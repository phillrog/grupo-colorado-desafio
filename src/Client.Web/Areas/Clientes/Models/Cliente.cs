using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Client.Web.Areas.Clientes.Models
{
    public class Cliente
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
        public List<Telefone> Telefones { get; set; }
        public int? UsuarioInclusao { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime? DataInclusao { get; set; }
        [NotMapped]
        public bool EmEdicao { get; set; }

        public Cliente()
        {
            Telefones = new List<Telefone>();
        }
    }

    public class ClientesLista
    {
        public IReadOnlyCollection<Cliente> Clientes { get; init; } = Array.Empty<Cliente>();
    }
}
