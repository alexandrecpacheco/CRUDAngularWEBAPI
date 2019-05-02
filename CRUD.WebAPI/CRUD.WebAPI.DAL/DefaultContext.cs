using CRUD.WebAPI.Entities;
using System.Data.Entity;

namespace CRUD.WebAPI.DAL
{
    /// <summary>
    /// Class responsable to access the database
    /// </summary>
    public class DefaultContext : DbContext
    {
        public DefaultContext()
            : base("name=DefaultContext")
        {
        }
        public DbSet<Customers> Clientes { get; set; }
        public DbSet<Professions> Profissoes { get; set; }
    }
}
