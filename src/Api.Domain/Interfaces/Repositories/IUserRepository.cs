using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;

namespace Api.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin (string email);
    }
}
