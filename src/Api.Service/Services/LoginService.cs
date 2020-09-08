using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<object> FindByLogin(UserEntity userEntity)
        {
            var baseUser = new UserEntity();
            if (userEntity != null && !string.IsNullOrWhiteSpace(userEntity.Email))
            {
                return await _userRepository.FindByLogin(userEntity.Email);
            }
            
            return null;
        }
    }
}
