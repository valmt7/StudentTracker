using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTracker
{
    
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
    }
}