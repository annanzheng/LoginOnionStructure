using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Interfaces;


namespace RepoLayer.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly DbContext _context;

        public GenericRepo(DbContext context)
        {
            _context = context;
        }

        public T getByID(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> getAll()
        {
            return _context.Set<T>().ToList();
        }

        public void add(T entity)
        {
            _context.Set<T>().Add(entity);
           
        }

        public void delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }





    }
}
