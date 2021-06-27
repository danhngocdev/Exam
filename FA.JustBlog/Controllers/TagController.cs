using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class TagController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private TagRepository data = new TagRepository();
        // GET: Tag
        public ActionResult Index()
        {
            var tags = data.GetAll();
            return View(tags);
        }


        [Route("Tag/{tag}")]
        public ActionResult PopularTags(string tag)
        {
            var tags = data.GetTagByUrlSlug(tag);
            if (tags != null )
            {
                return View(tags);
            }
            return View();
         
        }
    }
}