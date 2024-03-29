﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Chapter
{
    public class Edit
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }

        public string Title { get; set; }

        public int Priority { get; set; }

        public bool IsChecked { get; set; }





        public ValidateResult Save()
        {
            //验证参数。
            if (string.IsNullOrWhiteSpace(this.Title))
                return new ValidateResult(false, "Title", "标题不可为空！");
            if (this.Priority < 0)
                return new ValidateResult(false, "Priority", "序号不可小于0！");

            var db = new Domains.MySQL.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证章节。
                var chapter = db.Documents.Find(this.DocumentId);
                if (!chapter.IsBook || chapter.IsMain || chapter.IsAbstract)
                    return new ValidateResult(false, "DocumentId", "不是章节！");
                //if (this.TimeStamp != System.BitConverter.ToInt64(chapter.TimeStamp, 0))
                //    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //修改章节。
                chapter.Title = this.Title;
                chapter.NodeName = this.Title;
                chapter.Priority = this.Priority;
                chapter.IsChecked = this.IsChecked;
                chapter.UpdateTime = DateTime.Now;

                //更新书籍。
                var parent = db.Documents.Find(chapter.ParentDocumentId);
                do
                {
                    if (parent.IsBook && parent.IsMain)
                        break;

                    parent = db.Documents.Find(parent.ParentDocumentId);
                } while (true);
                parent.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}