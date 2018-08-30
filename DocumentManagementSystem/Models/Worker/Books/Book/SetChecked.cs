using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Book
{
    public class SetChecked
    {
        public Guid DocumentId { get; set; }





        public ValidateResult Save()
        {
            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证书籍。
                var book = db.Documents.Find(this.DocumentId);
                if (!book.IsBook)
                    return new ValidateResult(false, "DocumentId", "不是书籍！");

                //修改书籍。
                book.IsChecked = true;
                book.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}