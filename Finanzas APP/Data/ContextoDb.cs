using Finanzas_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace Finanzas_APP.Data
{
    public class ContextoDb: DbContext
    {
        public ContextoDb() { }

        public ContextoDb(DbContextOptions<ContextoDb> options) : base(options) { }

        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Ingreso> Ingreso { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Gasto> Gasto { get; set; }
    }
}