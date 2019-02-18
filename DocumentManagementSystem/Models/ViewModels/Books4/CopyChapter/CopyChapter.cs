using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.CopyChapter
{
    public class CopyChapter
    {
        public Guid PasteDocumentId { get; set; }

        [Required]
        public Guid? CopyDocumentId { get; set; }





        public Worker.ValidateResult Save()
        {
            var clone = new Worker.Books.Chapter.Clone
            {
                PasteDocumentId = this.PasteDocumentId,
                CopyDocumentId = this.CopyDocumentId.Value,
            };

            var result = clone.Save();

            return result;
        }
    }
}