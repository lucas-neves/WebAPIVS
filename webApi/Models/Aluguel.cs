using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class Aluguel
    {
        public Aluguel()
        {
            
        }

        [Key]
        public int Id_Aluguel { get; set; }
        public System.DateTime DataJogo { get; set; }
        public System.TimeSpan Hora { get; set; }
        public Nullable<bool> Confirm { get; set; }
        public int Id_Quadra { get; set; }
        public int Id_Cliente { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Quadra Quadra { get; set; }
    }
}
