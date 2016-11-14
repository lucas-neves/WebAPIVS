using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class Conta
    {
        public Conta()
        {
            this.Clientes = new List<Cliente>();
            this.Donoes = new List<Dono>();
        }

		[Key]
        public int Id_Acc { get; set; }
        public string Nr_Acc { get; set; }
        public string Nr_Ag { get; set; }
        public string Nr_Bank { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Dono> Donoes { get; set; }
    }
}
