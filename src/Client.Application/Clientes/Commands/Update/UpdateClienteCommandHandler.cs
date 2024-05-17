using Client.Application.Factories;
using Client.Domain.Interfaces;


namespace Client.Application.Clientes.Commands.Update
{
    public class UpdateClienteCommandHandler: IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetById(request.Id);

            Guard.Against.NotFound(request.Id, cliente);

            var domain = ClienteFactory.Create(request);

            _clienteRepository.Update(domain);

            var result = await _clienteRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(result > 0);
        }
    }
}
