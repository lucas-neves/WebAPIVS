using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApi.Models
{
    public class FavoritoView
    {
        public FavoritoView(Favorito favorito)
        {
            Id_Favorito = favorito.Id_Favorito;
            Id_Quadra = favorito.Id_Quadra;
            Id_Cliente = favorito.Id_Cliente;
			Cliente = new ClienteView(favorito.Cliente);
			Quadra = new QuadraView(favorito.Quadra);
        }
        public int Id_Favorito { get; set; }
		public int Id_Quadra { get; set; }
		public int Id_Cliente { get; set; }
		public virtual ClienteView Cliente { get; set; }
		public virtual QuadraView Quadra { get; set; }
	}
}
