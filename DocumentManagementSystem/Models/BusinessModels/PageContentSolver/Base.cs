using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.PageContentSolver
{
    public abstract class Base
    {
        public Base(string url)
        {
            this.Url = url;
        }





        public string Url { get; set; }

        public string SourceText { get; set; }

        protected Models.Domains.Entities.Document Document { get; set; }





        public abstract bool GetPage();

        public abstract bool ParsePage();

        public abstract Models.Domains.Entities.Document GetReturn();
    }
}