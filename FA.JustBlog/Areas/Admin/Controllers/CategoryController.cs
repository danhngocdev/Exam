using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {

        JustBlogContext db = new JustBlogContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(data);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(c);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]

        public ActionResult Edit(int Id)
        {
            var obj = db.Categories.Where(x => x.Id == Id).FirstOrDefault();
            return View(obj);
        }


        [HttpPost]
       
        public ActionResult Edit(Category p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int Id)
        {
            var cate = db.Categories.Where(x => x.Id == Id).FirstOrDefault();
            db.Categories.Remove(cate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}