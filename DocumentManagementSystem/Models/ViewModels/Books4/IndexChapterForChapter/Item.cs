using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexChapterForChapter
{
    public class Item
    {
        public Item(Worker.Books.Chapter.Details d)
        {
            if (!d._isExist)
                return;

            this.DocumentId = d.DocumentId;

            this.Title = d.Title;
            this.Priority = d.Priority;
            this.IsChecked = d.IsChecked;

            this._isExist = true;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }





        [Display(Name = "子章节")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }
    }
}