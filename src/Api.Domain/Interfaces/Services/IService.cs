using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> PostAsync(T item);
        Task<T> PutAsync(T item);
        Task<bool> DeleteAsync(Guid id);
    }
}
