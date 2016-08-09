using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ElectricityProject.Repository.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected DbContext context;
        protected readonly IDbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Delete(T obj)
        {
            dbSet.Remove(obj);
            context.SaveChanges();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate.Compile());
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public void AddOrUpdate(T obj)
        {
            dbSet.AddOrUpdate(obj);
            context.SaveChanges();
        }
    }

}
