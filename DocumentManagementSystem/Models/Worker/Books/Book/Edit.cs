using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Book
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

            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证书籍。
                var book = db.Documents.Find(this.DocumentId);
                if (!book.IsBook)
                    return new ValidateResult(false, "DocumentId", "不是书籍！");
                if (this.TimeStamp != System.BitConverter.ToInt64(book.TimeStamp, 0))
                    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //修改书籍。
                book.Title = this.Title;
                book.Priority = this.Priority;
                book.IsChecked = this.IsChecked;
                book.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}