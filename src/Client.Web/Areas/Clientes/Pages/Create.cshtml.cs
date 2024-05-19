using Client.Web.Areas.Clientes.Models;
using Client.Web.Areas.Clientes.Services;
using Client.Web.Utils;
using Client.Web.Web;
using Microsoft.AspNetCore.Mvc;

namespace Client.Web.Areas.Clientes.Pages
{
    public class CreateModel : BasePageModel
    {
        public CreateModel(IClientesService clienteService) : base(clienteService) { }
        
        public IActionResult OnGetAsync()
        {
            base.Initialize();

            Cliente = new Cliente();

            TempData.Put<Cliente>("ClienteData", Cliente);

            return Page();
        }        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Cliente cliente)
        {
            
            if (!ModelState.IsValid) return Page();

            try
            {
                await _clienteService.PostClient(cliente);
                TempData.GravarMensagem("sucesso", "Cliente registrado com sucesso!");
            }
            catch (Exception ex)
            {
                TempData.GravarMensagem("erro", "Oops! Ocorreu uma falha inesperada, por favor tente mais tarde!");
            }

            return RedirectToPage("./Index");
        }
    }
}
