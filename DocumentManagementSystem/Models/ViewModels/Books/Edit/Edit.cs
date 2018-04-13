using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Edit
{
    public class Edit
    {
        public Edit(Guid id)
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);
            this.Initial(target);
        }

        public Edit()
        {

        }

        public void Initial(Domains.Entities.Document target)
        {
            this.DocumentId = target.DocumentId;

            this.NodeName = target.NodeName;
            this.Priority = target.Priority;
            this.Remarks = target.Remarks;

            this.IsAbstract = target.IsAbstract;
            this.IsChecked = target.IsChecked;
            this.IsBookmarked = target.IsBookmarked;

            this.IsMain = target.IsMain;
            this.ISBN = target.ISBN;
            this.Url = target.Url;

            this.TimeStamp = target.TimeStamp;
        }





        public Guid DocumentId { get; set; }





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





        [Timestamp]
        public byte[] TimeStamp { get; set; }





        public bool Save()
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(this.DocumentId);

            target.NodeName = this.NodeName;
            target.Priority = this.Priority;
            target.Remarks = this.Remarks;
            target.IsAbstract = this.IsAbstract;
            target.IsChecked = this.IsChecked;
            target.IsBookmarked = this.IsBookmarked;
            target.IsMain = this.IsMain;
            target.ISBN = this.ISBN;
            target.Url = this.Url;
            target.TimeStamp = this.TimeStamp;
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