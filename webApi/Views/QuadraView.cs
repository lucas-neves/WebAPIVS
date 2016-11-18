using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApi.Models
{
	class QuadraView
	{
		public QuadraView(Quadra quadra)
		{
            Id_Quadra = quadra.Id_Quadra;
            Id_Dono = quadra.Id_Dono;
			Id_End = quadra.Id_End;
            CoordernateOne = quadra.CoordernateOne;
            CoordernateTwo = quadra.CoordernateTwo;
            Opcionais = quadra.Opcionais;
            Tipo_Quadra = quadra.Tipo_Quadra;
            Valor_Quadra = quadra.Valor_Quadra;
            Descricao = quadra.Descricao;
            Image_Path = quadra.Image_Path;						
		}
		public int Id_Quadra { get; set; }
		public int Id_Dono { get; set; }
		public int Id_End { get; set; }
		public string CoordernateOne { get; set; }
		public string CoordernateTwo { get; set; }
		public string Opcionais { get; set; }
		public string Tipo_Quadra { get; set; }
		public double Valor_Quadra { get; set; }
		public string Descricao { get; set; }
		public string Image_Path { get; set; }
        public virtual Dono Dono { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
