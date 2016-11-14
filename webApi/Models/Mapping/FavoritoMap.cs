using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace webApi.Models.Mapping
{
    public class FavoritoMap : EntityTypeConfiguration<Favorito>
    {
        public FavoritoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_Favorito);

            // Properties
            this.Property(t => t.Id_Favorito)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Favoritos");
            this.Property(t => t.Id_Favorito).HasColumnName("Id_Favorito");
            this.Property(t => t.Id_Quadra).HasColumnName("Id_Quadra");
            this.Property(t => t.Id_Cliente).HasColumnName("Id_Cliente");

            // Relationships
            this.HasRequired(t => t.Cliente)
                .WithMany(t => t.Favoritos)
                .HasForeignKey(d => d.Id_Cliente);
            this.HasRequired(t => t.Quadra)
                .WithMany(t => t.Favoritos)
                .HasForeignKey(d => d.Id_Quadra);

        }
    }
}
