using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataSet;
        public UserRepository(ApiContext apiContext) : base(apiContext)
        {
            _dataSet = apiContext.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            try
            {
                return await _dataSet.FirstOrDefaultAsync(u => u.Email.Equals(email));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
