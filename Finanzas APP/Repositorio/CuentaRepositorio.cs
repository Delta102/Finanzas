using Finanzas_APP.Data;
using Finanzas_APP.Models;

namespace Finanzas_APP.Repositorio
{
    public interface ICuentaRepositorio
    {
        void CrearCuenta(Cuenta cuenta);
        int CantidadCuenta();
    }

    public class CuentaRepositorio: ICuentaRepositorio {

        public readonly ContextoDb _context;

        public CuentaRepositorio(ContextoDb context) {
            _context = context;
        }

        public void CrearCuenta(Cuenta cuenta)
        {
            _context.Add(cuenta);
            _context.SaveChanges();
        }

        public int CantidadCuenta() {
            return _context.Cuenta.Count();   // SELECT COUNT(*) FROM CUENTA
        }
    }
}
