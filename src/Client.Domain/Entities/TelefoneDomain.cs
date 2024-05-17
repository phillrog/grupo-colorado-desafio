using Client.Domain.Common;
using Client.Domain.Enums;
using Client.Domain.ValueObjects;

namespace Client.Domain.Entities
{
    public class TelefoneDomain : BasicEntity<Guid>
    {
        public TelefoneDomain(Guid id) : base(id)
        {
            Id = Guid.NewGuid();
        }

        public TelefoneDomain(Guid id, int idCliente, string numeroTelefone, string operadora, bool ativo, int tipoTelefone)
            : base(id)
        {
            IdCliente = idCliente;
            NumeroTelefone = numeroTelefone;
            Operadora = operadora;
            Ativo = ativo;
            TipoTelefone = TipoTelefone.From((TipoTelefoneEnum)tipoTelefone);
        }


        public int IdCliente { get; private set; }
        public string NumeroTelefone { get; private set; }
        public string Operadora { get; private set; }
        public bool Ativo { get; private set; }
        public TipoTelefone TipoTelefone { get; private set; }
    }
}
