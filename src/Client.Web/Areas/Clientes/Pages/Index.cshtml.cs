using Client.Web.Areas.Clientes.Models;
using Client.Web.Areas.Clientes.Services;
using Client.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        
        public string Search = "";
        
        public string column = "NomeFantasia";
        public string orderBy = "desc";

        public int pageIndex = 1;
        public int totalpage = 0;
        private readonly int pageSize = 5;

        public async Task OnGetAsync(int? pageIndex, string? search, string? column, string? orderBy)
        {
            var result = await _clientesService.GetAllClients();
            var query = new List<Cliente>(result.Clientes);
            if (search != null)
            {
                this.Search = search;
                query = query.Where(p => p.NomeFantasia.Contains(search) || p.RazaoSocial.Contains(search) || p.Cep.Contains(search)).ToList();
            }
            
            string[] validColumn = { "RazaoSocial", "NomeFantasia", "Cep"};
            string[] validOrderBy = { "desc", "asc" };

            if (!validOrderBy.Contains(orderBy))
            {
                orderBy = "desc";
            }
            this.orderBy = orderBy;
            this.column = column;

            
            if (column == "RazaoSocial")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.RazaoSocial).ToList();
                }
                else
                {
                    query = query.OrderByDescending(p => p.RazaoSocial).ToList();
                }
            }
            else if (column == "NomeFantasia")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.NomeFantasia).ToList();
                }
                else
                {
                    query = query.OrderByDescending(p => p.NomeFantasia).ToList();
                }
            }
            else if (column == "Cep")
            {
                if (orderBy == "asc")
                {
                    query = query.OrderBy(p => p.Cep).ToList();
                }
                else
                {
                    query = query.OrderByDescending(p => p.Cep).ToList();
                }
            }

            if (pageIndex == null || pageIndex < 1)
            {
                pageIndex = 1;
            }
            this.pageIndex = (int)pageIndex;

            decimal count = query.Count();
            totalpage = (int)Math.Ceiling(count / pageSize);
            query = query.Skip((this.pageIndex - 1) * pageSize).Take(pageSize).ToList();            

            Cliente = query;            
        }
    }
}
