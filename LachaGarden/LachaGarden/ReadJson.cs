using DataAccessLayer.Models;
using System.Diagnostics.Metrics;

namespace LachaGarden
{
    public static class ReadJson
    {
        public static IConfiguration Configuration;

        public static Customer GetAdmin()
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, true).Build();
            var adminDefault = config.GetSection("AdminAccount").Get<Customer>();
            return adminDefault;
        }

    }
}
