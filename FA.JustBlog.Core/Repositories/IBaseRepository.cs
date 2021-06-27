using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(int id);
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        IList<T> GetAll();
        void Save();
        void Dispose();
    }
}
