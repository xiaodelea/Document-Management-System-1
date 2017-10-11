using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.CreateByUrlMicrosoftDocsApi
{
    public class CreateByUrlMicrosoftDocsApi
    {
        public CreateByUrlMicrosoftDocsApi(Guid? parentDocumentId, string url)
        {
            this.ParentDocumentId = parentDocumentId;
            this.Url = url;
        }

        public CreateByUrlMicrosoftDocsApi()
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