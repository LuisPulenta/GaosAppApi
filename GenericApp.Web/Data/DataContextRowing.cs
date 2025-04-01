using GenericApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericApp.Web.Data
{
    public class DataContextRowing : DbContext
    {
        public DataContextRowing(DbContextOptions<DataContextRowing> options) : base(options)
        {
        }
        public DbSet<Usuario2> Usuarios { get; set; }
    }
}