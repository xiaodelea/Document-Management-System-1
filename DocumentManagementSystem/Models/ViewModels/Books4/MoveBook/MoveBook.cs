using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.MoveBook
{
    public class MoveBook
    {
        public MoveBook()
        {

        }

        public MoveBook(Guid documentId)
        {
            var b = new Worker.Books.Book.Details(documentId);

            this._isExist = b._isExist;
            if (!b._isExist)
                return;

            this.DocumentId = b.DocumentId;
            this.TimeStamp = b.TimeStamp;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        [Display(Name = "书架ID")]
        public Guid NewParentDocumentId { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Book.Move
            {
                DocumentId = this.DocumentId,
                TimeStamp = this.TimeStamp,
                NewParentDocumentId = this.NewParentDocumentId,
            };

            var result = b.Save();

            return result;
        }
    }
}