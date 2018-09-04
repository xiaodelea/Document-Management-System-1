using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.MoveChapter
{
    public class MoveChapter
    {
        public MoveChapter()
        {

        }

        public MoveChapter(Guid documentId)
        {
            var b = new Worker.Books.Chapter.Details(documentId);

            this._isExist = b._isExist;
            if (!b._isExist)
                return;

            this.DocumentId = b.DocumentId;
            this.TimeStamp = b.TimeStamp;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        [Display(Name = "书籍或章节ID")]
        public Guid NewParentDocumentId { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Chapter.Move
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