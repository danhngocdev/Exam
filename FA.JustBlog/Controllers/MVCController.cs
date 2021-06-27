using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class MVCController : Controller
    {
        // GET: MVC
        private JustBlogContext db = new JustBlogContext();
        public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            return View(posts);
        }
    }
}