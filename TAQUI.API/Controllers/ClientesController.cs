using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;
using TAQUI.Model;
using TAQUI.Model.DTO.Request;
using TAQUI.Model.DTO.Response;
using TAQUI.Repository;
using TAQUI.Service.ConvertMapping;

namespace TAQUI.API.Controllers
{

    /// <summary>
    /// Controlador responsável por gerenciar clientes.
    /// </summary>
    [Route("api/clientes/[controller]")]
    [ApiController]
    [Tags("Clientes")]
    public class ClientesController(IRepository<Cliente> clienteRepository) : ControllerBase
    {
        private readonly IRepository<Cliente> _clienteRepository = clienteRepository;
        private readonly ClienteService _clienteService = new ClienteService();


        /// <summary>
        /// Retorna a lista completa de clientes.
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     GET /cliente
        /// 
        /// Esse endpoint retorna uma lista de todos os clientes disponíveis no sistema.
        /// </remarks>
        /// <response code="200">Retorna a lista de clientes</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClienteResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(TAQUI.Model.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteResponse>>> GetAll()
        {
            IEnumerable<Cliente> clientes = await _clienteRepository.GetAll();

            //Retorna um enumerable de clientes sem os dados sensíveis.
            return Ok(_clienteService.clientesToResponseIEnumerable(clientes));

        }

        /// <summary>
        /// Retorna um cliente com base no id fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     GET /cliente/id
        /// 
        /// Esse endpoint retorna um cliente com base no id fornecido.
        /// </remarks>
        /// <response code="200">Retorna o cliente</response>
        /// <response code="404">Nenhum cliente encontrado</response>
        /// <response code="500">Erro interno no servidor</response>
        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(TAQUI.Model.ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string id)
        {

            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest("ID inválido. Deve ser uma string hexadecimal de 24 caracteres.");
            }

            var cliente = await _clienteRepository.GetById(objectId);
            if (cliente == null)
            {
                return NotFound();
            }

            //Retorna o cliente sem seus dados sensíveis.
            return Ok(_clienteService.clienteToResponse(cliente));
        }

        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     POST /cliente
        /// 
        /// Esse endpoint salva os dados do cliente no banco de dados.
        /// </remarks>
        /// <response code="200">Cliente criado</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Erro de servidor</response>
        // POST api/<ClientesController>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(TAQUI.Model.ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(ClienteRequest clienteRequest)
        {
            Cliente cliente = new Cliente();
            ClienteResponse clienteResponse = new ClienteResponse();

            cliente = await _clienteService.requestToClienteAsync(clienteRequest);

            if (cliente == null)
            {
                return BadRequest();
            }

            await _clienteRepository.Add(cliente);
            clienteResponse = _clienteService.clienteToResponse(cliente);

            // Retorna o cliente sem seus dados sensíveis.
            return Ok(clienteResponse);
        }

        /// <summary>
        /// Atualiza um cliente com base no id fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     PUT /cliente/{id}
        /// 
        /// Esse endpoint atualiza o cliente com base no id fornecido.
        /// </remarks>
        /// <response code="200">Cliente atualizado</response>
        /// <response code="404">Nenhum cliente encontrado</response>
        /// <response code="500">Erro interno no servidor</response>
        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClienteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(TAQUI.Model.ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(string id, [FromBody] ClienteRequest clienteRequest)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest("ID inválido. Deve ser uma string hexadecimal de 24 caracteres.");
            }

            Cliente cliente = new Cliente();
            ClienteResponse clienteResponse = new ClienteResponse();

            cliente = await _clienteService.requestToClienteAsync(clienteRequest);
            cliente.Id = objectId;

            Cliente existingCliente = await _clienteRepository.GetById(objectId);

            if (existingCliente == null)
            {
                return NotFound();
            }

            await _clienteRepository.Update(objectId, cliente);
            clienteResponse = _clienteService.clienteToResponse(cliente);

            // Retorna o cliente com seus dados alterados, sem seus dados sensíveis.
            return Ok(clienteResponse);
        }

        /// <summary>
        /// Deleta um cliente com base no id fornecido.
        /// </summary>
        /// <remarks>
        /// Exemplo de solicitação:
        /// 
        ///     DELETE/cliente/{id}
        /// 
        /// Esse endpoint deleta o cliente com base no id fornecido.
        /// </remarks>
        /// <response code="200">Cliente deletado</response>
        /// <response code="404">Nenhum cliente encontrado</response>
        /// <response code="500">Erro interno no servidor</response>
        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(TAQUI.Model.ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest("ID inválido. Deve ser uma string hexadecimal de 24 caracteres.");
            }

            var cliente = await _clienteRepository.GetById(objectId);
            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteRepository.Delete(objectId);

            //Retorna nada.
            return Ok();
        }

    }
}
