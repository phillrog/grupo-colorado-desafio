using Client.Application.Clientes.Commands.Create;
using Client.Domain.Entities;


namespace Client.Application.Factories
{
    public static class TelefoneFactory
    {
        public static IEnumerable<TelefoneDomain> Create(IEnumerable<TelefoneCreateCommand> command)
        {
            return command.Select(x => new TelefoneDomain(Guid.NewGuid(), 0, x.NumeroTelefone, x.Operadora, true, x.TipoTelefone));
        }
    }
}
