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
            var addition = new Domains.Entities.Addition
            {
                AdditionId = Guid.NewGuid(),
                AdditionCategoryId = this.AdditionCategoryId,
                DocumentId = this.DocumentId,
                Description = this.Description,
                UpdateTime = DateTime.Now,
            };

            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //添加信息。
                db.Additions.Add(addition);

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }
    }
}