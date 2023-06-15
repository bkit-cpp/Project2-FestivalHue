using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.EF
{
    public class FestivalHueDbContextFactory:IDesignTimeDbContextFactory<FestivalHueDbContext>
    {
        public FestivalHueDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("FestivalHueDb");
            var optionsBuilder = new DbContextOptionsBuilder<FestivalHueDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FestivalHueDbContext(optionsBuilder.Options);
        }
    }
}
