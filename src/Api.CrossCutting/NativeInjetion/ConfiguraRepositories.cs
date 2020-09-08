using Api.Data.Repository;
using Api.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.NativeInjetion
{
    public static class ConfiguraRepositories
    {
        public static void RegisterRepositories(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceDescriptors.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
