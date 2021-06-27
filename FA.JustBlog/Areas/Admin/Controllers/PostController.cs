using FA.JustBlog.Areas.Admin.Models;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.DTO;
using System.Net;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        JustBlogContext db = new JustBlogContext();
        PostRepository postrepo = new PostRepository();

        // GET: Admin/Post/Create
        public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            return View(posts);
        }

        public ActionResult Create()
        {
            return View();
        }



        //[Route("Details/{id}")]
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

        [ChildActionOnly]
        public ActionResult LatestViews()
        {
            var posts = db.Posts.OrderByDescending(p => p.PostedOn).Take(5).ToList();
            if (posts == null)
            {
                return HttpNotFound();
            }
            return PartialView("_LatestPosts", posts);
        }

        [ChildActionOnly]
        public ActionResult MostViewedPosts()
        {
            var posts = db.Posts.OrderByDescending(p => p.ViewCount).Take(5).ToList();
            if (posts == null)
            {
                return HttpNotFound();
            }
            return PartialView("_MostViewedPosts", posts);
        }



        [ChildActionOnly]
        public ActionResult MostInterestingPosts()
        {
            //var listPost = new List<Post>();
            var posts = postrepo.GetHighestPost(3);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return PartialView("_MostInterestingPosts", posts);
        }

        [ChildActionOnly]
        public ActionResult PublishedPosts()
        {
            var posts = db.Posts.Where(p => p.Published <= DateTime.Now).ToList();
            if (posts == null)
            {
                return HttpNotFound();
            }
            return PartialView("_PublishedPosts", posts);
        }

        [ChildActionOnly]
        public ActionResult UnpublishedPosts()
        {
            var posts = db.Posts.Where(p => p.Published > DateTime.Now).ToList();
            if (posts == null)
            {
                return HttpNotFound();
            }
            return PartialView("_UnpublishedPosts", posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post p)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(p);
                db.SaveChanges();
                ModelState.Clear();
                //p = null;
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var post = db.Posts.Where(x => x.Id == id).FirstOrDefault();
            return View(post);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                if(post.Id > 0)
                {
                    var p = db.Posts.Where(x => x.Id == post.Id).FirstOrDefault();
                    if(p != null)
                    {
                        p.Title = post.Title;
                        p.ShortDescription = post.ShortDescription;
                        p.PostContent = post.PostContent;
                        p.Meta = post.Meta;
                        p.UrlSlug = post.UrlSlug;
                        //p.Published = post.Published;
                        //p.PostedOn = post.PostedOn;
                        //p.Modified = post.Modified;
                        //p.CategoryId = post.CategoryId;
                        //p.ViewCount = post.ViewCount;
                        //p.RateCount = post.RateCount;
                        //p.TotalRate = post.TotalRate;
                    }
                }
                else
                {
                    return Content("No data found!");
                }
                db.SaveChanges();
            }
            return View(post);
        }

        public ActionResult Delete(int id)
        {
            var del = db.Posts.Where(x => x.Id == id).FirstOrDefault();
            if (del!= null && del.Id > 0)
            {
                db.Posts.Remove(del);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}