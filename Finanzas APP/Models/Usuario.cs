using System.ComponentModel.DataAnnotations;

namespace Finanzas_APP.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public float SaldoInicial { get; set; }
    }
}
