using Client.Domain.Commom;
using Client.Domain.Enums;
using Client.Domain.Exceptions;

namespace Client.Domain.ValueObjects
{
    public class TipoTelefone(TipoTelefoneEnum tipo) : ValueObject<TipoTelefone>
    {
        public int Id { get; private set; }
        public string Descricao => ((TipoTelefoneEnum)Id).ToString();

        public static TipoTelefone From(TipoTelefoneEnum tipo)
        {
            var tipoTelefone = new TipoTelefone(tipo);

            if (!Supported.Contains(tipoTelefone))
            {
                throw new UnsupportedTipoTelefoneException((int)tipo);
            }

            return tipoTelefone;
        }

        public static TipoTelefone Residencial => new(TipoTelefoneEnum.Residencial);

        public static TipoTelefone Comercial => new(TipoTelefoneEnum.Comercial);

        public static TipoTelefone Whatsapp => new(TipoTelefoneEnum.Whatsapp);

        public static TipoTelefone Celular => new(TipoTelefoneEnum.Celular);

        protected override bool EqualsCore(TipoTelefone other) => Descricao == other.Descricao;

        protected override int GetHashCodeCore() => Descricao.GetHashCode() * 400;

        protected static IEnumerable<TipoTelefone> Supported
        {
            get
            {
                yield return Residencial;
                yield return Comercial;
                yield return Whatsapp;
                yield return Celular;
            }
        }

        public static implicit operator string(TipoTelefone tipo)
        {
            return tipo.Id.ToString();
        }

        public static explicit operator TipoTelefone(TipoTelefoneEnum tipo)
        {
            return From(tipo);
        }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
