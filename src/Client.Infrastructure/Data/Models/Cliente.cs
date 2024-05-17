using Client.Domain.Interfaces;
using Client.Domain.Enums;

namespace Client.Infrastructure.Data.Models
{
    public class Cliente : IEntity
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }

        public ICollection<Telefone> Telefones { get; set; }
        public int UsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; }        
    }
}
