using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository()
        {
        }

        public CategoryRepository(JustBlogContext context) : base(context)
        {

        }

    }
}
