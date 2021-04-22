
using System;
using System.Collections.Generic;
using System.Linq;

namespace OP.Infrastructure.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable  where T : class 
    {
        bool SaveChange();
        T Add(T Entity);
        bool AddRange(ICollection<T> Entity);

        T AddWithoutSave(T Enitity);
        bool Update(T Entity);
        bool UpdateWithoutSave(T Entity);
     
        T Get(int id);
         T  Get(string id);
        IQueryable<T> GetALl();

    }
}