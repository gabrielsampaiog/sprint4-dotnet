using Microsoft.AspNetCore.Mvc;
using System.Net;
using TAQUI.Model;
using TAQUI.Repository;

namespace TAQUI.API.Controllers
{

    /// <summary>
    /// Controlador responsável por gerenciar produtos.
    /// </summary>
    [Route("api/produtos/[controller]")]
    [ApiController]
    [Tags("Produtos")]
    public class ProdutosController(IRepository<Produto> produtoRepository) : ControllerBase
    {
        private readonly IRepository<Produto> _produtoRepository = produtoRepository;

        /// <summary>
        /// Cria um novo produto.
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     POST /produto
        /// 
        /// Esse endpoint salva os dados do produto no banco de dados.
        /// </remarks>
        /// <response code="200">Produto criado</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Erro de servidor</response>
        // POST api/<ProdutosController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(TAQUI.Model.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(Produto produto)
        {
            await _produtoRepository.Add(produto);

            return Ok();
        }


    }
}

