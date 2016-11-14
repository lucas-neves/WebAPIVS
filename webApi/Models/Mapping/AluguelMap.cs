using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace webApi.Models.Mapping
{
    public class AluguelMap : EntityTypeConfiguration<Aluguel>
    {
        public AluguelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_Aluguel);

            // Properties
            this.Property(t => t.Id_Aluguel)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Aluguel");
            this.Property(t => t.Id_Aluguel).HasColumnName("Id_Aluguel");
            this.Property(t => t.DataJogo).HasColumnName("DataJogo");
            this.Property(t => t.Hora).HasColumnName("Hora");
            this.Property(t => t.Confirm).HasColumnName("Confirm");
            this.Property(t => t.Id_Quadra).HasColumnName("Id_Quadra");
            this.Property(t => t.Id_Cliente).HasColumnName("Id_Cliente");

            // Relationships
            this.HasRequired(t => t.Cliente)
                .WithMany(t => t.Aluguels)
                .HasForeignKey(d => d.Id_Cliente);
            this.HasRequired(t => t.Quadra)
                .WithMany(t => t.Aluguels)
                .HasForeignKey(d => d.Id_Quadra);

        }
    }
}
