using Client.Web.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Client.Web.Areas.Clientes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Client.Web.Areas.Clientes.Services;
using Microsoft.AspNetCore.Authorization;

namespace Client.Web.Web
{
    [Authorize]
    //[IgnoreAntiforgeryToken]
    public class BasePageModel : PageModel
    {
        internal readonly IClientesService _clienteService;

        public BasePageModel(IClientesService clienteService)
        {
            _clienteService = clienteService;
        }
        internal List<SelectListItem> TipoPessoas { get; set; }
        internal List<SelectListItem> TipoTelefones { get; set; }
        internal Telefone Telefone { get; set; } = new Telefone();

        [BindProperty]
        public Cliente Cliente { get; set; }

        public Message StatusMessage { get; set; }

        protected void Initialize()
        {
            TempData.Limpar();

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


        public PartialViewResult PartialViewRefresh(Cliente cliente)
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

        protected void PreserveState(Cliente cliente)
        {
            this.Cliente = cliente;

            TempData.Put<Cliente>("ClienteData", cliente);
        }

        protected Cliente RecoverState()
        {
            return TempData.Get<Cliente>("ClienteData");
        }
    }
}
