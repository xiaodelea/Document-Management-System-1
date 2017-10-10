using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementSystem.Controllers
{
    /// <summary>
    /// 文档控制器。
    /// </summary>
    public class DocumentsController : Controller
    {
        /// <summary>
        /// 一览。
        /// </summary>
        /// <remarks>仅显示根节点。</remarks>
        public ActionResult Index()
        {
            var targetV = new Models.ViewModels.Documents.Index.Index();

            return View(targetV);
        }

        public ActionResult IndexBookmark()
        {
            var targetV = new Models.ViewModels.Documents.IndexBookmark.IndexBookmark();

            return View(targetV);
        }

        /// <summary>
        /// 明细。
        /// </summary>
        /// <param name="id">文档ID。</param>
        public ActionResult Details(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();

            var target = db.Documents.Find(id);

            var targetV = new Models.ViewModels.Documents.Details.Details(target);

            return View(targetV);
        }

        /// <summary>
        /// 新增。
        /// </summary>
        /// <param name="parentDocumentId">指定的父文档的文档ID。为空时表示增加根文档。</param>
        public ActionResult Create(Guid? parentDocumentId)
        {
            var targetV = new Models.ViewModels.Documents.Create.Create(parentDocumentId);

            return View(targetV);
        }

        /// <summary>
        /// 新增 执行。
        /// </summary>
        /// <param name="targetV">视图对象。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind()] Models.ViewModels.Documents.Create.Create targetV)
        {
            if (ModelState.IsValid)
            {
                var target = targetV.GetReturn();

                var db = new Models.Domains.Entities.DMsDbContext();
                db.Documents.Add(target);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = target.DocumentId });
            }

            return View(targetV);
        }

        public ActionResult CreateByUrl(Guid? parentDocumentId)
        {
            var targetV = new Models.ViewModels.Documents.CreateByUrl.CreateByUrl(parentDocumentId);
            var targetW = new Models.ViewModels.Documents.CreateByUrl.SelectionWorker(targetV);

            ViewBag.CodeOfSolver = targetW.CodesOfSolver;

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateByUrl([Bind()]Models.ViewModels.Documents.CreateByUrl.CreateByUrl targetV)
        {
            if (ModelState.IsValid)
            {
                switch (targetV.CodeOfSolver)
                {
                    case "MicrosoftDocs":
                        return RedirectToAction("CreateByUrlMicrosoftDocs", targetV);
                    default:
                        return HttpNotFound();
                }
            }

            var targetW = new Models.ViewModels.Documents.CreateByUrl.SelectionWorker(targetV);

            ViewBag.CodeOfSolver = targetW.CodesOfSolver;

            return View(targetV);
        }

        public ActionResult CreateByUrlMicrosoftDocs(Guid? parentDocumentId, string url)
        {
            var targetV = new Models.ViewModels.Documents.CreateByUrlMicrosoftDocs.CreateByUrlMicrosoftDocs(parentDocumentId, url);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateByUrlMicrosoftDocs([Bind()]Models.ViewModels.Documents.CreateByUrlMicrosoftDocs.CreateByUrlMicrosoftDocs targetV)
        {
            if (ModelState.IsValid)
            {
                //var targetB = new Models.BusinessModels.PageContentSolver.MicrosoftDocs(targetV.Url, targetV.NodeName);
                var targetB = new Models.BusinessModels.PageContentSolver.MicrosoftDocs(targetV);

                bool result;

                result = targetB.GetPage();
                if (!result)
                    return HttpNotFound();

                result = targetB.ParsePage();
                if (!result)
                    return HttpNotFound();

                var target = targetB.GetReturn();

                var db = new Models.Domains.Entities.DMsDbContext();

                target.DocumentId = Guid.NewGuid();
                target.ParentDocumentId = targetV.ParentDocumentId;
                {
                    target.Priority = db.Documents.Where(c => c.ParentDocumentId == targetV.ParentDocumentId).Max(c => c.Priority) + 1;
                    if (target.Priority == null) target.Priority = 1;
                }
                target.UpdateTime = DateTime.Now;

                db.Documents.Add(target);
                db.SaveChanges();

                return RedirectToAction("Details", new { id = target.ParentDocumentId });
            }

            return View(targetV);
        }

        /// <summary>
        /// 编辑。
        /// </summary>
        /// <param name="id">文档ID。</param>
        public ActionResult Edit(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            if (target == null)
                return HttpNotFound();

            var targetV = new Models.ViewModels.Documents.Edit.Edit(target);

            return View(targetV);
        }

        /// <summary>
        /// 编辑 执行。
        /// </summary>
        /// <param name="document">视图对象。</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind()]Models.ViewModels.Documents.Edit.Edit targetV)
        {
            if (ModelState.IsValid)
            {
                var db = new Models.Domains.Entities.DMsDbContext();
                var target = db.Documents.Find(targetV.DocumentId);

                targetV.GetReturn(target);
                target.UpdateTime = DateTime.Now;

                db.SaveChanges();

                return RedirectToAction("Details", new { id = target.DocumentId });
            }

            return View(targetV);
        }

        /// <summary>
        /// 删除。
        /// </summary>
        /// <param name="id">文档ID。</param>
        /// <returns>父文档页面（如果有父文档）或一览（如果无父文档）。</returns>
        /// <remarks>直接删除。不提示。</remarks>
        public ActionResult Delete(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();

            var target = db.Documents.Find(id);

            if (target == null)
                return HttpNotFound();

            var parentDocumentId = target.ParentDocumentId;

            target.ParentDocumentId = null;
            db.SaveChanges();
            db.Documents.Remove(target);
            db.SaveChanges();

            if (parentDocumentId != null)
                return RedirectToAction("Details", new { id = parentDocumentId });
            else
                return RedirectToAction("Index");
        }

        /// <summary>
        /// 面包屑。
        /// </summary>
        /// <param name="id">当前文档ID。</param>
        /// <returns></returns>
        public PartialViewResult BreadField(Guid id, bool activeCurrentNode)
        {
            var db = new Models.Domains.Entities.DMsDbContext();

            var target = db.Documents.Find(id);

            var targetV = new Models.ViewModels.Documents.BreadField.BreadField(target, activeCurrentNode);

            return PartialView(targetV);
        }

        /// <summary>
        /// 新增章节。
        /// </summary>
        /// <param name="documentId">归属的文档ID。</param>
        /// <returns></returns>
        public ActionResult CreateChapter(Guid documentId)
        {
            var targetV = new Models.ViewModels.Documents.CreateChapter.CreateChapter(documentId);

            return View(targetV);
        }

        /// <summary>
        /// 新增章节。
        /// </summary>
        /// <param name="targetV">视图对象。</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateChapter([Bind]Models.ViewModels.Documents.CreateChapter.CreateChapter targetV)
        {
            if (ModelState.IsValid)
            {
                var db = new Models.Domains.Entities.DMsDbContext();

                var target = targetV.GetReturn();
                db.Chapters.Add(target);

                db.SaveChanges();

                return RedirectToAction("Details", new { id = targetV.DocumentId });
            }

            return View(targetV);
        }

        /// <summary>
        /// 新增文档章节-批量。
        /// </summary>
        /// <param name="documentId">文档ID。</param>
        /// <returns></returns>
        public ActionResult CreateChapterBatch(Guid documentId)
        {
            var targetV = new Models.ViewModels.Documents.CreateChapterBatch.CreateChapterBatch(documentId);

            return View(targetV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateChapterBatch([Bind()]Models.ViewModels.Documents.CreateChapterBatch.CreateChapterBatch targetV)
        {
            if (ModelState.IsValid)
            {
                var db = new Models.Domains.Entities.DMsDbContext();

                var targetList = targetV.GetReturnList();

                foreach (var target in targetList)
                {
                    db.Chapters.Add(target);
                }

                db.SaveChanges();

                return RedirectToAction("Details", new { id = targetV.DocumentId });
            }

            return View(targetV);
        }

        /// <summary>
        /// 删除章节。
        /// </summary>
        /// <param name="chapterId">章节ID。</param>
        /// <returns></returns>
        public ActionResult DeleteChapter(Guid chapterId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();

            var target = db.Chapters.Find(chapterId);

            db.Chapters.Remove(target);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = target.DocumentId });
        }
    }
}