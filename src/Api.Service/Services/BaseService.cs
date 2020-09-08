using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;
using Api.Domain.Interfaces.Services;

namespace Api.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _baseRepository;

        public BaseService(IRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            return await _baseRepository.SelectAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _baseRepository.SelectAllAsync();
        }

        public virtual async Task<T> PostAsync(T item)
        {
            return await _baseRepository.InsertAsync(item);
        }

        public virtual async Task<T> PutAsync(T item)
        {
            return await _baseRepository.UpdateAsync(item);
        }
    }
}
