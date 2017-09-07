using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Documents.CreateByUrl
{
    public class SelectionWorker
    {
        public SelectionWorker(CreateByUrl targetV)
        {
            this.CodesOfSolver = new System.Web.Mvc.SelectList(
               new List<System.Web.Mvc.SelectListItem>
               {
                    new System.Web.Mvc.SelectListItem {Text="MicrosoftDocs",Value="MicrosoftDocs" }
               }, "Value", "Text", targetV.CodeOfSolver);
        }





        public System.Web.Mvc.SelectList CodesOfSolver { get; set; }
    }
}