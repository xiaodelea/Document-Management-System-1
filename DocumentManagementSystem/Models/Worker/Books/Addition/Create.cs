using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Addition
{
    public class Create
    {
        public Guid DocumentId { get; set; }

        public Guid AdditionCategoryId { get; set; }

        public string Description { get; set; }





        public ValidateResult Save()
        {
            //验证参数。
            if (string.IsNullOrWhiteSpace(this.Description))
                return new ValidateResult(false, "Description", "不可为空！");

            //构建信息。
            var addition = new Domains.MySQL.Entities.Addition
            {
                AdditionId = Guid.NewGuid(),
                AdditionCategoryId = this.AdditionCategoryId,
                DocumentId = this.DocumentId,
                Description = this.Description,
                UpdateTime = DateTime.Now,
            };

            var db = new Domains.MySQL.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //检测节点。
                var document = db.Documents.Find(this.DocumentId);
                if (document == null)
                    return new ValidateResult(false, "DocumentId", "节点不存在！");

                //添加信息。
                db.Additions.Add(addition);

                //修改节点。
                document.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}