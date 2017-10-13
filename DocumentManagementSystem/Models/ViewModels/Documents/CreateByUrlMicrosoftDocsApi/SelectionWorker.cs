using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Documents.CreateByUrlMicrosoftDocsApi
{
    public class SelectionWorker
    {
        public SelectionWorker(CreateByUrlMicrosoftDocsApi targetV)
        {
            this.NodeNameParsingMode = new System.Web.Mvc.SelectList(
                new List<System.Web.Mvc.SelectListItem>
                {
                    new System.Web.Mvc.SelectListItem {Text="MicrosoftDocsApiType",Value="MicrosoftDocsApiType" },
                    new System.Web.Mvc.SelectListItem {Text="MicrosoftDocsApiMember",Value="MicrosoftDocsApiMember" },
                }, "Value", "Text", targetV.NodeNameParsingMode);
        }





        public System.Web.Mvc.SelectList NodeNameParsingMode { get; set; }
    }
}