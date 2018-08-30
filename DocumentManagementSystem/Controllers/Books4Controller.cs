using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementSystem.Controllers
{
    public class Books4Controller : Controller
    {
        public ActionResult IndexBook([Bind()]Models.ViewModels.Books4.IndexBook.Route route)
        {
            var i = new Models.ViewModels.Books4.IndexBook.IndexBook(route);

            return View(i);
        }
    }
}