using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Directory
{
    public class Item
    {
        public Item(Domains.Entities.Document target, Guid id, int level)
        {
            this.DocumentId = target.DocumentId;
            this.NodeName = target.NodeName;
            this.IsCurrent = this.DocumentId == id;
            this.Level = level;
            this.IsChecked = target.IsChecked;
            this.Priority = target.Priority;
        }





        public Guid DocumentId { get; set; }

        [Display(Name = "目录")]
        public string NodeName { get; set; }

        public bool IsCurrent { get; set; }

        public int Level { get; set; }

        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }
    }
}