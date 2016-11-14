using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using webApi.Models.Mapping;

namespace webApi.Models
{
    public partial class JogaJuntoDBContext : DbContext
    {
        static JogaJuntoDBContext()
        {
            Database.SetInitializer<JogaJuntoDBContext>(null);
        }

        public JogaJuntoDBContext()
            : base("Name=JogaJuntoDBContext")
        {
        }

        public DbSet<Aluguel> Aluguels { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Dono> Donoes { get; set; }
        public DbSet<Endereco> Enderecoes { get; set; }
        public DbSet<Favorito> Favoritoes { get; set; }
        public DbSet<Quadra> Quadras { get; set; }
        public DbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AluguelMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new ContaMap());
            modelBuilder.Configurations.Add(new DonoMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new FavoritoMap());
            modelBuilder.Configurations.Add(new QuadraMap());
            modelBuilder.Configurations.Add(new database_firewall_rulesMap());
        }
    }
}
