using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopOnline.Models;

namespace WebShopOnline.Controllers
{
    public class ArticalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Artical
        public ActionResult Index(string alias)
        {
            var items = db.Posts.Where(x => x.Alias == alias).OrderByDescending(x => x.CreatedDate).ToList() ;
            return View(items);
        }
    }
}