using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories
{

    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository()
        {
        }
        public TagRepository(JustBlogContext context) : base(context)
        {

        }
        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _base.Tags.FirstOrDefault(p => p.UrlSlug == urlSlug);
        }
    }
}
