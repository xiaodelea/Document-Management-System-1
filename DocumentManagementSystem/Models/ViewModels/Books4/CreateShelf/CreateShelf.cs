using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.CreateShelf
{
    public class CreateShelf
    {
        public CreateShelf()
        {

        }

        public CreateShelf(Guid? parentDocumentId)
        {
            this.ParentDocumentId = parentDocumentId;
        }





        public Guid? ParentDocumentId { get; set; }

        [Display(Name = "名称")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int Priority { get; set; }





        public Guid? DocumentId { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Shelf.Create
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