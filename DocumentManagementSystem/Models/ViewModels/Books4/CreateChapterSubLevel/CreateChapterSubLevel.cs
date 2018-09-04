using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.CreateChapterSubLevel
{
    public class CreateChapterSubLevel
    {
        public CreateChapterSubLevel()
        {

        }

        public CreateChapterSubLevel(Guid parentDocumentId)
        {
            this.ParentDocumentId = parentDocumentId;

            var i = new Worker.Books.Chapter.Index(parentDocumentId: parentDocumentId);
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





        public Guid ParentDocumentId { get; set; }

        [Display(Name = "名称")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int Priority { get; set; }





        public Guid? DocumentId { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Chapter.Create
            {
                ParentDocumentId = this.ParentDocumentId,
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