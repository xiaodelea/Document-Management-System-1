using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Index
{
    public class Item
    {
        public Item(Domains.Entities.Document target, int level)
        {
            this.Initial(target, level);
        }

        private void Initial(Domains.Entities.Document target, int level)
        {
            this.DocumentId = target.DocumentId;
            this.Level = level;
            this.IsMain = target.IsMain;

            this.NodeName = target.NodeName;
            this.Priority = target.Priority;
        }





        public Guid DocumentId { get; set; }

        public int Level { get; set; }

        public bool IsMain { get; set; }





        [Display(Name = "节点名称")]
        public string NodeName { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }
    }
}