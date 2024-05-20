using Client.Web.Areas.Clientes.Models;
using Client.Web.Areas.Clientes.Services;
using Client.Web.Utils;
using Client.Web.Web;
using Microsoft.AspNetCore.Mvc;

namespace Client.Web.Areas.Clientes.Pages
{
    public class DetailsModel : BasePageModel
    {        
        public DetailsModel(IClientesService clientesService) : base(clientesService) { }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            base.Initialize();
            if (id == null)
            {
                TempData.GravarMensagem("aviso", "Id inválido!");
                return RedirectToPage("./Index");
            }
            try
            {
                Cliente = await _clienteService.GetClientById(id.Value);
                if (Cliente == null)
                {
                    TempData.GravarMensagem("erro", "Cliente não encontrado!");
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception)
            {
                TempData.GravarMensagem("erro", "Oops! Ocorreu uma falha inesperada, por favor tente mais tarde!");
                return RedirectToPage("./Index");
            }
            Cliente.EmDetalhes = true;
            return Page();
        }
    }
}
