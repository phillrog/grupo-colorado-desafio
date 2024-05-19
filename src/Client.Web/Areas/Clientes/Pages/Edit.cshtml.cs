using Client.Web.Areas.Clientes.Models;
using Client.Web.Areas.Clientes.Services;
using Client.Web.Utils;
using Client.Web.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Web.Areas.Clientes.Pages
{
    [Authorize]
    public class EditModel : BasePageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditModel(IClientesService clienteService, IHttpContextAccessor httpContextAccessor) : base(clienteService)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            base.Initialize();
            var user = _httpContextAccessor.HttpContext.User;
            try
            {
                Cliente = await _clienteService.GetClientById(id ?? 0);

                if (Cliente == null)
                {
                    TempData.GravarMensagem("erro", "Cliente não encontrado!");
                    return RedirectToPage("./Index");
                }

                Cliente.EmEdicao = true;

            }
            catch (Exception ex)
            {
                TempData.GravarMensagem("erro", "Oops! Ocorreu uma falha inesperada, por favor tente mais tarde!");
                return RedirectToPage("./Index");
            }

            TempData.Put<Cliente>("ClienteData", Cliente);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Cliente cliente)
        {

            if (!ModelState.IsValid) return Page();

            try
            {
                await _clienteService.PutClient(cliente);
                TempData.GravarMensagem("sucesso", "Cliente editado com sucesso!");
            }
            catch (Exception ex)
            {
                TempData.GravarMensagem("erro", "Oops! Ocorreu uma falha inesperada, por favor tente mais tarde!");
            }

            return RedirectToPage("./Index");
        }
    }
}
