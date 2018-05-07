using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Index
{
    public class Item
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level">层级。从0开始。</param>
        public Item(Domains.Entities.Document target, int level)
        {
            this.Initial(target, level);
        }

        private void Initial(Domains.Entities.Document target, int level)
        {
            this.DocumentId = target.DocumentId;
            this.Level = level;
            this.IsBookMain = target.IsBookMain;

            this.NodeName = target.NodeName;
            this.Priority = target.Priority;
        }





        public Guid DocumentId { get; set; }

        public int Level { get; set; }

        public bool IsBookMain { get; set; }





        [Display(Name = "书架-书籍")]
        public string NodeName { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }
    }
}