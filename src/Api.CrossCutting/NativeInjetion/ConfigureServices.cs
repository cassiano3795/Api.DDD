using Api.Data.Repository;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.NativeInjetion
{
    public static class ConfigureServices
    {
        public static void AddServices(this IServiceCollection serviceDescriptors)
        {
            // Services
            serviceDescriptors.AddScoped<IUserService, UserService>();
            serviceDescriptors.AddScoped<ILoginService, LoginService>();
        }
    }
}
