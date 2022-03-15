using System;
using System.ComponentModel.DataAnnotations;

namespace APICliente.Models
{
    public partial class VendasCliente
    {
        public int IdVenda { get; set; }
        public int CodigoCliente { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DataVenda { get; set; }
        public double ValorVenda { get; set; }
    }
}
