using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class DonoView
    {
        public DonoView(Dono dono)
        {
            Id_Dono = dono.Id_Dono;
            CPF = dono.CPF;
            Nome = dono.Nome;
            Telefone = dono.Telefone;
            Id_Acc = dono.Id_Acc;
            Conta = dono.Conta;
        }

		public int Id_Dono { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Id_Acc { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual ICollection<Quadra> Quadras { get; set; }
    }
}
