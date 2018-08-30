using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementSystem.Controllers
{
    public class Books4Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexBook([Bind()]Models.ViewModels.Books4.IndexBook.Route route)
        {
            var i = new Models.ViewModels.Books4.IndexBook.IndexBook(route);

            return View(i);
        }

        public ActionResult IndexShelf()
        {
            var i = new Models.ViewModels.Books4.IndexShelf.IndexShelf();

            return View(i);
        }

        public ActionResult DetailsBook(Guid id)
        {
            var v = new Models.ViewModels.Books4.DetailsBook.DetailsBook(id);

            if (!v._isExist)
                return HttpNotFound();

            return View(v);
        }
    }
}