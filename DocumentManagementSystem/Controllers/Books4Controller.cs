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

        public ActionResult IndexBookForShelf(Guid parentDocumentId)
        {
            var i = new Models.ViewModels.Books4.IndexBookForShelf.IndexBookForShelf(parentDocumentId);

            return PartialView(i);
        }

        public ActionResult IndexShelf()
        {
            var i = new Models.ViewModels.Books4.IndexShelf.IndexShelf();

            return View(i);
        }

        public ActionResult IndexShelfForShelf(Guid parentDocumentId)
        {
            var i = new Models.ViewModels.Books4.IndexShelfForShelf.IndexShelfForShelf(parentDocumentId);

            return PartialView(i);
        }

        public ActionResult ListShelfForBook(Guid documentId)
        {
            var i = new Models.ViewModels.Books4.ListShelfForBook.ListShelfForBook(documentId);

            return PartialView(i);
        }

        public ActionResult IndexChapterForBook(Guid parentDocumentId)
        {
            var i = new Models.ViewModels.Books4.IndexChapterForBook.IndexChapterForBook(parentDocumentId);

            return PartialView(i);
        }

        public ActionResult IndexChapterForChapter(Guid parentDocumentId)
        {
            var i = new Models.ViewModels.Books4.IndexChapterForChapter.IndexChapterForChapter(parentDocumentId);

            return PartialView(i);
        }

        public ActionResult Details(Guid id)
        {
            var book = new Models.Worker.Books.Book.Details(id);
            if (book._isExist)
                return RedirectToAction("DetailsBook", new { id });

            var shelf = new Models.Worker.Books.Shelf.Details(id);
            if (shelf._isExist)
                return RedirectToAction("DetailsShelf", new { id });

            var chapter = new Models.Worker.Books.Chapter.Details(id);
            if (chapter._isExist)
                return RedirectToAction("DetailsChapter", new { id });

            return HttpNotFound();
        }

        public ActionResult DetailsBook(Guid id)
        {
            var v = new Models.ViewModels.Books4.DetailsBook.DetailsBook(id);

            if (!v._isExist)
                return HttpNotFound();

            return View(v);
        }

        public ActionResult DetailsShelf(Guid id)
        {
            var v = new Models.ViewModels.Books4.DetailsShelf.DetailsShelf(id);

            if (!v._isExist)
                return HttpNotFound();

            return View(v);
        }

        public ActionResult DetailsChapter(Guid id)
        {
            var v = new Models.ViewModels.Books4.DetailsChapter.DetailsChapter(id);

            if (!v._isExist)
                return HttpNotFound();

            return View(v);
        }

        public ActionResult DirectoryBook(Guid documentId)
        {
            var i = new Models.ViewModels.Books4.DirectoryBook.DirectoryBook(documentId);

            return PartialView(i);
        }

        public ActionResult DirectoryChapter(Guid documentId)
        {
            var i = new Models.ViewModels.Books4.DirectoryChapter.DirectoryChapter(documentId);

            return PartialView(i);
        }

        public ActionResult IndexAddition(Guid documentId)
        {
            var i = new Models.ViewModels.Books4.IndexAddition.IndexAddition(documentId);

            return PartialView(i);
        }

        public ActionResult CreateBook(Guid parentDocumentId)
        {
            var v = new Models.ViewModels.Books4.CreateBook.CreateBook(parentDocumentId);

            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind()]Models.ViewModels.Books4.CreateBook.CreateBook v)
        {
            if (ModelState.IsValid)
            {
                var result = v.Save();

                if (result.Result)
                    return RedirectToAction("Details", new { id = v.DocumentId });
                else if (result.ValidateErrors.Count() == 0)
                    return HttpNotFound();
                else
                    foreach (var error in result.ValidateErrors)
                        ModelState.AddModelError(error.ParaName, error.Description);
            }

            return View(v);
        }

        public ActionResult CreateAddition(Guid documentId)
        {
            var v = new Models.ViewModels.Books4.CreateAddition.CreateAddition(documentId);

            var w = new Models.ViewModels.Books4.CreateAddition.SelectionWorker(v);
            ViewBag.AdditionCategoryId = w.AdditionCategories;

            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAddition([Bind()]Models.ViewModels.Books4.CreateAddition.CreateAddition v)
        {
            if (ModelState.IsValid)
            {
                var result = v.Save();

                if (result.Result)
                    return RedirectToAction("Details", new { id = v.DocumentId });
                else if (result.ValidateErrors.Count() == 0)
                    return HttpNotFound();
                else
                    foreach (var error in result.ValidateErrors)
                        ModelState.AddModelError(error.ParaName, error.Description);
            }

            var w = new Models.ViewModels.Books4.CreateAddition.SelectionWorker(v);
            ViewBag.AdditionCategoryId = w.AdditionCategories;

            return View(v);
        }

        public ActionResult EditBook(Guid documentId)
        {
            var v = new Models.ViewModels.Books4.EditBook.EditBook(documentId);

            return View(v);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook([Bind()]Models.ViewModels.Books4.EditBook.EditBook v)
        {
            if (ModelState.IsValid)
            {
                var result = v.Save();

                if (result.Result)
                    return RedirectToAction("Details", new { id = v.DocumentId });
                else if (result.ValidateErrors.Count() == 0)
                    return HttpNotFound();
                else
                    foreach (var error in result.ValidateErrors)
                        ModelState.AddModelError(error.ParaName, error.Description);
            }

            return View(v);
        }
    }
}