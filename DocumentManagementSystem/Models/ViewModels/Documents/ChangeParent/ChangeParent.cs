using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.ChangeParent
{
    public class ChangeParent
    {
        public ChangeParent(Guid id)
        {
            this.DocumentId = id;
        }

        public ChangeParent()
        {

        }





        [Required]
        public Guid DocumentId { get; set; }





        [Display(Name = "标题")]
        public Guid? NewParentId { get; set; }





        public bool Do()
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(this.DocumentId);
            if (target == null)
                return false;
            target.ParentDocumentId = NewParentId;
            target.UpdateTime = DateTime.Now;
            try
            {
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}