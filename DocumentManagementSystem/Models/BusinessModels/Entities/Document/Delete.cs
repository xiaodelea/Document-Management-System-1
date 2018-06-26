using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Entities.Document
{
    public class Delete : Base
    {
        public Delete(Guid documentId, byte[] timeStamp)
        {
            this.DocumentId = documentId;
            this.TimeStamp = timeStamp;
        }





        public ValidateResult Save()
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                var target = db.Documents.Find(this.DocumentId);
                if (target == null)
                    return new ValidateResult(false, null);

                if (System.BitConverter.ToInt64(this.TimeStamp, 0) != System.BitConverter.ToInt64(target.TimeStamp, 0))
                    return new ValidateResult(false, "TimeStamp", "Changed");

                db.Documents.Remove(target);
                db.SaveChanges();
            }

            return new ValidateResult(true, null);
        }
    }
}