using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Services
{
    public class UserService : BaseService<UserEntity>, IUserService
    {
        public UserService(IRepository<UserEntity> baseRepository) : base(baseRepository)
        {
        }
    }
}
