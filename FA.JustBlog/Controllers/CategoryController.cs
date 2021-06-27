using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        // GET: Category
        public ActionResult Index()
        {
            var cate = db.Categories.ToList();
            return View(cate);
        }

        [Route("Category/{name}")]
        public ActionResult Category(string name)
        {
            var cate = db.Categories.FirstOrDefault(x => x.Name == name) ;
            if (cate !=null && cate.Id > 0)
            {
                return View(cate);
            }
            return View("Error");
        }
    }
}