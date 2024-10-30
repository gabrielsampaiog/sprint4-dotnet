using Microsoft.AspNetCore.Mvc;
using TAQUI.Model;
using TAQUI.Repository;
using _2TDPM.Services.Recommendation;
using TAQUI.Service.ClienteViewService;
using MongoDB.Bson;
using TAQUI.Service.ConvertMapping;
using System.Net;
using TAQUI.Model.DTO.Response;

namespace TAQUI.API.Controllers
{

    /// <summary>
    /// Controlador responsável por gerenciar recomendação de produtos.
    /// </summary>
    [Route("api/clientes/[controller]")]
    [ApiController]
    [Tags("ClienteView")]
    public class ProdutoRecommendationController(IClienteViewService clienteViewService, RecommendationEngine recommendationEngine, IRepository<Produto> repositoryProduto) : ControllerBase
    {
        private readonly IClienteViewService _clienteViewService = clienteViewService;
        private readonly IRepository<Produto> _repositoryProduto = repositoryProduto;
        private readonly RecommendationEngine _recommendationEngine = recommendationEngine;

        /// <summary>
        /// Cria uma nova view de produto.
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     POST /viewcliente
        /// 
        /// Esse endpoint salva uma nova view de produto no banco de dados.
        /// </remarks>
        /// <response code="201">View criada</response>
        // POST api/<ProdutoRecommendationController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> PostClienteViewAsync([FromBody] ClienteView clienteView)
        {
            _clienteViewService.AddClienteView(clienteView);
            return Created();
        }

        /// <summary>
        /// Retorna uma recomendação com base no id fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     GET /clienteId
        /// 
        /// Esse endpoint retorna uma recomendação com base no id fornecido.
        /// </remarks>
        /// <response code="200">Retorna o cliente</response>
        [HttpGet("{clienteId}")]
        [ProducesResponseType(typeof(ClienteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(TAQUI.Model.ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRecommendations(string clienteId)
        {
            if (!ObjectId.TryParse(clienteId, out ObjectId parsedUserId))
            {
                return BadRequest("Invalid cliente ID");
            }

            _recommendationEngine.PrepareTrainModel((IEnumerable<ClienteView>)_clienteViewService.GetClienteViews());

            var products = _repositoryProduto.GetAll();

            var recommendedProdutos = new List<Produto>();

            foreach (var product in await products)
            {
                float score = _recommendationEngine.Predict(parsedUserId, product.Id);

                if (score > 0.5)
                {
                    recommendedProdutos.Add(product);
                }
            }

            return Ok(recommendedProdutos);
        }
    }
}

