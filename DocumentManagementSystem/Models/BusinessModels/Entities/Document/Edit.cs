using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Entities.Document
{
    public class Edit : Base
    {
        public ValidateResult Save()
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                var target = db.Documents.Find(this.DocumentId);
                if (target == null)
                    return new ValidateResult(false, null);

                if (string.IsNullOrWhiteSpace(this.Title))
                    return new ValidateResult(false, "Title", "Empty");
                if (this.Priority < 0)
                    return new ValidateResult(false, "Priority", "Less Than 0");

                if (System.BitConverter.ToInt64(this.TimeStamp, 0) != System.BitConverter.ToInt64(target.TimeStamp, 0))
                    return new ValidateResult(false, "TimeStamp", "Changed");

                target.Title = this.Title;
                target.NodeName = this.Title;

                target.Priority = this.Priority;
                target.IsChecked = this.IsChecked;

                target.Url = this.Url;
                target.Remarks = this.Remarks;
                target.ISBN = this.ISBN;

                target.IsAbstract = this.IsBookshelf || this.IsChapterMain;
                target.IsMain = this.IsBookRoot || this.IsChapterMain;

                target.UpdateTime = DateTime.Now;

                db.SaveChanges();
            }

            return new ValidateResult(true, null);
        }
    }
}