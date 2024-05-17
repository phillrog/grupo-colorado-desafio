using AutoMapper;
using Client.Application.Models;
using Client.Domain.Interfaces;
using AutoMapper.QueryableExtensions;
using Client.Application.Clientes.Queries.GetAll;
using Ardalis.GuardClauses;

namespace Client.Application.Clientes.Queries.GetById
{
    public record GetByIdClientesQuery : IRequest<ClienteVM>
    {
        public int Id { get; init; }
        public GetByIdClientesQuery(int id)
        {
            Id = id;
        }
    };

    public class GetAllClientesQueryHandler : IRequestHandler<GetByIdClientesQuery, ClienteVM>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetAllClientesQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteVM> Handle(GetByIdClientesQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetById(request.Id);
            
            Guard.Against.NotFound(request.Id, cliente);

            return _mapper.Map<ClienteVM>(cliente);
        }
    }
}
