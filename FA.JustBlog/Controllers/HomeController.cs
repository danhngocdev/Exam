using FA.JustBlog.Core.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using FA.JustBlog.Core.Repositories;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private PostRepository data = new PostRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            return View(posts);
        }

        [Route("Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Single(x => x.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        //public ActionResult Details(int year, int month, string title)
        //{
        //    var post = data.Find(year, month, title);
        //    if (post != null && post.Id > 0)
        //    {
        //        ViewBag.Titles = "Test Router";
        //        return View(post);
        //    }
        //    return View();
        //}


        [ChildActionOnly]
        public ActionResult AboutCard()
        {
            return PartialView("_PatialAboutCard");
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
            return PartialView("_LatestPosts",post);
        }
        [ChildActionOnly]
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
