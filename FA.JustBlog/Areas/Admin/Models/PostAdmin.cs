using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Areas.Admin.Models
{
    public class PostAdmin
    {
        JustBlogContext db = null;
        public PostAdmin ()
        {
            db = new JustBlogContext();
        }
        public long Insert (Post entity)
        {
            db.Posts.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
    }
}