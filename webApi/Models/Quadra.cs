using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class Quadra
    {
        public Quadra()
        {
            this.Aluguels = new List<Aluguel>();
            this.Favoritos = new List<Favorito>();
        }

		[Key]
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
        public virtual ICollection<Aluguel> Aluguels { get; set; }
        public virtual Dono Dono { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Favorito> Favoritos { get; set; }
    }
}
