using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : ClaseBase
    {

        Task<T> Get(int Id);

        Task<IReadOnlyList<T>> List();

        Task<T> GetEntity(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListEntity(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);

    }
}
