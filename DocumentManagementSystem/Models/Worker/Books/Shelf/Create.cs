﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Shelf
{
    public class Create
    {
        public Guid? ParentDocumentId { get; set; }

        public string Title { get; set; }

        public int Priority { get; set; }





        public Guid? DocumentId { get; set; }





        public ValidateResult Save()
        {
            //验证参数。
            if (string.IsNullOrWhiteSpace(this.Title))
                return new ValidateResult(false, "Title", "标题不可为空！");
            if (this.Priority < 0)
                return new ValidateResult(false, "Priority", "序号不可小于0！");

            //构建书架。
            var shelf = new Domains.MySQL.Entities.Document
            {
                DocumentId = Guid.NewGuid(),
                ParentDocumentId = this.ParentDocumentId,
                Title = this.Title,
                NodeName = this.Title,
                Priority = this.Priority,
                UpdateTimeForHTTPGet = DateTime.Now,
                IsBook = true,
                IsAbstract = true,
                UpdateTime = DateTime.Now,
            };

            var db = new Domains.MySQL.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //添加书架。
                db.Documents.Add(shelf);

                db.SaveChanges();

                //回传参数。
                this.DocumentId = shelf.DocumentId;
            }

            return new ValidateResult(true);
        }
    }
}