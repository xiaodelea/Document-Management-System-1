using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementSystem.Controllers
{
    public class Books3Controller : Controller
    {
        public ActionResult Index([Bind()]Models.ViewModels.Books3.Index.Route route)
        {
            var v = new Models.ViewModels.Books3.Index.Index(route);

            return View(v);
        }

        public PartialViewResult IndexSub(Guid? parentDocumentId, string titlePart, bool? isChecked, int indent)
        {
            var r = new Models.ViewModels.Books3.Index.Route(parentDocumentId, titlePart, isChecked, 1, int.MaxValue, 0);

            var v = new Models.ViewModels.Books3.Index.Index(r);

            ViewBag.Indent = indent;

            return PartialView(v.List);
        }

        public JsonResult IndexSubJson(Guid? parentDocumentId, string titlePart, bool? isChecked, int indent)
        {
            var r = new Models.ViewModels.Books3.Index.Route(parentDocumentId, titlePart, isChecked, 1, int.MaxValue, 0);

            var v = new Models.ViewModels.Books3.Index.Index(r);

            return Json(v.List);
        }
    }
}