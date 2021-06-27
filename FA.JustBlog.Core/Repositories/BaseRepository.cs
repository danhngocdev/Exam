using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly JustBlogContext _base = null;
        public readonly DbSet<T> db = null;
        public BaseRepository()
        {
            _base = new JustBlogContext();
            db = _base.Set<T>();
        }
        public BaseRepository(JustBlogContext context)
        {
            _base = context;
            db = _base.Set<T>();
        }
        public void Add(T item)
        {
            db.Add(item);
        }

        public void Delete(T item)
        {
            db.Remove(item);
        }

        public void Delete(int id)
        {
            var result = db.Find(id);
            db.Remove(result);
        }

        public T Find(int id)
        {
            return db.Find(id);
        }

        public IList<T> GetAll()
        {
            return db.ToList();
        }

        public void Save()
        {
            _base.SaveChanges();
        }

        public void Update(T item)
        {
            _base.Entry(item).State = EntityState.Modified;
        }

        // Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _base.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
