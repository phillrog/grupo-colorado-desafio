using System.ComponentModel.DataAnnotations;

namespace Client.Web.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Razão Social")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }
        public int TipoPessoa { get; set; }
        public string Documento { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        [Display(Name = "UF")]
        public string Uf { get; set; }
        public IEnumerable<TelefoneViewModel> Telefones { get; set; }        
    }
}
