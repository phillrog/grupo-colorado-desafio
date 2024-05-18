using Client.Web.Models;
using Client.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Web.Areas.Clientes.Pages
{
    public class DetailsModel : PageModel
    {
        private IClientesService _clientesService;

        public DetailsModel(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        public ClienteViewModel Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _clientesService.GetClientById(id);
            if (result != null)
            {
                Cliente = result;
                return Page();
            }
            return NotFound();
        }
    }
}
