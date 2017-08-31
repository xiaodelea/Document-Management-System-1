﻿using System;
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
    }
}