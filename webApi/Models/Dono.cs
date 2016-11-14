using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class Dono
    {
        public Dono()
        {
            this.Quadras = new List<Quadra>();
        }

		[Key]
        public int Id_Dono { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Id_Acc { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual ICollection<Quadra> Quadras { get; set; }
    }
}
