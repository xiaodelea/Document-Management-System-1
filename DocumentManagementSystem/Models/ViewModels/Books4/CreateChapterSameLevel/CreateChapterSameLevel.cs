using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.CreateChapterSameLevel
{
    public class CreateChapterSameLevel
    {
        public CreateChapterSameLevel()
        {

        }

        public CreateChapterSameLevel(Guid currentDocumentId)
        {
            this.CurrentDocumentId = currentDocumentId;

            var currentDocument = new Worker.Books.Chapter.Details(currentDocumentId);

            var i = new Worker.Books.Chapter.Index(parentDocumentId: currentDocument.ParentDocumentId);
            if (i.List.Count > 0)
            {
                var max = i.List.Max(c => c.Priority);
                if (max.HasValue)
                    this.Priority = max.Value + 1;
            }
            else
            {
                this.Priority = 1;
            }
        }





        public Guid CurrentDocumentId { get; set; }

        [Display(Name = "名称")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int Priority { get; set; }





        public Guid? DocumentId { get; set; }





        public Worker.ValidateResult Save()
        {
            var currentDocument = new Worker.Books.Chapter.Details(this.CurrentDocumentId);

            var b = new Worker.Books.Chapter.Create
            {
                ParentDocumentId = currentDocument.ParentDocumentId,
                Title = this.Title,
                Priority = this.Priority
            };

            var result = b.Save();

            if (result.Result)
                this.DocumentId = b.DocumentId;

            return result;
        }
    }
}