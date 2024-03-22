using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopOnline.Models;

namespace WebShopOnline.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(int? id)
        {
            var items = _dbContext.Products.ToList();
            if(id != null)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToList();
            }
            var cate = _dbContext.ProductCategories.Find(id);
            if(cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult Detail(string alias, int id)
        {
            var item = _dbContext.Products.Find(id);
            if(item != null)
            {
                _dbContext.Products.Attach(item);
                item.CountView = item.CountView + 1;
                _dbContext.Entry(item).Property(x=>x.CountView).IsModified = true;
                _dbContext.SaveChanges();
            }
            return View(item);
        }

        public ActionResult Partial_ItemsByCateId()
        {
            var items = _dbContext.Products.Where(x => x.IsHome && x.IsActive).Take(15).ToList();
            return PartialView(items);
        }

        public ActionResult Partial_ItemsBySales()
        {
            var items = _dbContext.Products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
    }
}