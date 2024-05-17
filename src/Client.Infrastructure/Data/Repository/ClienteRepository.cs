using Client.Domain.Interfaces;
using Client.Domain.Entities;
using Client.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Client.Infrastructure.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _context;
        public ClienteRepository(ClienteDbContext clienteDbContext)
        {
            _context = clienteDbContext;
        }

        public void Add(Cliente domain)
        {
            _context.Cliente.Add(domain);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Cliente.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Cliente.FirstAsync(x => x.Id == id);
        }

        public void Remove(Cliente domain)
        {
            _context.Cliente.Remove(domain);
        }

        public void Update(Cliente domain)
        {
            _context.Cliente.Update(domain);
        }
    }
}
