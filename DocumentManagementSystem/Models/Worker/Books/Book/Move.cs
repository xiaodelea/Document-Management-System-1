﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Book
{
    public class Move
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }

        public Guid NewParentDocumentId { get; set; }





        public ValidateResult Save()
        {
            //验证参数。
            if (this.DocumentId == this.NewParentDocumentId)
                return new ValidateResult(false, "NewParentDocumentId", "目标节点不能为自身节点！");

            var db = new Domains.MySQL.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证书籍。
                var book = db.Documents.Find(this.DocumentId);
                if (!book.IsBook || book.IsAbstract || !book.IsMain)
                    return new ValidateResult(false, "DocumentId", "不是书籍！");
                //if (this.TimeStamp != System.BitConverter.ToInt64(book.TimeStamp, 0))
                //    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //验证目标书架。
                var newShelf = db.Documents.Find(this.NewParentDocumentId);
                if (!newShelf.IsBook || !newShelf.IsAbstract || newShelf.IsMain)
                    return new ValidateResult(false, "NewParentDocumentId", "不是书架！");

                //修改书籍。
                book.ParentDocumentId = NewParentDocumentId;
                book.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}