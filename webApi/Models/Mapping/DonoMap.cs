using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace webApi.Models.Mapping
{
    public class DonoMap : EntityTypeConfiguration<Dono>
    {
        public DonoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_Dono);

            // Properties
            this.Property(t => t.Id_Dono)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CPF)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(11);

            this.Property(t => t.Nome)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(30);

            this.Property(t => t.Telefone)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Dono");
            this.Property(t => t.Id_Dono).HasColumnName("Id_Dono");
            this.Property(t => t.CPF).HasColumnName("CPF");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Id_Acc).HasColumnName("Id_Acc");

            // Relationships
            this.HasRequired(t => t.Conta)
                .WithMany(t => t.Donoes)
                .HasForeignKey(d => d.Id_Acc);

        }
    }
}
