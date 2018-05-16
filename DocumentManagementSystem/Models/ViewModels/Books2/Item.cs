using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books2
{
    public class Item
    {
        public Item(Domains.Entities.Document target)
        {
            this.DocumentId = target.DocumentId;
            this.ParentDocumentId = target.ParentDocumentId;

            this.Title = target.Title;
            this.Priority = target.Priority;
            this.IsChecked = target.IsChecked;
            this.Url = target.Url;
            this.Remarks = target.Remarks;
            this.ISBN = target.ISBN;

            this.IsBookAbstract = target.IsBookAbstract;
            this.IsBookMain = target.IsBookMain;
            this.IsBookNormal = target.IsBookNormal;
            this.IsBookError = target.IsBookError;
        }





        public Guid DocumentId { get; set; }

        public Guid? ParentDocumentId { get; set; }





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
    }
}