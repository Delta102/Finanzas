using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finanzas_APP.Models
{
    public class Gasto
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaGasto { get; set; }
        public string Descripcion { get; set; }
        public float Monto { get; set; }
        public int IdCuenta { get; set; }

        [ForeignKey("IdCuenta")]
        public virtual Cuenta? Cuenta { get; set; }
    }
}