using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace webApi.Models.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_Cliente);

            // Properties
            this.Property(t => t.Id_Cliente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Username)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Senha)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(15);

            this.Property(t => t.Email)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.Telefone)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Cliente");
            this.Property(t => t.Id_Cliente).HasColumnName("Id_Cliente");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Senha).HasColumnName("Senha");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Id_Acc).HasColumnName("Id_Acc");
            this.Property(t => t.Id_End).HasColumnName("Id_End");
            this.Property(t => t.Telefone).HasColumnName("Telefone");

            // Relationships
            this.HasRequired(t => t.Conta)
                .WithMany(t => t.Clientes)
                .HasForeignKey(d => d.Id_Acc);
            this.HasRequired(t => t.Endereco)
                .WithMany(t => t.Clientes)
                .HasForeignKey(d => d.Id_End);

        }
    }
}
