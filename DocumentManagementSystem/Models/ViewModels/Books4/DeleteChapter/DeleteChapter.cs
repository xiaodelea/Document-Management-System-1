using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.DeleteChapter
{
    public class DeleteChapter
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        public Guid? ReturnDocumentIdId { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Chapter.Delete
            {
                DocumentId = this.DocumentId,
                TimeStamp = this.TimeStamp,
            };

            var result = b.Save();

            if (result.Result)
                this.ReturnDocumentIdId = b.ReturnDocumentIdId.Value;

            return result;
        }
    }
}