using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class EntityController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        // GET: Entity
        public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            return View(posts);
        }
        public ActionResult Entity()
        {
            var posts = db.Posts.ToList();
            return View(posts);
        }
    }
}