using webapp_travel_agency.Models;
using Microsoft.EntityFrameworkCore;

namespace webapp_travel_agency.Data
{
    public class BlogContext : DbContext
    {

        public DbSet<Viaggio> Viaggi { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=localhost;Database=webapp_travel_agency;Integrated Security=True");
        }
    }

}
