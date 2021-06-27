using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Models;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private PostRepository data = new PostRepository();

        // GET: Post/Index
        public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            return View(posts);
        }

        public ActionResult LatestPosts()
        {
            var posts = db.Posts.OrderByDescending(p => p.PostedOn).ToList();
            return PartialView("LatestPosts", posts);
        }

        //[Route("Post/released/{year}/{month}/{title}")]
        public ActionResult Details(int year,int month,string title)
        {
            var post = data.Find(year, month, title);
            if (post != null && post.Id > 0)
            {
                ViewBag.Titles = "Test Router";
                return View(post);
            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult MostViews()
        {
            var post = db.Posts.OrderByDescending(p => p.ViewCount).Take(5).ToList();
            if (post == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ListPosts", post);
        }
        [ChildActionOnly]
        public ActionResult LatestViews()
        {
            var post = db.Posts.OrderByDescending(p => p.PostedOn).Take(5).ToList();
            if (post == null)
            {
                return HttpNotFound();
            }
            return PartialView("_LatestPosts", post);
        }
        public ActionResult PopularTags()
        {
            var post = db.Tags.OrderByDescending(p => p.Count).Take(10).ToList();
            if (post == null)
            {
                return HttpNotFound();
            }
            return PartialView("_PopularTags", post);
        }
        public ActionResult AllCategory()
        {
            var posts = db.Categories.ToList();
            return PartialView("_Category", posts);
        }
    }
}