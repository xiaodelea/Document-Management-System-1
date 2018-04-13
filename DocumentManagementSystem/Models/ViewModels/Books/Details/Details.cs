using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Details
{
    public class Details
    {
        public Details(Domains.Entities.Document target)
        {
            this.Initial(target);
        }

        public Details(Guid id)
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);
            this.Initial(target);
        }

        public void Initial(Domains.Entities.Document target)
        {
            var db = new Domains.Entities.DMsDbContext();

            this.ParentDocumentId = target.ParentDocumentId;
            this.DocumentId = target.DocumentId;
            {
                if (target.ParentDocumentId != null)
                    this.PreSilbingDocumentId = target.ParentDocument.ChildDocuments.Where(c => c.IsBook && c.Priority < target.Priority).OrderBy(c => c.Priority).LastOrDefault()?.DocumentId;
                else
                    this.PreSilbingDocumentId = db.Documents.Where(c => c.IsBook && c.ParentDocumentId == null && c.Priority < target.Priority).OrderBy(c => c.Priority).ToList().LastOrDefault()?.DocumentId;
            }
            {
                if (target.ParentDocumentId != null)
                    this.PostSilbingDocumentId = target.ParentDocument.ChildDocuments.Where(c => c.IsBook && c.Priority > target.Priority).OrderBy(c => c.Priority).FirstOrDefault()?.DocumentId;
                else
                    this.PostSilbingDocumentId = db.Documents.Where(c => c.IsBook && c.ParentDocumentId == null && c.Priority > target.Priority).OrderBy(c => c.Priority).ToList().FirstOrDefault()?.DocumentId;
            }
            this.IsBookAbstract = target.IsBookAbstract;  
            this.IsBookMain = target.IsBookMain;
            this.IsBookNormal = target.IsBookNormal;

            this.NodeName = target.NodeName;
            this.Priority = target.Priority;
            this.Remarks = target.Remarks;

            if (this.IsBookMain)
            {
                this.Main = new Main();
                this.Main.Url = target.Url;
                this.Main.ISBN = target.ISBN;
            }

            if (!this.IsBookAbstract)
            {
                this.Concrete = new Concrete();
                this.Concrete.DocumentId = this.DocumentId;
                this.Concrete.IsChecked = target.IsChecked;
                this.Concrete.IsBookmarked = target.IsBookmarked;
            }
            else
            {
                this.Abstract = new Abstract();
            }
        }





        public Guid DocumentId { get; set; }

        public Guid? PreSilbingDocumentId { get; set; }

        public Guid? ParentDocumentId { get; set; }

        public Guid? PostSilbingDocumentId { get; set; }

        [Display(Name = "抽象")]
        public bool IsBookAbstract { get; set; }

        [Display(Name = "主")]
        public bool IsBookMain { get; set; }

        [Display(Name = "普通")]
        public bool IsBookNormal { get; set; }





        [Display(Name = "节点名称")]
        public string NodeName { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "备注")]
        public string Remarks { get; set; }





        public Concrete Concrete { get; set; }

        public Abstract Abstract { get; set; }

        public Main Main { get; set; }
    }
}