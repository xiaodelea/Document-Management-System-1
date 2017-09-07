using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.CreateByUrlMicrosoftDocs
{
    public class CreateByUrlMicrosoftDocs
    {
        public CreateByUrlMicrosoftDocs(Guid? parentDocumentId, string url)
        {
            this.ParentDocumentId = parentDocumentId;
            this.Url = url;
        }

        public CreateByUrlMicrosoftDocs()
        {

        }





        public Guid? ParentDocumentId { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public string NodeName { get; set; }
    }
}