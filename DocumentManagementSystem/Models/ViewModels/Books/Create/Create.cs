using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Create
{
    public class Create
    {
        public Create(Guid? parentDocumentId)
        {
            this.ParentDocumentId = parentDocumentId;

            var db = new Domains.Entities.DMsDbContext();
            var parentDocument = db.Documents.Find(parentDocumentId);
            if (parentDocument == null)
            {
                this.Priority = db.Documents.Where(c => c.ParentDocumentId == null).Max(c => c.Priority) + 1;
            }
            else
            {
                this.Priority = parentDocument.ChildDocuments.Max(c => c.Priority) + 1;
            }
            if (this.Priority == null)
                this.Priority = 1;
        }

        public Create()
        {

        }





        public Guid? ParentDocumentId { get; set; }





        [Required]
        [Display(Name = "节点名称")]
        public string NodeName { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }





        [Display(Name = "抽象")]
        public bool IsAbstract { get; set; }

        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }

        [Display(Name = "书签")]
        public bool IsBookmarked { get; set; }





        [Display(Name = "主要")]
        public bool IsMain { get; set; }

        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }





        public Domains.Entities.Document GetTargetBookNormal()
        {
            var target = new Domains.Entities.Document();
            target.DocumentId = Guid.NewGuid();
            target.ParentDocumentId = this.ParentDocumentId;
            target.Title = this.NodeName;
            target.NodeName = this.NodeName;
            target.Priority = this.Priority;
            target.Remarks = this.Remarks;
            target.IsBook = true;
            target.UpdateTime = DateTime.Now;

            target.UpdateTimeForHTTPGet = DateTime.Now;

            return target;
        }

        public Domains.Entities.Document GetTargetBookMain()
        {
            var target = new Domains.Entities.Document();
            target.DocumentId = Guid.NewGuid();
            target.ParentDocumentId = this.ParentDocumentId;
            target.Title = this.NodeName;
            target.NodeName = this.NodeName;
            target.Priority = this.Priority;
            target.Url = this.Url;
            target.Remarks = this.Remarks;
            target.IsBook = true;
            target.ISBN = this.ISBN;
            target.IsMain = true;
            target.UpdateTime = DateTime.Now;

            target.UpdateTimeForHTTPGet = DateTime.Now;

            return target;
        }

        public Domains.Entities.Document GetTargetBookAbstract()
        {
            var target = new Domains.Entities.Document();
            target.DocumentId = Guid.NewGuid();
            target.ParentDocumentId = this.ParentDocumentId;
            target.Title = this.NodeName;
            target.NodeName = this.NodeName;
            target.Priority = this.Priority;
            target.Remarks = this.Remarks;
            target.IsBook = true;
            target.IsAbstract = true;
            target.UpdateTime = DateTime.Now;

            target.UpdateTimeForHTTPGet = DateTime.Now;

            return target;
        }

        public bool Save(Domains.Entities.Document target)
        {
            var db = new Domains.Entities.DMsDbContext();
            db.Documents.Add(target);
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