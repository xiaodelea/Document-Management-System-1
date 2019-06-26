using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Book
{
    public class Delete
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        public Guid? ReturnDocumentIdId { get; set; }





        public ValidateResult Save()
        {
            var db = new Domains.MySQL.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证书籍。
                var book = db.Documents.Find(this.DocumentId);
                if (!book.IsBook || !book.IsMain || book.IsAbstract)
                    return new ValidateResult(false, "DocumentId", "不是书籍！");
                //if (this.TimeStamp != System.BitConverter.ToInt64(book.TimeStamp, 0))
                //    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");
                if (book.ChildDocuments.Count() > 0)
                    return new ValidateResult(false, "DocumentId", "有子项目时不允许删除！");

                //设置返回数据。
                this.ReturnDocumentIdId = book.ParentDocumentId;

                //删除书籍。
                db.Documents.Remove(book);

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}