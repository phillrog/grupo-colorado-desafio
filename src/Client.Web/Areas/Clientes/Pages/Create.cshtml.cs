using Client.Web.Areas.Clientes.Models;
using Client.Web.Areas.Clientes.Services;
using Client.Web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Reflection.PortableExecutable;

namespace Client.Web.Areas.Clientes.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IClientesService _clienteService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateModel(IClientesService clienteService,
            IHttpContextAccessor httpContextAccessor)
        {
            _clienteService = clienteService;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<SelectListItem> TipoPessoas { get; set; }
        public List<SelectListItem> TipoTelefones { get; set; }
        public Telefone Telefone { get; set; } = new Telefone();

        [BindProperty]
        public Cliente Cliente { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult OnGet()
        {
            TipoPessoas = new List<SelectListItem>() {
                new SelectListItem { Text = "Selecione", Value = "", Selected = true },
                new SelectListItem { Text = "Física", Value = "1" },
                new SelectListItem { Text = "Jurídica", Value = "2" }
            };

            TipoTelefones = new List<SelectListItem>() {
                new SelectListItem { Text = "Selecione", Value = "",Selected = true },
                new SelectListItem { Text = "Residencial", Value = "1" },
                new SelectListItem { Text = "Comercial", Value = "2" },
                new SelectListItem { Text = "Whatsapp", Value = "3" },
                new SelectListItem { Text = "Celular", Value = "4" },
            };

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
                StatusMessage = "Cliente registrado com sucesso!";
            }
            catch (Exception ex)
            {
                StatusMessage = "Oops! Ocorreu uma falha inesperada, por favor tente mais tarde!";
            }

            return RedirectToPage("./Index");
        }

        public JsonResult OnGetGetLatestData()
        {
            var result = new Cliente();
            if (TempData.Get<Cliente>("ClienteData") != null)
            {
                result = RecoverState();
            };

            return new JsonResult(result);
        }

        public PartialViewResult OnPostAddNewTelefone(Cliente cliente)
        {            
            var partialViewResult = PartialViewRefresh(cliente);

            PreserveState(cliente);                 

            return partialViewResult;
        }

        public PartialViewResult OnPostRemoveTelefone(Cliente cliente)
        {
            var partialViewResult = PartialViewRefresh(cliente);

            PreserveState(cliente);

            return partialViewResult;
        }


        private PartialViewResult PartialViewRefresh(Cliente cliente)
        {
            var partialView = "_TelefonePartial";

            var data = cliente;

            var myViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { { partialView, cliente } };

            myViewData.Model = data;

            return new PartialViewResult()
            {
                ViewName = partialView,
                ViewData = myViewData,
            };
        }

        private void PreserveState(Cliente cliente)
        {
            this.Cliente = cliente;

            TempData.Put<Cliente>("ClienteData", cliente);
        }

        private Cliente RecoverState()
        {
            return TempData.Get<Cliente>("ClienteData");
        }

    }
}
