using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Sql.Entity.Helper
{
    public class CinemaContextFactory : IDesignTimeDbContextFactory<CinemaDbContext>
    {
        public CinemaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=CinemaDB; Username=postgres; Password=dbpass11").UseSnakeCaseNamingConvention();

            return new CinemaDbContext(optionsBuilder.Options);
        }
    }
}
