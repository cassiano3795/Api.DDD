using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.NativeInjetion
{
    public static class ConfigureContext
    {
        public static void RegisterContext(this IServiceCollection serviceDescriptors, IConfiguration configuration){
            serviceDescriptors.AddDbContext<ApiContext>(op => op.UseMySql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
