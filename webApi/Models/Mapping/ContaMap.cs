using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace webApi.Models.Mapping
{
    public class ContaMap : EntityTypeConfiguration<Conta>
    {
        public ContaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_Acc);

            // Properties
            this.Property(t => t.Id_Acc)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Nr_Acc)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Nr_Ag)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Nr_Bank)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Conta");
            this.Property(t => t.Id_Acc).HasColumnName("Id_Acc");
            this.Property(t => t.Nr_Acc).HasColumnName("Nr_Acc");
            this.Property(t => t.Nr_Ag).HasColumnName("Nr_Ag");
            this.Property(t => t.Nr_Bank).HasColumnName("Nr_Bank");
        }
    }
}
