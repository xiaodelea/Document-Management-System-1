using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementSystem.Controllers
{
    /// <summary>
    /// 书籍管理。
    /// </summary>
    public class Books2Controller : Controller
    {
        /// <summary>
        /// 综合入口。
        /// </summary>
        /// <param name="id">节点ID。为空表示根。</param>
        /// <returns>跳转到对应类别的界面。</returns>
        /// <remarks>自动识别节点ID对应节点的类型——书架、书籍或章节——并进行跳转。</remarks>
        public ActionResult Index(Guid? id)
        {
            if (id == null)
                return RedirectToAction("IndexBookshelf", new { id });

            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            if (target == null)
                return HttpNotFound();

            if (target.IsBookBookShelf)
                return RedirectToAction("IndexBookshelf", new { id });
            else if (target.IsBookBook)
                return RedirectToAction("IndexBook", new { id });
            else if (target.IsBookChapter)
                return RedirectToAction("IndexChapter", new { id });
            else
                return null;
        }

        /// <summary>
        /// 书架。
        /// </summary>
        /// <param name="id">节点ID。为空表示根。</param>
        /// <returns>书架界面。</returns>
        public ActionResult IndexBookshelf(Guid? id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 书籍。
        /// </summary>
        /// <param name="id">节点ID。</param>
        /// <returns>书籍界面。</returns>
        public ActionResult IndexBook(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 章节。
        /// </summary>
        /// <param name="id">节点ID。</param>
        /// <returns>章节界面。</returns>
        public ActionResult IndexChapter(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }





        public PartialViewResult SingleBookshelf(Guid? id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            if (target == null)
            {
                var targetVvirtual = new Models.ViewModels.Books2.Item();
                targetVvirtual.Title = "[根]";
                return PartialView(targetVvirtual);
            }

            if (!target.IsBookBookShelf)
                return null;

            var targetV = new Models.ViewModels.Books2.Item(target);

            return PartialView(targetV);
        }

        public PartialViewResult SingleBook(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            if (target == null)
                return null;

            if (!target.IsBookBook)
                return null;

            var targetV = new Models.ViewModels.Books2.Item(target);

            return PartialView(targetV);
        }

        public PartialViewResult SingleChapter(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            if (target == null)
                return null;

            if (!target.IsBookChapter)
                return null;

            var targetV = new Models.ViewModels.Books2.Item(target);

            return PartialView(targetV);
        }





        public PartialViewResult ListBookShelf(Guid? id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.ParentDocumentId == id);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookBookShelf);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            ViewBag.Id = id;

            return PartialView(list);
        }

        public PartialViewResult ListBook(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.ParentDocumentId == id);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookBook);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            ViewBag.Id = id;

            return PartialView(list);
        }

        public PartialViewResult ListChapter(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.ParentDocumentId == id);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookChapter);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            ViewBag.Id = id;

            return PartialView(list);
        }





        public PartialViewResult DirectoryBookshelf(Guid? id)
        {
            var list = new List<Models.ViewModels.Books2.Item>();

            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            if (target == null)
                return PartialView(list);

            if (!target.IsBookBookShelf)
                return PartialView(list);

            list.Add(new Models.ViewModels.Books2.Item(target));
            while (target.ParentDocumentId != null)
            {
                target = target.ParentDocument;
                list.Add(new Models.ViewModels.Books2.Item(target));
            }
            list.Reverse();

            return PartialView(list);
        }

        public PartialViewResult DirectoryBook(Guid id)
        {
            var list = new List<Models.ViewModels.Books2.Item>();

            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            if (target == null)
                return null;

            if (!target.IsBookBook)
                return null;

            list.Add(new Models.ViewModels.Books2.Item(target));
            while (target.ParentDocumentId != null)
            {
                target = target.ParentDocument;
                list.Add(new Models.ViewModels.Books2.Item(target));
            }
            list.Reverse();

            return PartialView(list);
        }

        public PartialViewResult DirectoryChapter(Guid id)
        {
            var list = new List<Models.ViewModels.Books2.Item>();

            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            if (target == null)
                return null;

            if (!target.IsBookChapter)
                return null;

            list.Add(new Models.ViewModels.Books2.Item(target));
            while (target.ParentDocumentId != null)
            {
                target = target.ParentDocument;
                list.Add(new Models.ViewModels.Books2.Item(target));

                if (target.IsBookBook)
                    break;
            }

            list.Reverse();

            return PartialView(list);
        }





        public JsonResult GetBookshelves(Guid? bookshelfId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.ParentDocumentId == bookshelfId);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookBookShelf);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            return Json(list);
        }

        public JsonResult GetBookshelf(Guid bookshelfId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(bookshelfId);

            if (target == null)
                return null;

            if (!target.IsBookBookShelf)
                return null;

            var targetV = new Models.ViewModels.Books2.Item(target);

            return Json(targetV);
        }

        public JsonResult GetBooks(Guid? bookshelfId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.ParentDocumentId == bookshelfId);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookBook);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            return Json(list);
        }





        public JsonResult GetBook(Guid bookId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(bookId);

            if (target == null)
                return null;

            if (!target.IsBookBook)
                return null;

            var targetV = new Models.ViewModels.Books2.Item(target);

            return Json(targetV);
        }

        public JsonResult GetChapters(Guid parentId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.ParentDocumentId == parentId);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookChapter);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            return Json(list);
        }

        public JsonResult GetChapter(Guid chapterId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(chapterId);

            if (target == null)
                return null;

            if (!target.IsBookChapter)
                return null;

            var targetV = new Models.ViewModels.Books2.Item(target);

            return Json(targetV);
        }





        public ActionResult CreateBookshelf(Guid? parentId)
        {
            var item = new Models.ViewModels.Books2.Item();
            item.DocumentId = Guid.NewGuid();
            item.ParentDocumentId = parentId;
            item.Priority=Models.ViewModels.Books2.Item.GetPriority(parentId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBookshelf([Bind()]Models.ViewModels.Books2.Item item)
        {
            if (ModelState.IsValid)
            {
                var result = item.CreateBookshelf();
                if (result.Item1)
                    return RedirectToAction("Index", new { id = item.DocumentId });
                else
                    return HttpNotFound(result.Item2);
            }
            return View(item);
        }

        public ActionResult CreateBook(Guid? parentId)
        {
            var item = new Models.ViewModels.Books2.Item();
            item.DocumentId = Guid.NewGuid();
            item.ParentDocumentId = parentId;
            item.Priority = Models.ViewModels.Books2.Item.GetPriority(parentId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind()]Models.ViewModels.Books2.Item item)
        {
            if (ModelState.IsValid)
            {
                var result = item.CreateBook();
                if (result.Item1)
                    return RedirectToAction("Index", new { id = item.DocumentId });
                else
                    return HttpNotFound(result.Item2);
            }
            return View(item);
        }

        public ActionResult CreateChapter(Guid parentId)
        {
            var item = new Models.ViewModels.Books2.Item();
            item.DocumentId = Guid.NewGuid();
            item.ParentDocumentId = parentId;
            item.Priority = Models.ViewModels.Books2.Item.GetPriority(parentId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateChapter([Bind()]Models.ViewModels.Books2.Item item)
        {
            if (ModelState.IsValid)
            {
                var result = item.CreateChapter();
                if (result.Item1)
                    return RedirectToAction("Index", new { id = item.DocumentId });
                else
                    return HttpNotFound(result.Item2);
            }
            return View(item);
        }
    }
}