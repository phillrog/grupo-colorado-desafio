using AutoMapper;
using Client.Application.Models;
using Client.Domain.Interfaces;
using AutoMapper.QueryableExtensions;

namespace Client.Application.Clientes.Queries.GetAll
{
    public record GetAllClientesQuery : IRequest<ClientesVM>;

    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, ClientesVM>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetAllClientesQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClientesVM> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            var lista = await _clienteRepository.GetAll();
            return new ClientesVM() {
                Clientes = lista.AsQueryable().ProjectTo<ClientesDTO>(_mapper.ConfigurationProvider).OrderBy(t => t.NomeFantasia).ToList()
            };
        }
    }
}
