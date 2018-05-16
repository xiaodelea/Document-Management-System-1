﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementSystem.Controllers
{
    public class Books2Controller : Controller
    {
        public JsonResult GetBookshelves(Guid? bookshelfId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.ParentDocumentId == bookshelfId);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookAbstract);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            return Json(list);
        }

        public JsonResult GetBookshelf(Guid bookshelfId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(bookshelfId);

            if (target == null)
                return null;

            if (!target.IsBookAbstract)
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

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookMain);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            return Json(list);
        }

        public JsonResult GetBook(Guid bookId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(bookId);

            if (target == null)
                return null;

            if (!target.IsBookMain)
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

            var @enum = queryOrdered.AsEnumerable().Where(c => c.IsBookNormal);

            var list = @enum.ToList().Select(c => new Models.ViewModels.Books2.Item(c)).ToList();

            return Json(list);
        }

        public JsonResult GetChapter(Guid chapterId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(chapterId);

            if (target == null)
                return null;

            if (!target.IsBookNormal)
                return null;

            var targetV = new Models.ViewModels.Books2.Item(target);

            return Json(targetV);
        }
    }
}