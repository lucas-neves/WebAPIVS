using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace webApi.Models.Mapping
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_End);

            // Properties
            this.Property(t => t.Id_End)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Logradouro)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.Complemento)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.CEP)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Bairro)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            this.Property(t => t.Cidade)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Endereco");
            this.Property(t => t.Id_End).HasColumnName("Id_End");
            this.Property(t => t.Logradouro).HasColumnName("Logradouro");
            this.Property(t => t.Complemento).HasColumnName("Complemento");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.Bairro).HasColumnName("Bairro");
            this.Property(t => t.Cidade).HasColumnName("Cidade");
        }
    }
}
