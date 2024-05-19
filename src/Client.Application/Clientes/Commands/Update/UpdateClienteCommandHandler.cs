using Client.Application.Factories;
using Client.Domain.Interfaces;
using System.Linq;


namespace Client.Application.Clientes.Commands.Update
{
    public class UpdateClienteCommandHandler: IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITelefoneRepository _telefoneRepository;

        public UpdateClienteCommandHandler(IClienteRepository clienteRepository, ITelefoneRepository telefoneRepository)
        {
            _clienteRepository = clienteRepository;
            _telefoneRepository = telefoneRepository;
        }

        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsNoTracking(request.Id);

            Guard.Against.NotFound(request.Id, cliente);

            var domain = ClienteFactory.Create(request);

            foreach (var telefone in cliente.Telefones)
            {
                _telefoneRepository.Remove(telefone);
                domain.Telefones.ToList().Add(telefone);
            }           

            _clienteRepository.Update(domain);

            
            var result = await _clienteRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(result > 0);
        }
    }
}
