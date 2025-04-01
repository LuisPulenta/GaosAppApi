using GenericApp.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class RContext : DbContext
{
    public RContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Usuario2> Usuarios { get; set; }
}