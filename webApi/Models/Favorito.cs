using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class Favorito
    {
		[Key]
        public int Id_Favorito { get; set; }
        public int Id_Quadra { get; set; }
        public int Id_Cliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Quadra Quadra { get; set; }
    }
}
