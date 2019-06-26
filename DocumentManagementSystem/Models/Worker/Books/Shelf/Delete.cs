using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Shelf
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
                //验证书架。
                var shelf = db.Documents.Find(this.DocumentId);
                if (!shelf.IsBook || !shelf.IsAbstract || shelf.IsMain)
                    return new ValidateResult(false, "DocumentId", "不是书架！");
                //if (this.TimeStamp != System.BitConverter.ToInt64(shelf.TimeStamp, 0))
                //    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");
                if (shelf.ChildDocuments.Count() > 0)
                    return new ValidateResult(false, "DocumentId", "有子项目时不允许删除！");

                //设置返回数据。
                this.ReturnDocumentIdId = shelf.ParentDocumentId;

                //删除书架。
                db.Documents.Remove(shelf);

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}