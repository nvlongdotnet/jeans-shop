using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopOnline.Models.Entity;
using WebShopOnline.Models;

namespace WebShopOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class ContactController : Controller
    {

        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Admin/Contact
        public ActionResult Index()
        {
            var items = _dbContext.Contacts.ToList();
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Contact model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                _dbContext.Contacts.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbContext.Contacts.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                _dbContext.Contacts.Attach(model);
                _dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbContext.Contacts.Find(id);
            if (item != null)
            {
                _dbContext.Contacts.Remove(item);
                _dbContext.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });

        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = _dbContext.Contacts.Find(id);
            if (item != null)
            {
                item.IsRead = !item.IsRead;
                _dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                return Json(new { success = true, isActive = item.IsRead });
            }
            return Json(new { success = false });

        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = _dbContext.Contacts.Find(Convert.ToInt32(item));
                        _dbContext.Contacts.Remove(obj);
                        _dbContext.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}