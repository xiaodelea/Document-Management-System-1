using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Entities.Document
{
    public class Create : Base
    {
        public ValidateResult Save()
        {
            var target = new Models.Domains.Entities.Document
            {
                DocumentId = Guid.NewGuid(),

                ParentDocumentId = this.ParentDocumentId,

                Title = this.Title,
                NodeName = this.Title,

                Priority = this.Priority,
                UpdateTimeForHTTPGet = DateTime.Now,
                IsChecked = this.IsChecked,

                Url = this.Url,
                Remarks = this.Remarks,
                IsBook = true,
                ISBN = this.ISBN,

                IsAbstract = this.IsBookshelf || this.IsChapterMain,
                IsMain = this.IsBookRoot || this.IsChapterMain,

                UpdateTime = DateTime.Now
            };

            var db = new Models.Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                if (string.IsNullOrWhiteSpace(this.Title))
                    return new ValidateResult(false, "Title", "Empty");
                if (this.Priority < 0)
                    return new ValidateResult(false, "Priority", "Less Than 0");

                db.Documents.Add(target);
                db.SaveChanges();
            }

            this.DocumentId = target.DocumentId;

            return new ValidateResult(true, null);
        }
    }
}