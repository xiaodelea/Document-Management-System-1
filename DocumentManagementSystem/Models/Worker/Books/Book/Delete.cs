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





        public ValidateResult Save()
        {
            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证书籍。
                var book = db.Documents.Find(this.DocumentId);
                if (!book.IsBook || !book.IsMain || book.IsAbstract)
                    return new ValidateResult(false, "DocumentId", "不是书籍！");
                if (this.TimeStamp != System.BitConverter.ToInt64(book.TimeStamp, 0))
                    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //删除书籍。
                db.Documents.Remove(book);

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}