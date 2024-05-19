using Client.Domain.Interfaces;
using Client.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Client.Infrastructure.Data.Context
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.Entity is IEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IEntity;

                if (entity == null) continue;

                if (entry.State == EntityState.Added)
                {
                    entity.DataInclusao = DateTime.Now;
                    entity.UsuarioInclusao = 1; // admin
                    continue;
                }

                Entry(entity).Property(x => x.DataInclusao).IsModified = false;
                Entry(entity).Property(x => x.UsuarioInclusao).IsModified = false;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine);
    }
}
