using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.MoveShelf
{
    public class MoveShelf
    {
        public MoveShelf()
        {

        }

        public MoveShelf(Guid documentId)
        {
            var b = new Worker.Books.Shelf.Details(documentId);

            this._isExist = b._isExist;
            if (!b._isExist)
                return;

            this.DocumentId = b.DocumentId;
            this.TimeStamp = b.TimeStamp;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        [Display(Name = "作为根书架")]
        public bool IsRoot { get; set; }

        [Display(Name = "父书架ID")]
        public Guid? NewParentDocumentId { get; set; }





        public Worker.ValidateResult Save()
        {
            if (!this.IsRoot && this.NewParentDocumentId == null)
                return new Worker.ValidateResult(false, "NewParentDocumentId", "必填！");

            var b = new Worker.Books.Shelf.Move
            {
                DocumentId = this.DocumentId,
                TimeStamp = this.TimeStamp,
            };
            if (!this.IsRoot)
                b.NewParentDocumentId = this.NewParentDocumentId.Value;

            var result = b.Save();

            return result;
        }
    }
}