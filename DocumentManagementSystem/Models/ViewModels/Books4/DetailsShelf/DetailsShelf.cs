using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.DetailsShelf
{
    public class DetailsShelf
    {
        public DetailsShelf(Guid id)
        {
            var shelf = new Worker.Books.Shelf.Details(id);
            if (!shelf._isExist)
                return;

            this.DocumentId = shelf.DocumentId;
            this.TimeStamp = shelf.TimeStamp;

            this.Title = shelf.Title;
            this.Priority = shelf.Priority;
            this.UpdateTime = shelf.UpdateTime;

            var iBook = new Worker.Books.Book.Index(parentDocumentId: id);
            var iShelf = new Worker.Books.Shelf.Index(parentDocumentId: id);
            if (iBook.List.Count() == 0 && iShelf.List.Count() == 0)
                this.IsNoChild = true;

            this._isExist = true;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }

        public bool IsNoChild { get; set; }





        [Display(Name = "书架名")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}