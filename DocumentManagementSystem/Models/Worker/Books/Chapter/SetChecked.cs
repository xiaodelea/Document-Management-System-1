using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Chapter
{
    public class SetChecked
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        public ValidateResult Save()
        {
            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证章节。
                var chapter = db.Documents.Find(this.DocumentId);
                if (!chapter.IsBook || chapter.IsMain || chapter.IsAbstract)
                    return new ValidateResult(false, "DocumentId", "不是章节！");
                if (this.TimeStamp != System.BitConverter.ToInt64(chapter.TimeStamp, 0))
                    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //修改章节。
                chapter.IsChecked = true;
                chapter.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}