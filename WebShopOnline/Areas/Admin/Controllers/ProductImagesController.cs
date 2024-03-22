using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopOnline.Models;
using WebShopOnline.Models.Entity;

namespace WebShopOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class ProductImagesController : Controller
    {
        // GET: Admin/ProductImages
        ApplicationDbContext _dbContext = new ApplicationDbContext();
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = _dbContext.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            _dbContext.ProductImages.Add(new ProductImage
            {
                   ProductId = productId,
                   Image = url,
                   IsDefault = false
            });
            _dbContext.SaveChanges();
            return Json(new { success = true});
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbContext.ProductImages.Find(id);
            _dbContext.ProductImages.Remove(item);
            _dbContext.SaveChanges();
            return Json(new { success = true});
        }

        //[HttpPost]
        //public ActionResult IsDefault(int id)
        //{
        //    var item = _dbContext.ProductImages.Find(id);
        //    if (item != null)
        //    {
        //        item.IsDefault = !item.IsDefault;
        //        _dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        //        _dbContext.SaveChanges();
        //        return Json(new { success = true, isDefault = item.IsDefault });
        //    }
        //    return Json(new { success = false });

        //}
    }
}