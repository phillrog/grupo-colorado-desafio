using Client.Web.Models;
using Client.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol;

namespace Client.Web.Areas.Clientes.Pages
{
    public class IndexModel : PageModel
    {
        private IClientesService _clientesService;

        public IndexModel(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        public IList<ClienteViewModel> Cliente { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var result = await _clientesService.GetAllClients();
            Cliente = result.Clientes.ToList();
        }
    }
}
