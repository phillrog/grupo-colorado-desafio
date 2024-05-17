using Client.Domain.Interfaces;
using Client.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Client.Infrastructure.Data.Context
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as Entity;

                if (entity == null) continue;

                if (entry.State == EntityState.Added)
                {
                    entity.DataInclusao = DateTime.Now;
                    entity.UsuarioInclusao = 0; // sistema
                    continue;
                }

                Entry(entity).Property(x => x.DataInclusao).IsModified = false;
                Entry(entity).Property(x => x.UsuarioInclusao).IsModified = false;
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
