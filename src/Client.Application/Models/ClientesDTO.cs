using AutoMapper;
using Client.Application.Clientes.Queries.GetById;
using Client.Domain.Entities;
using Client.Domain.Enums;

namespace Client.Application.Models
{
    public class ClientesDTO
    {
        public int Id { get; init; }
        public string RazaoSocial { get; init; }
        public string NomeFantasia { get; init; }
        public TipoPessoaEnum TipoPessoa { get; init; }
        public string Documento { get; init; }
        public string Endereco { get; init; }
        public string Complemento { get; init; }
        public string Bairro { get; init; }
        public string Cidade { get; init; }
        public string Cep { get; init; }
        public string Uf { get; init; }
        public IEnumerable<TelefoneDTO> Telefones { get; init; }
        public int? UsuarioInclusao { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime? DataInclusao { get; set; }
    }

    public class TelefoneDTO
    {
        public Guid Id { get; init; }
        public int IdCliente { get; init; }
        public string NumeroTelefone { get; init; }
        public string Operadora { get; init; }
        public bool Ativo { get; init; }
        public int IdTipoTelefone { get; set; }
        public string TipoTelefone { get; set; }
    }

    public class ClienteMapping : Profile
    {
        public ClienteMapping()
        {
            CreateMap<ClienteDomain, ClientesDTO>();
            CreateMap<ClienteDomain, ClienteVM>();
        }
    }

    public class TelefoneMapping : Profile
    {
        public TelefoneMapping()
        {
            CreateMap<TelefoneDomain, TelefoneDTO>().AfterMap((src, dest) =>
            {
                dest.TipoTelefone = src.TipoTelefone.ToString() ;
                dest.IdTipoTelefone = src.TipoTelefone.Id;
            });
        }
    }
}
