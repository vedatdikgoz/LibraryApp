using LibraryApp.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Concrete.EntityFramework
{
  
        public class EfEntityRepositoryBase<T, TContext> : IEntityRepository<T>
        where T : class, new()
        where TContext : DbContext, new()

        {
            public void Create(T entity)
            {
                using var context = new TContext();
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }

            public void Delete(T entity)
            {
                using var context = new TContext();
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }

            public List<T> GetAll()
            {
                using var context = new TContext();
                return context.Set<T>().ToList();

            }

            public T GetById(int id)
            {
                using var context = new TContext();
                return context.Set<T>().Find(id);
            }

            public virtual void Update(T entity)
            {
                using var context = new TContext();
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
}
