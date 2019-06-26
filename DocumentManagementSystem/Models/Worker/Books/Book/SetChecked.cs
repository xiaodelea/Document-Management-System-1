using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Book
{
    public class SetChecked
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





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

                //修改书籍。
                book.IsChecked = true;
                book.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}