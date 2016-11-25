using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class AluguelView
    {
		public AluguelView(Aluguel aluguel)
        {
            Id_Aluguel = aluguel.Id_Aluguel;
            DataJogo = aluguel.DataJogo;
            Hora = aluguel.Hora;
            Confirm = aluguel.Confirm;
            Id_Quadra = aluguel.Id_Quadra;
            Id_Cliente = aluguel.Id_Cliente;
            Cliente = new ClienteView(aluguel.Cliente);
            Quadra = new QuadraView(aluguel.Quadra);
        }
        public int Id_Aluguel { get; set; }
        public System.DateTime DataJogo { get; set; }
        public System.TimeSpan Hora { get; set; }
        public Nullable<bool> Confirm { get; set; }
        public int Id_Quadra { get; set; }
        public int Id_Cliente { get; set; }
        public virtual ClienteView Cliente { get; set; }
        public virtual QuadraView Quadra { get; set; }
    }
}
