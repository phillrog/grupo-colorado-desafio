using Client.Application.Models;

namespace Client.Application.Clientes.Queries.GetAll
{
    public class ClientesVM
    {
        public IReadOnlyCollection<ClientesDTO> Clientes { get; init; } = Array.Empty<ClientesDTO>();
    }
}
