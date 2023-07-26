using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : ClaseBase
    {

        Task<T> GetByIdAsync(int Id);

        Task<IReadOnlyList<T>> GetAllAsync();

    }
}
