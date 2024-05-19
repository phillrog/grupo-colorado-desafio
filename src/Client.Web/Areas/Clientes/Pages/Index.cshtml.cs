using Client.Web.Areas.Clientes.Models;
using Client.Web.Areas.Clientes.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Web.Areas.Clientes.Pages
{
    public class IndexModel : PageModel
    {
        private IClientesService _clientesService;

        public IndexModel(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        public IList<Cliente> Cliente { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var result = await _clientesService.GetAllClients();
            Cliente = result.Clientes.ToList();
        }
    }
}
