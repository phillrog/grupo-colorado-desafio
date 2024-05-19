using Client.Domain.Interfaces;
using Client.Domain.Entities;
using Client.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Client.Infrastructure.Data.Models;
using Client.Domain.Enums;

namespace Client.Infrastructure.Data.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly ClienteDbContext _context;
        public TelefoneRepository(ClienteDbContext clienteDbContext)
        {
            _context = clienteDbContext;
        }

        public void Add(TelefoneDomain domain)
        {
            _context.Telefone.Add(ToModel(domain));
        }

        public async Task<IEnumerable<TelefoneDomain>> GetAll()
        {
            return await Task.FromResult(_context.Telefone.AsNoTracking().Select(ToDomain).ToList());
        }

        public async Task<TelefoneDomain> GetById(int id)
        {
           throw new NotImplementedException();
        }

        public void Remove(TelefoneDomain domain)
        {
            var model = ToModel(domain);

            _context.Remove(_context.Telefone.First(d => d.Id == model.Id));
        }

        public void Update(TelefoneDomain domain)
        {
            var model = ToModel(domain);
            _context.Entry<Telefone>(model).State = EntityState.Modified;
            _context.Telefone.Update(model);
        }

        private Telefone ToModel(TelefoneDomain domain)
        {
            return new Telefone()
            {
                Id = domain.Id,
                Ativo = domain.Ativo,
                IdCliente = domain.IdCliente,
                NumeroTelefone = domain.NumeroTelefone,
                Operadora = domain.Operadora,
                TipoTelefone = domain.TipoTelefone
            };
        }

        private TelefoneDomain ToDomain(Telefone model)
        {
            return new TelefoneDomain(
                    model.Id,
                    model.IdCliente,
                    model.Operadora,
                    model.NumeroTelefone,
                    model.Ativo,
                    (TipoTelefoneEnum)model.TipoTelefone.Id
                );
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }       
    }
}