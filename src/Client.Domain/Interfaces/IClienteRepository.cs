using Client.Domain.Common;
using Client.Domain.Entities;

namespace Client.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<ClienteDomain>
    {
        Task<ClienteDomain> GetByIdAsNoTracking(int id);
    }
}
