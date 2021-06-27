using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {

        JustBlogContext db = new JustBlogContext();
        // GET: Admin/Comment
        public ActionResult Index()
        {
            var comment = db.Comments.ToList();
            return View(comment);
        }
    }
}