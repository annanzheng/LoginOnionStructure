using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Interfaces;

namespace RepoLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentContext _context;

        public IStudentRepo StudentRepo { get; }

        public UnitOfWork(StudentContext context)
        {
            _context = context;
            StudentRepo = new StudentRepo(_context);
        }

        public int complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
