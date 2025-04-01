using Microsoft.EntityFrameworkCore;

public class RetailContext : RContext
{
     public RetailContext(DbContextOptions<RetailContext> options) : base(options)
    {
    }
}