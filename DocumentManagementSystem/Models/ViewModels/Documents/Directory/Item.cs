using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.Directory
{
    public class Item
    {
        public Item(Guid documentId, string preSpace, string nodeNameFull, bool isFinished)
        {
            this.DocumentId = documentId;
            this.PreSpace = preSpace;

            this.NodeName = nodeNameFull;
            this.IsFinished = isFinished;
        }





        public Guid DocumentId { get; set; }

        public string PreSpace { get; set; }





        [Display(Name = "节点")]
        public string NodeName { get; set; }

        [Display(Name = "完成")]
        public bool IsFinished { get; set; }
    }
}