using System.ComponentModel.DataAnnotations;

namespace Client.Web.Areas.Clientes.Models
{
    public class Telefone
    {
        public Guid? Id { get; set; }
        public int? IdCliente { get; set; }
        [Display(Name ="Número")]
        public string NumeroTelefone { get; set; }
        [Display(Name = "DDD")]
        public string Operadora { get; set; }
        public bool? Ativo { get; set; }
        public int IdTipoTelefone { get; set; }
        [Display(Name = "Tipo")]
        public string TipoTelefone { get; set; }        
    }
}
