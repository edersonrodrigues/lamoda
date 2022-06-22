using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rgm.Domain.Entities.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<bool> Delete(int Id);
    }
}
