using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Chapter
{
    public class Create
    {
        public Guid ParentDocumentId { get; set; }

        public string Title { get; set; }

        public int Priority { get; set; }

        public Guid? CurrentDocumentIdToSetFinished { get; set; }





        public Guid? DocumentId { get; set; }





        public ValidateResult Save()
        {
            //验证参数。
            if (string.IsNullOrWhiteSpace(this.Title))
                return new ValidateResult(false, "Title", "标题不可为空！");
            if (this.Priority < 0)
                return new ValidateResult(false, "Priority", "序号不可小于0！");

            //构建章节。
            var chapter = new Domains.MySQL.Entities.Document
            {
                DocumentId = Guid.NewGuid(),
                ParentDocumentId = this.ParentDocumentId,
                Title = this.Title,
                NodeName = this.Title,
                Priority = this.Priority,
                UpdateTimeForHTTPGet = DateTime.Now,
                IsBook = true,
                UpdateTime = DateTime.Now,
            };

            var db = new Domains.MySQL.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //添加章节。
                db.Documents.Add(chapter);

                //更新书籍。
                var parent = db.Documents.Find(this.ParentDocumentId);
                do
                {
                    if (parent.IsBook && parent.IsMain)
                        break;

                    parent = db.Documents.Find(parent.ParentDocumentId);
                } while (true);
                parent.UpdateTime = DateTime.Now;

                //设置章节完成。
                if (this.CurrentDocumentIdToSetFinished.HasValue)
                {
                    var currentDocumentToSetFinished = db.Documents.Find(this.CurrentDocumentIdToSetFinished);

                    if (currentDocumentToSetFinished == null)
                        return new ValidateResult(false, "CurrentDocumentIdToSetFinished", "当前设置完成的节点不存在！");
                    if (!currentDocumentToSetFinished.IsBook || currentDocumentToSetFinished.IsAbstract || currentDocumentToSetFinished.IsMain)
                        return new ValidateResult(false, "CurrentDocumentIdToSetFinished", "当前设置完成的节点类型错误！");

                    currentDocumentToSetFinished.IsChecked = true;
                }

                db.SaveChanges();

                //回传参数。
                this.DocumentId = chapter.DocumentId;
            }

            return new ValidateResult(true);
        }
    }
}