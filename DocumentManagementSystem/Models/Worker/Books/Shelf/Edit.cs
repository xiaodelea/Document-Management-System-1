using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Shelf
{
    public class Edit
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }

        public string Title { get; set; }

        public int Priority { get; set; }





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
                //验证书架。
                var shelf = db.Documents.Find(this.DocumentId);
                if (!shelf.IsBook || !shelf.IsAbstract || shelf.IsMain)
                    return new ValidateResult(false, "DocumentId", "不是书架！");
                //if (this.TimeStamp != System.BitConverter.ToInt64(shelf.TimeStamp, 0))
                //    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //修改书架。
                shelf.Title = this.Title;
                shelf.NodeName = this.Title;
                shelf.Priority = this.Priority;
                shelf.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}