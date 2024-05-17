using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Client.Infrastructure.Data.Models;


namespace Client.Infrastructure.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Bairro).HasMaxLength(200);
            builder.Property(t => t.Cep).HasMaxLength(14);
            builder.Property(t => t.Cidade).HasMaxLength(200);
            builder.Property(t => t.Complemento).HasMaxLength(50);
            builder.Property(t => t.DataInclusao);
            builder.Property(t => t.UsuarioInclusao);
            builder.Property(t => t.Endereco).HasMaxLength(200);
            builder.Property(t => t.NomeFantasia).HasMaxLength(200).IsRequired();
            builder.Property(t => t.RazaoSocial).HasMaxLength(200).IsRequired();
            builder.Property(t => t.TipoPessoa).HasConversion<int>();
            builder.Property(t => t.Uf).HasMaxLength(2);
            
            builder.Property(t => t.Documento).HasMaxLength(15).IsRequired();

            builder.HasMany(t => t.Telefones).WithOne(d => d.Cliente).HasForeignKey(f => f.IdCliente);
        }
    }
}
