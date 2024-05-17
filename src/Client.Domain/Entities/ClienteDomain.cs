using Client.Domain.Common;
using Client.Domain.Enums;

namespace Client.Domain.Entities
{
    public class ClienteDomain : BasicEntity<int>
    {
        public ClienteDomain(int id) : base(id) { }

        public ClienteDomain(string razaoSocial, string nomeFantasia, TipoPessoaEnum tipoPessoa, string documento, string endereco, string complemento, string bairro, string cidade, string cep, string uf, IEnumerable<TelefoneDomain> telefones)
            : base(0)
        {
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            TipoPessoa = tipoPessoa;
            Documento = documento;
            Endereco = endereco;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Uf = uf;
            Telefones = telefones;
        }

        public ClienteDomain(int id, string razaoSocial, string nomeFantasia, int tipoPessoa, string documento, string endereco, string complemento, string bairro, string cidade, string cep, string uf, IEnumerable<TelefoneDomain> telefones)
            : base(0)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            TipoPessoa = (TipoPessoaEnum)tipoPessoa;
            Documento = documento;
            Endereco = endereco;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Uf = uf;
            Telefones = telefones;
        }

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
        public IEnumerable<TelefoneDomain> Telefones { get; private set; }
    }
}
