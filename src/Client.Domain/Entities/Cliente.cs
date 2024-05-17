using Client.Domain.Commom;
using Client.Domain.Enums;

namespace Client.Domain.Entities
{
    public class Cliente : Entity
    {
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public TipoPessoaEnum TipoPessoa { get; private set; }
        public string Documento { get; private set; }
        public string Endereco { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Cep { get; private set; }
        public string Uf { get; private set; }
        public string DataInsercao { get; private set; }
        public string UsuarioInsercao { get; private set; }
    }
}
