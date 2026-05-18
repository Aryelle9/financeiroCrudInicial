using System.ComponentModel.DataAnnotations;

namespace PrjFinanceiro.Models
{
    public class Cargo
    {
        [Key]
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public string Abreviacao { get; set; }

        
    }
}
