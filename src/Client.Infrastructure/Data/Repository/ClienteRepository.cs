using Client.Domain.Interfaces;
using Client.Domain.Entities;
using Client.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Client.Infrastructure.Data.Models;

namespace Client.Infrastructure.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _context;
        public ClienteRepository(ClienteDbContext clienteDbContext)
        {
            _context = clienteDbContext;
        }

        public void Add(ClienteDomain domain)
        {
            _context.Cliente.Add(ToModel(domain));
        }

        public async Task<IEnumerable<ClienteDomain>> GetAll()
        {
            return await Task.FromResult(_context.Cliente.AsNoTracking().Select(ToDomain));
        }

        public async Task<ClienteDomain> GetById(int id)
        {
            var entity = _context.Cliente.Include(d=> d.Telefones).First(d => d.Id == id);
            if (entity == null)
                return null;

            return await Task.FromResult(ToDomain(entity));
        }

        public void Remove(ClienteDomain domain)
        {
            var model = ToModel(domain);
            _context.Cliente.Remove(model);
        }

        public void Update(ClienteDomain domain)
        {
            var model = ToModel(domain);
            _context.Cliente.Update(model);
        }

        private Cliente ToModel(ClienteDomain domain)
        {
            return new Cliente()
            {
                Id = domain.Id,
                RazaoSocial = domain.RazaoSocial,
                NomeFantasia = domain.NomeFantasia,
                TipoPessoa = domain.TipoPessoa,
                Documento = domain.Documento,
                Endereco = domain.Endereco,
                Complemento = domain.Complemento,
                Bairro = domain.Bairro,
                Cidade = domain.Cidade,
                Cep = domain.Cep,
                Uf = domain.Uf,
                Telefones = domain.Telefones.Select(t => new Telefone()
                {
                    Id = t.Id,
                    Ativo = t.Ativo,
                    IdCliente = t.IdCliente,
                    NumeroTelefone = t.NumeroTelefone,
                    Operadora = t.Operadora,
                    TipoTelefone = t.TipoTelefone
                }).ToList()
            };
        }

        private ClienteDomain ToDomain(Cliente model)
        {
            return new ClienteDomain(model.Id,
                model.RazaoSocial,
                model.NomeFantasia,
                (int)model.TipoPessoa,
                model.Documento,
                model.Endereco,
                model.Complemento,
                model.Bairro,
                model.Cidade,
                model.Cep,
                model.Uf,
                model.Telefones.Select(t => new TelefoneDomain(
                    t.Id,
                    t.IdCliente,
                    t.Operadora,
                    t.NumeroTelefone,
                    t.Ativo,
                    t.TipoTelefone.Id
                )));
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}