using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Sql.Entity.Helper
{
    public static class DbContextExtension
    {
        public static DbContextOptionsBuilder ContextOptionsBuilder (this DbContextOptionsBuilder optionsBuilder, string connString)
        {
            optionsBuilder.UseNpgsql(connString).
                UseSnakeCaseNamingConvention();

            return optionsBuilder;
        }
    }
}
