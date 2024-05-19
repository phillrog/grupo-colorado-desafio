using Client.Domain.Interfaces;

namespace Client.Application.Clientes.Commands.Delete
{
    public class DeleteClienteCommandHandler: IRequestHandler<DeleteClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;

        public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsNoTracking(request.Id);

            Guard.Against.NotFound(request.Id, cliente);

            _clienteRepository.Remove(cliente);

            var result = await _clienteRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(result > 0);
        }
    }
}
