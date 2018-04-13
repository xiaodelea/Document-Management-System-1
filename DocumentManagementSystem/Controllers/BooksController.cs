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





        public ActionResult CreateBookNormal(Guid? parentDocumentId)
        {
            var targetV = new Models.ViewModels.Books.Create.Create(parentDocumentId);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBookNormal([Bind()]Models.ViewModels.Books.Create.Create targetV)
        {
            if (ModelState.IsValid)
            {
                var target = targetV.GetTargetBookNormal();

                var result = targetV.Save(target);

                if (result)
                    return RedirectToAction("Details", new { id = target.DocumentId });
                else
                    return HttpNotFound();
            }

            return View(targetV);
        }

        public ActionResult CreateBookMain(Guid? parentDocumentId)
        {
            var targetV = new Models.ViewModels.Books.Create.Create(parentDocumentId);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBookMain([Bind()]Models.ViewModels.Books.Create.Create targetV)
        {
            if (ModelState.IsValid)
            {
                var target = targetV.GetTargetBookMain();

                var result = targetV.Save(target);

                if (result)
                    return RedirectToAction("Details", new { id = target.DocumentId });
                else
                    return HttpNotFound();
            }

            return View(targetV);
        }

        public ActionResult CreateBookAbstract(Guid? parentDocumentId)
        {
            var targetV = new Models.ViewModels.Books.Create.Create(parentDocumentId);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBookAbstract([Bind()]Models.ViewModels.Books.Create.Create targetV)
        {
            if (ModelState.IsValid)
            {
                var target = targetV.GetTargetBookAbstract();

                var result = targetV.Save(target);

                if (result)
                    return RedirectToAction("Details", new { id = target.DocumentId });
                else
                    return HttpNotFound();
            }

            return View(targetV);
        }





        public ActionResult EditBookNormal(Guid id)
        {
            var targetV = new Models.ViewModels.Books.Edit.Edit(id);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookNormal([Bind()]Models.ViewModels.Books.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var result = targetV.SaveBookNormal();

                if (result)
                    return RedirectToAction("Details", new { id = targetV.DocumentId });
                else
                    return HttpNotFound();
            }

            return View(targetV);
        }

        public ActionResult EditBookMain(Guid id)
        {
            var targetV = new Models.ViewModels.Books.Edit.Edit(id);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookMain([Bind()]Models.ViewModels.Books.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var result = targetV.SaveBookMain();

                if (result)
                    return RedirectToAction("Details", new { id = targetV.DocumentId });
                else
                    return HttpNotFound();
            }

            return View(targetV);
        }

        public ActionResult EditBookAbstract(Guid id)
        {
            var targetV = new Models.ViewModels.Books.Edit.Edit(id);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBookAbstract([Bind()]Models.ViewModels.Books.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var result = targetV.SaveBookAbstract();

                if (result)
                    return RedirectToAction("Details", new { id = targetV.DocumentId });
                else
                    return HttpNotFound();
            }

            return View(targetV);
        }
    }
}