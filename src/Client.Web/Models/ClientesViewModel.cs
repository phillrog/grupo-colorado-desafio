namespace Client.Web.Models
{
    public class ClientesViewModel
    {
        public IReadOnlyCollection<ClienteViewModel> Clientes { get; init; } = Array.Empty<ClienteViewModel>();
    }
}
