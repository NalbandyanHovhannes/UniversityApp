using Microsoft.EntityFrameworkCore;
using UniversityApp.Models;

namespace UniversityApp.DbConnection
{
    public class Context :DbContext
    {
        public DbSet<RegisterRequest> Users { get; set; }
        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=University;Trusted_Connection=True;");
        }
    }
}
