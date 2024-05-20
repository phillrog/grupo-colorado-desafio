using Client.Application.Clientes.Commands.Create;
using Client.Application.Clientes.Commands.Delete;
using Client.Application.Clientes.Commands.Update;
using Client.Application.Clientes.Queries.GetAll;
using Client.Application.Clientes.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Client.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Listar Clientes.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Retorna 200 com a lista inteira de clientes</returns>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET 
        ///     
        ///
        /// </remarks>
        /// <response code="200">Retorna quando houver sucesso na listagem</response>
        /// <response code="500">Quando algum erro interno acontecer</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ClientesVM> Get()
        {
            return await _mediator.Send(new GetAllClientesQuery());
        }

        /// <summary>
        /// Pesquisar um cliente por Id
        /// </summary>
        /// <param name="item">Id</param>
        /// <returns>Retorna 200 com os dados do cliente</returns>
        /// <remarks>
        /// Exemplo:
        ///
        ///    GET api/v1/clientes/5 
        ///     
        ///
        /// </remarks>
        /// <response code="200">Retorna quando houver sucesso na pesquisa</response>
        /// <response code="500">Quando algum erro interno acontecer</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ClienteVM> Get(int id)
        {
            return await _mediator.Send(new GetByIdClientesQuery(id));
        }

        /// <summary>
        /// Gravar um cliente 
        /// </summary>
        /// <param name="item">CreateClienteCommand</param>
        /// <returns>Retorna 201</returns>
        /// <remarks>
        /// Exemplo:
        ///
        ///    POST api/v1/clientes/
        ///    {
        ///      "razaoSocial": "TESTE",
        ///      "nomeFantasia": "TESTE",
        ///      "tipoPessoa": 1,
        ///      "documento": "TESTE",
        ///      "endereco": "TESTE",
        ///      "complemento": "TESTE",
        ///      "bairro": "TESTE",
        ///      "cidade": "TESTE",
        ///      "cep": "14270-000",
        ///      "uf": "SP",
        ///      "telefones": [
        ///        {
        ///          "id": "10017993-3A21-4DCB-A503-365CAEABF222",
        ///          "numeroTelefone": "999999999",
        ///          "operadora": "016",
        ///          "idTipoTelefone": 1
        ///        }
        ///    }
        ///
        /// </remarks>
        /// <response code="201">Retorna quando gravar com sucesso</response>
        /// <response code="400">Retorna quando algum dado inválido</response>
        /// <response code="500">Quando algum erro interno acontecer</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Atualizar os dados de um cliente 
        /// </summary>
        /// <param name="item">CreateClienteCommand</param>
        /// <returns>Retorna 203</returns>
        /// <remarks>
        /// Exemplo:
        ///
        ///    PUT api/v1/clientes/
        ///    {
        ///      "id": "1",
        ///      "razaoSocial": "TESTE",
        ///      "nomeFantasia": "TESTE",
        ///      "tipoPessoa": 1,
        ///      "documento": "TESTE",
        ///      "endereco": "TESTE",
        ///      "complemento": "TESTE",
        ///      "bairro": "TESTE",
        ///      "cidade": "TESTE",
        ///      "cep": "14270-000",
        ///      "uf": "SP",
        ///      "telefones": [
        ///        {
        ///          "id": "10017993-3A21-4DCB-A503-365CAEABF222",
        ///          "idCliente": 1,
        ///          "ativo": true,
        ///          "numeroTelefone": "999999999",
        ///          "operadora": "016",
        ///          "idTipoTelefone": 1
        ///        }
        ///    }
        ///
        /// </remarks>
        /// <response code="203">Retorna quando atualizar com sucesso</response>
        /// <response code="400">Retorna quando algum dado inválido</response>
        /// <response code="404">Retorna quando id do usuário não for encontrado na base</response>
        /// <response code="500">Quando algum erro interno acontecer</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateClienteCommand command)
        {
            if (id != command.Id) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Remover um cliente 
        /// </summary>
        /// <param name="item">Id</param>
        /// <returns>Retorna 203</returns>
        /// <remarks>
        /// Exemplo:
        ///
        ///    DELETE api/v1/clientes/5 
        ///     
        ///
        /// </remarks>
        /// <response code="203">Retorna quando deletar com sucesso</response>
        /// <response code="404">Retorna quando id do usuário não for encontrado na base</response>
        /// <response code="500">Quando algum erro interno acontecer</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteClienteCommand { Id = id });
            return NoContent();
        }
    }
}
