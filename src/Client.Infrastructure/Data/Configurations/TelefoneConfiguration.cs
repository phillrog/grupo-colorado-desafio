using Client.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Client.Infrastructure.Data.Configurations
{
    internal class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable(nameof(Telefone));
            builder.HasKey(e => e.Id);
            builder.Property(t => t.Ativo);
            builder.Property(t => t.NumeroTelefone).HasMaxLength(12);
            builder.Property(t => t.Operadora).HasMaxLength(3);
            builder.Property(t => t.IdCliente);
            builder.OwnsOne(t => t.TipoTelefone);

            builder.HasOne(d => d.Cliente).WithMany(c => c.Telefones).HasForeignKey(d => d.IdCliente);
        }
    }
}
