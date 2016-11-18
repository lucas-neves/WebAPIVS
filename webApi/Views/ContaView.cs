using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class ContaView
    {
        public ContaView(Conta acc)
        {
            Id_Acc = acc.Id_Acc;
            Nr_Acc = acc.Nr_Acc;
            Nr_Ag = acc.Nr_Ag;
            Nr_Bank = acc.Nr_Bank;
        }

		public int Id_Acc { get; set; }
        public string Nr_Acc { get; set; }
        public string Nr_Ag { get; set; }
        public string Nr_Bank { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Dono> Donoes { get; set; }
    }
}
