
using Client.Application.Factories;
using Client.Domain.Interfaces;

namespace Client.Application.Clientes.Commands.Create
{
    public record CreateClienteCommand : IRequest<int>
    {
        public string RazaoSocial { get; init; }
        public string NomeFantasia { get; init; }
        public int TipoPessoa { get; init; }
        public string Documento { get; init; }
        public string Endereco { get; init; }
        public string Complemento { get; init; }
        public string Bairro { get; init; }
        public string Cidade { get; init; }
        public string Cep { get; init; }
        public string Uf { get; init; }
        public IEnumerable<TelefoneCommand> Telefones { get; init; }

    }

    public record TelefoneCommand
    {
        public Guid Id { get; init; }
        public int IdCliente { get; init; }
        public string NumeroTelefone { get; init; }
        public string Operadora { get; init; }
        public bool Ativo { get; init; }
        public int TipoTelefone { get; init; }
    }

    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var domain = ClienteFactory.Create(request);

            _clienteRepository.Add(domain);

            await _clienteRepository.SaveChangesAsync(cancellationToken);

            return domain.Id;
        }
    }
}
