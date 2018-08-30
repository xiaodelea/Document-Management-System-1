using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexBook
{
    public class Item
    {
        public Item(Worker.Books.Book.Details d)
        {
            if (!d._isExist)
                return;

            var shelf = new Worker.Books.Shelf.Details(d.ParentDocumentId);
            if (!shelf._isExist)
                return;

            this.DocumentId = d.DocumentId;

            this.Title = d.Title;
            this.Priority = d.Priority;
            this.IsChecked = d.IsChecked;
            this.UpdateTime = d.UpdateTime;

            this.BookShelfName = shelf.Title;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }





        [Display(Name = "书名")]
        public string Title { get; set; }

        [Display(Name = "书架名")]
        public string BookShelfName { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }

        [Display(Name = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}