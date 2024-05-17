using Client.Application.Factories;
using Client.Domain.Interfaces;

namespace Client.Application.Clientes.Commands.Create
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var domain = ClienteFactory.Create(request);

            _clienteRepository.Add(domain);

            var result = await _clienteRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(result > 0);
        }
    }
}
