using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        /// <summary>
        /// Used for migrations
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Returns a valid DbContext.</returns>
        public ApiContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=ZxC@753!";
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseMySql(connectionString);
            return new ApiContext(optionsBuilder.Options);
        }
    }
}
