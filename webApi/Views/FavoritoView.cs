using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApi.Models
{
    public partial class FavoritoView
    {
        public FavoritoView(Favorito favorito)
        {
            Id_Favorito = favorito.Id_Favorito;
            Id_Quadra = favorito.Id_Quadra;
            Id_Cliente = favorito.Id_Cliente;
            this.Quadra = new List<Quadra>();
            Descricao = favorito.Quadra.Descricao;
            Image_Path = favorito.Quadra.Image_Path;
        }

        [Key]
		public int Id_Favorito { get; set; }
		public int Id_Quadra { get; set; }
		public int Id_Cliente { get; set; }
        public virtual ICollection<Quadra> Quadra { get; set; }
        public string Descricao { get; set; }
        public string Image_Path { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
