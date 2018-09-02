using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Addition
{
    public class Edit
    {
        public Guid AdditionId { get; set; }

        public long TimeStamp { get; set; }

        public string Description { get; set; }





        public ValidateResult Save()
        {
            //验证参数。
            if (string.IsNullOrWhiteSpace(this.Description))
                return new ValidateResult(false, "Description", "不可为空！");

            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证信息。
                var addition = db.Additions.Find(this.AdditionId);
                if (this.TimeStamp != System.BitConverter.ToInt64(addition.TimeStamp, 0))
                    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //检测节点。
                var document = db.Documents.Find(addition.DocumentId);
                if (document == null)
                    return new ValidateResult(false, "DocumentId", "节点不存在！");

                //修改信息。
                addition.Description = this.Description;
                addition.UpdateTime = DateTime.Now;

                //修改节点。
                document.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}