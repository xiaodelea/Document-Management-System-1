using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexShelf
{
    public class Item
    {
        public Item(Worker.Books.Shelf.Details d, int level)
        {
            if (!d._isExist)
                return;

            this.DocumentId = d.DocumentId;
            this.Level = level;

            this.Title = d.Title;
            this.Priority = d.Priority;
            this.UpdateTime = d.UpdateTime;

            this._isExist = true;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public int Level { get; set; }





        [Display(Name = "书架名")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}