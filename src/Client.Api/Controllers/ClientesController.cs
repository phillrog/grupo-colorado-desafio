using Client.Application.Clientes.Commands.Create;
using Client.Application.Clientes.Queries.GetAll;
using Client.Application.Clientes.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Client.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ClientesVM> Get()
        {
            return await _mediator.Send(new GetAllClientesQuery());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ClienteVM> Get(int id)
        {
            return await _mediator.Send(new GetByIdClientesQuery(id));
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateClienteCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
