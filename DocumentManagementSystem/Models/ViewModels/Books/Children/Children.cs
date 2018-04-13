using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books.Children
{
    public class Children
    {
        public Children(Guid id)
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            this.DocumentId = id;
            this.ParentDocumentId = target.ParentDocumentId;
            this.List = target.ChildDocuments.Where(c => c.IsBook).OrderBy(c => c.Priority).ToList().Select(c => new Item(c)).ToList();
        }





        public Guid DocumentId { get; set; }

        public Guid? ParentDocumentId { get; set; }





        public List<Item> List { get; set; }
    }
}