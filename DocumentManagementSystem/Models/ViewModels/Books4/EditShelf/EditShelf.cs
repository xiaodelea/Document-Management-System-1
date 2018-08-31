using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.EditShelf
{
    public class EditShelf
    {
        public EditShelf()
        {

        }

        public EditShelf(Guid documentId)
        {
            var b = new Worker.Books.Shelf.Details(documentId);

            this._isExist = b._isExist;
            if (!b._isExist)
                return;

            this.DocumentId = b.DocumentId;
            this.TimeStamp = b.TimeStamp;

            this.Title = b.Title;
            this.Priority = b.Priority;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        [Display(Name = "名称")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "优先级")]
        public int? Priority { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Shelf.Edit
            {
                DocumentId = this.DocumentId,
                TimeStamp = this.TimeStamp,
                Title = this.Title,
                Priority = this.Priority.Value,
            };

            var result = b.Save();

            return result;
        }
    }
}