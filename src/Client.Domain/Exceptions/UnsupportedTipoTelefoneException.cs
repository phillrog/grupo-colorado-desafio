namespace Client.Domain.Exceptions
{
    public class UnsupportedTipoTelefoneException : Exception
    {
        public UnsupportedTipoTelefoneException(int tipo)
        : base($"Tipo telefone \"{tipo}\" is unsupported.")
        {
        }
    }
}
