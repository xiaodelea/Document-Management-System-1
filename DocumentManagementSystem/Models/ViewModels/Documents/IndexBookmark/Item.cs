using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.IndexBookmark
{
    public class Item
    {
        public Item(Models.Domains.Entities.Document target)
        {
            this.DocumentId = target.DocumentId;

            this.NodeName = target.NodeName;
            this.Path = target.Path;
        }





        public Guid DocumentId { get; set; }





        [Required]
        [Display(Name = "节点名称")]
        public string NodeName { get; set; }

        [Display(Name = "路径")]
        public string Path { get; set; }
    }
}