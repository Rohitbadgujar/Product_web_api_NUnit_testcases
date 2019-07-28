using Microsoft.EntityFrameworkCore;
using WebApi_assignment.Model;

namespace ApplicationWebApi.Models
{
    public class ApidbContext : DbContext
    {
        public ApidbContext(DbContextOptions<ApidbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> ProductItems { get; set; }
        //public DbSet<SalesRepModel> SalesList { get; set; }

    }
}