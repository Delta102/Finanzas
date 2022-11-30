using System.ComponentModel.DataAnnotations;

namespace Finanzas_APP.Models
{
    public class Ingreso
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Descripcion { get; set; }
        public float Monto { get; set; }
    }
}