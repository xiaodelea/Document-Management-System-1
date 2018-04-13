using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Children
{
    public class Item
    {
        public Item(Domains.Entities.Document target)
        {
            this.DocumentId = target.DocumentId;

            this.NodeName = target.NodeName;
            this.Priority = target.Priority;
            this.IsChecked = target.IsChecked;
        }





        public Guid DocumentId { get; set; }





        [Display(Name = "节点名称")]
        public string NodeName { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }
    }
}