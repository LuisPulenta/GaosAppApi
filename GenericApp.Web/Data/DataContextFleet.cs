using GenericApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericApp.Web.Data
{
    public class DataContextFleet : DbContext
    {
        public DataContextFleet(DbContextOptions<DataContextFleet> options) : base(options)
        {
        }
        public DbSet<Usuario2> Usuarios { get; set; }
    }
}