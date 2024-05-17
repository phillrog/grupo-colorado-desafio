using Client.Domain.Interfaces;
using Client.Domain.ValueObjects;

namespace Client.Domain.Entities
{
    public class Telefone : Entity
    {
        public Guid Id { get; private set; }
        public int IdCliente { get; protected  set; }
        public string NumeroTelefone { get; protected  set; }
        public string Operadora { get; protected  set; }
        public bool Ativo { get; protected  set; }
        public string DataInsercao { get; protected  set; }
        public string UsuarioInsercao { get; protected  set; }
        public Cliente  Cliente { get; protected  set; }
        public TipoTelefone TipoTelefone { get; set; }

        public Telefone() {}
    }
}
