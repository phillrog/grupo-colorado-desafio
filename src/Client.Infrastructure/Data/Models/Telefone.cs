using Client.Domain.Interfaces;
using Client.Domain.ValueObjects;

namespace Client.Infrastructure.Data.Models
{
    public class Telefone : IEntity
    {
        public Guid Id { get; set; }
        public int IdCliente { get; set; }
        public string NumeroTelefone { get; set; }
        public string Operadora { get; set; }
        public bool Ativo { get; set; }
        public Cliente Cliente { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public int UsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; }

        public Telefone() { }
    }
}
