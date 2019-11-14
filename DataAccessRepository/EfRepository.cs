using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepository
{
    public class EfRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext _context;
        

        public EfRepository(DbContext context)
        {

            _context = context;
        }

       

        public IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>();
            }
        }

       
        protected IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).AsQueryable();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
           
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
    }
}
