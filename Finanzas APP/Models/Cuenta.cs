using System.ComponentModel.DataAnnotations;

namespace Finanzas_APP.Models
{
    public class Cuenta
    {
        [Key]
        public int IdCuenta { get; set; }
        public string Nombre { get; set; }
        public float SaldoInicial { get; set; }
    }
}