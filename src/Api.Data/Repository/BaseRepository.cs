using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repositories;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApiContext _apiContext;
        private DbSet<T> _dataSet;

        public BaseRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
            _dataSet = apiContext.Set<T>();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var itemDb = await SelectAsync(id);
                if (itemDb == null)
                    return false;

                _dataSet.Remove(itemDb);
                await _apiContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var itemDb = await _dataSet.FindAsync(id);
                return itemDb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try
            {
                var itensDb = await _dataSet.ToListAsync();
                return itensDb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                item.CreatedAt = DateTime.UtcNow;

                _dataSet.Add(item);
                await _apiContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var itemDb = await SelectAsync(item.Id);

                if (itemDb == null)
                    return null;

                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = itemDb.CreatedAt;

                _apiContext.Entry(itemDb).CurrentValues.SetValues(item);
                // itemDb = item;
                await _apiContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
