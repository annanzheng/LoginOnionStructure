using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        T getByID(int? id);
        IEnumerable<T> getAll();
        void add(T entity);
        void delete(T entity);
        void update(T entity);
    }
}
