using Client.Web.Areas.Clientes.Services;
using Client.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Client.Web.Areas.Clientes.Pages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IClientesService _clientesService;

        public DeleteModel(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        public async Task<IActionResult> OnPostDeletarClienteAsync(int? id)
        {
            if (id == null)
            {
                TempData.GravarMensagem("aviso", "Id inválido!");
                return RedirectToPage("./Index");
            }
            try
            {
                await _clientesService.DeleteClient(id.Value);
                TempData.GravarMensagem("sucesso", "Cliente deletado com sucesso!");
            }
            catch (Exception)
            {
                TempData.GravarMensagem("erro", "Oops! Ocorreu uma falha inesperada, por favor tente mais tarde!");
            }
            return RedirectToPage("./Index");
        }

    }
}
