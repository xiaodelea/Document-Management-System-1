using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Chapter
{
    public class Move
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }

        public Guid NewParentDocumentId { get; set; }





        public ValidateResult Save()
        {
            //验证参数。
            if (this.DocumentId == this.NewParentDocumentId)
                return new ValidateResult(false, "NewParentDocumentId", "目标节点不能为自身节点！");

            var db = new Domains.MySQL.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证章节。
                var chapter = db.Documents.Find(this.DocumentId);
                if (!chapter.IsBook || chapter.IsAbstract || chapter.IsMain)
                    return new ValidateResult(false, "DocumentId", "不是章节！");
                //if (this.TimeStamp != System.BitConverter.ToInt64(chapter.TimeStamp, 0))
                //    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //验证目标父章节或书籍。
                var newParent = db.Documents.Find(this.NewParentDocumentId);
                if (!newParent.IsBook || newParent.IsAbstract)
                    return new ValidateResult(false, "NewParentDocumentId", "不是书籍或章节！");

                //修改书架。
                chapter.ParentDocumentId = NewParentDocumentId;
                chapter.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}