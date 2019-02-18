using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Chapter
{
    public class Clone
    {
        /// <summary>
        /// 作为容器放置克隆内容的节点。
        /// </summary>
        public Guid PasteDocumentId { get; set; }

        /// <summary>
        /// 该节点的所有子节点（不限于一级子节点）作为复制内容。
        /// </summary>
        public Guid CopyDocumentId { get; set; }





        public ValidateResult Save()
        {
            var db = new Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                var paste = db.Documents.Find(this.PasteDocumentId);
                if (paste == null)
                    return new ValidateResult(false, "PasteDocumentId", "Not Exist！");
                if (!paste.IsBookBook && !paste.IsBookChapter)
                    return new ValidateResult(false, "PasteDocumentId", "Not a Book or a Chapter！");

                var copy = db.Documents.Find(this.CopyDocumentId);
                if (copy == null)
                    return new ValidateResult(false, "CopyDocumentId", "Not Exist！");
                if (!copy.IsBookBook && !copy.IsBookChapter)
                    return new ValidateResult(false, "CopyDocumentId", "Not a Book or a Chapter！");
                if (copy.ChildDocuments.Count() == 0)
                    return new ValidateResult(false, "CopyDocumentId", "No Children！");

                //复制。
                this.CopyChildren(paste, copy, db);

                db.SaveChanges();
            }

            return new ValidateResult(true);
        }

        private void CopyChildren(Domains.Entities.Document target, Domains.Entities.Document origin, Domains.Entities.DMsDbContext db)
        {
            foreach (var item in origin.ChildDocuments)
            {
                var newItem = new Domains.Entities.Document
                {
                    DocumentId = Guid.NewGuid(),
                    ParentDocumentId = target.DocumentId,
                    Title = item.Title,
                    NodeName = item.NodeName,
                    Priority = item.Priority,
                    IsChecked = item.IsChecked,
                    IsBook = true,
                    UpdateTime = DateTime.Now,

                    UpdateTimeForHTTPGet = DateTime.Now,
                };
                target.ChildDocuments.Add(newItem);
                if (item.ChildDocuments.Count() > 0)
                    this.CopyChildren(newItem, item, db);
            }
        }
    }
}