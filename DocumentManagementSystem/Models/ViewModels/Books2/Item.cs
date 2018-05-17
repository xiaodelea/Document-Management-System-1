using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books2
{
    public class Item
    {
        public Item()
        {

        }

        public Item(Domains.Entities.Document target)
        {
            this.Initial(target);
        }

        public Item(Guid id)
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);
            this.Initial(target);
        }

        private void Initial(Domains.Entities.Document target)
        {
            this.DocumentId = target.DocumentId;
            this.ParentDocumentId = target.ParentDocumentId;

            this.Title = target.Title;
            this.Priority = target.Priority;
            this.IsChecked = target.IsChecked;
            this.Url = target.Url;
            this.Remarks = target.Remarks;
            this.ISBN = target.ISBN;

            this.IsBookAbstract = target.IsBookBookShelf;
            this.IsBookMain = target.IsBookBook;
            this.IsBookNormal = target.IsBookChapter;
            this.IsBookError = target.IsBookError;
        }

        public static int GetPriority(Guid? parentId)
        {
            int? priority;

            var db = new Domains.Entities.DMsDbContext();
            var parent = db.Documents.Find(parentId);

            if (parent == null)
            {
                priority = db.Documents.Where(c => c.ParentDocumentId == null).Max(c => c.Priority);
            }
            else
            {
                priority = parent.ChildDocuments.Max(c => c.Priority);
            }

            if (priority == null)
                priority = 1;
            else
                priority = priority + 1;
            return priority.Value;
        }





        public Guid DocumentId { get; set; }

        public Guid? ParentDocumentId { get; set; }





        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }

        [Url]
        [Display(Name = "URL")]
        public string Url { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }

        [Display(Name = "ISBN")]
        public string ISBN { get; set; }





        public bool IsBookAbstract { get; set; }

        public bool IsBookNormal { get; set; }

        public bool IsBookMain { get; set; }

        public bool IsBookError { get; set; }





        public Tuple<bool, string> CreateBookshelf()
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = new Domains.Entities.Document();
            target.DocumentId = this.DocumentId;
            target.ParentDocumentId = this.ParentDocumentId;
            target.Title = this.Title;
            target.NodeName = this.Title;
            target.Priority = this.Priority;
            target.IsChecked = false;
            target.Url = null;
            target.Remarks = null;
            target.IsBook = true;
            target.ISBN = null;
            target.IsAbstract = true;
            target.IsMain = false;
            target.UpdateTime = DateTime.Now;
            target.UpdateTimeForHTTPGet = DateTime.Now;
            db.Documents.Add(target);
            db.SaveChanges();
            return new Tuple<bool, string>(true, null);
        }

        public Tuple<bool, string> CreateBook()
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = new Domains.Entities.Document();
            target.DocumentId = this.DocumentId;
            target.ParentDocumentId = this.ParentDocumentId;
            target.Title = this.Title;
            target.NodeName = this.Title;
            target.Priority = this.Priority;
            target.IsChecked = false;
            target.Url = this.Url;
            target.Remarks = null;
            target.IsBook = true;
            target.ISBN = this.ISBN;
            target.IsAbstract = false;
            target.IsMain = true;
            target.UpdateTime = DateTime.Now;
            target.UpdateTimeForHTTPGet = DateTime.Now;
            db.Documents.Add(target);
            db.SaveChanges();
            return new Tuple<bool, string>(true, null);
        }

        public Tuple<bool, string> CreateChapter()
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = new Domains.Entities.Document();
            target.DocumentId = this.DocumentId;
            target.ParentDocumentId = this.ParentDocumentId;
            target.Title = this.Title;
            target.NodeName = this.Title;
            target.Priority = this.Priority;
            target.IsChecked = false;
            target.Url = null;
            target.Remarks = null;
            target.IsBook = true;
            target.ISBN = null;
            target.IsAbstract = false;
            target.IsMain = false;
            target.UpdateTime = DateTime.Now;
            target.UpdateTimeForHTTPGet = DateTime.Now;
            db.Documents.Add(target);
            db.SaveChanges();
            return new Tuple<bool, string>(true, null);
        }
    }
}