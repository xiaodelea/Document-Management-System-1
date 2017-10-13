using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.CreateByUrlMicrosoftDocsApi
{
    public class CreateByUrlMicrosoftDocsApi
    {
        public CreateByUrlMicrosoftDocsApi(Guid? parentDocumentId, string url, string nodeNameParsingMode = null)
        {
            this.ParentDocumentId = parentDocumentId;
            this.Url = url;
            this.NodeNameParsingMode = nodeNameParsingMode;
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

        public string NodeNameParsingMode { get; set; }
    }
}