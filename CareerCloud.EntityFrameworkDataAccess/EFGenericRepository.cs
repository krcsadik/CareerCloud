using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.Entity;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository <T>: IDataRepository<T> where T : class
    {
        private readonly  CareerCloudContext _context;
        public EFGenericRepository(bool proxyEnabled = true)
        {
            _context = new CareerCloudContext(proxyEnabled);
        }
        public void Add(params T[] items)
        {
            foreach (T obj in items)
            {
                _context.Entry(obj).State = EntityState.Added;
            }
            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (var navprop in navigationProperties)
            {
                queryable = queryable.Include<T, object>(navprop);

            }
            return queryable.ToList<T>();
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (var navprop in navigationProperties)
            {
                queryable = queryable.Include<T, object>(navprop);

            }
            return queryable.Where (where).ToList<T>();
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (Expression<Func<T, object>> navprop in navigationProperties)
            {
                queryable = queryable.Include<T, object>(navprop);

            }
            return queryable.FirstOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            foreach (T obj in items)
            {
                _context.Entry(obj).State = EntityState.Deleted;
            }
            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T obj in items)
            {
                _context.Entry(obj).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
