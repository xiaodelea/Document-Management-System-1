using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Chapter
{
    public class Delete
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        public Guid? ReturnDocumentIdId { get; set; }





        public ValidateResult Save()
        {
            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证章节。
                var chapter = db.Documents.Find(this.DocumentId);
                if (!chapter.IsBook || chapter.IsMain || chapter.IsAbstract)
                    return new ValidateResult(false, "DocumentId", "Not Chapter！");
                if (this.TimeStamp != System.BitConverter.ToInt64(chapter.TimeStamp, 0))
                    return new ValidateResult(false, "TimeStamp", "TimeStamp Not Match！");
                if (chapter.ChildDocuments.Count() > 0)
                    return new ValidateResult(false, "DocumentId", "Children Not Empty！");

                //设置返回数据。
                if (chapter.ParentDocument.ChildDocuments.Count(c => c.Priority < chapter.Priority) > 0)
                    this.ReturnDocumentIdId = chapter.ParentDocument.ChildDocuments.OrderBy(c => c.Priority).Last(c => c.Priority < chapter.Priority).DocumentId;
                else if (chapter.ParentDocument.ChildDocuments.Count(c => c.Priority > chapter.Priority) > 0)
                    this.ReturnDocumentIdId = chapter.ParentDocument.ChildDocuments.OrderBy(c => c.Priority).First(c => c.Priority > chapter.Priority).DocumentId;
                else
                    this.ReturnDocumentIdId = chapter.ParentDocumentId;

                //删除章节。
                db.Documents.Remove(chapter);

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}