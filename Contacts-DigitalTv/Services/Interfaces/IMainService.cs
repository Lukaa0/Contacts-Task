using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_DigitalTv.Services.Interfaces
{
    public interface IMainService<T> where T : class
    {
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task UpdateAsync(T entity);
        public  Task DeleteAsync(T entity);
        public Task CreateAsync(T entity);

    }
}
