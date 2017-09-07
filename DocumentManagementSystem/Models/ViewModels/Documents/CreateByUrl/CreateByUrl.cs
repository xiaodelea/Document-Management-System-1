using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.CreateByUrl
{
    public class CreateByUrl
    {
        public CreateByUrl(Guid? parentDocumentId)
        {
            this.ParentDocumentId = parentDocumentId;
        }

        public CreateByUrl()
        {

        }





        public Guid? ParentDocumentId { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public string CodeOfSolver { get; set; }
    }
}