using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Shelf
{
    public class Move
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }

        public Guid? NewParentDocumentId { get; set; }





        public ValidateResult Save()
        {
            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证书架。
                var shelf = db.Documents.Find(this.DocumentId);
                if (!shelf.IsBook || !shelf.IsAbstract || shelf.IsMain)
                    return new ValidateResult(false, "DocumentId", "不是书架！");
                if (this.TimeStamp != System.BitConverter.ToInt64(shelf.TimeStamp, 0))
                    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //验证目标父书架。
                if (this.NewParentDocumentId.HasValue)
                {
                    var newParentShelf = db.Documents.Find(this.NewParentDocumentId.Value);
                    if (!newParentShelf.IsBook || !newParentShelf.IsAbstract || newParentShelf.IsMain)
                        return new ValidateResult(false, "NewParentDocumentId", "不是书架！");
                }

                //修改书架。
                shelf.ParentDocumentId = NewParentDocumentId;
                shelf.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}