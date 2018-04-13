using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            var targetV = new Models.ViewModels.Books.Index.Index();

            return View(targetV);
        }

        public ActionResult Details(Guid id)
        {
            var targetV = new Models.ViewModels.Books.Details.Details(id);

            return View(targetV);
        }

        public PartialViewResult Directory(Guid id)
        {
            var targetV = new Models.ViewModels.Books.Directory.Directory(id);

            return PartialView(targetV);
        }

        public PartialViewResult Children(Guid id)
        {
            var targetV = new Models.ViewModels.Books.Children.Children(id);

            return PartialView(targetV);
        }

        public ActionResult Create(Guid? parentDocumentId)
        {
            var targetV = new Models.ViewModels.Books.Create.Create(parentDocumentId);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind()]Models.ViewModels.Books.Create.Create targetV)
        {
            if (ModelState.IsValid)
            {
                var target = targetV.GetTarget();

                var result = targetV.Save(target);

                if (result)
                    return RedirectToAction("Details", new { id = target.DocumentId });
                else
                    return HttpNotFound();
            }

            return View(targetV);
        }

        public ActionResult Edit(Guid id)
        {
            var targetV = new Models.ViewModels.Books.Edit.Edit(id);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind()]Models.ViewModels.Books.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var result = targetV.Save();

                if (result)
                    return RedirectToAction("Details", new { id = targetV.DocumentId });
                else
                    return HttpNotFound();
            }

            return View(targetV);
        }
    }
}