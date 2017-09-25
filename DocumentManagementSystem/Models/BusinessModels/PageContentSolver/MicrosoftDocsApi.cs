using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentManagementSystem.Models.Domains.Entities;

namespace DocumentManagementSystem.Models.BusinessModels.PageContentSolver
{
    public class MicrosoftDocsApi : Base
    {
        public MicrosoftDocsApi(string url) : base(url)
        {
        }

        public override bool GetPage()
        {
            throw new NotImplementedException();
        }

        public override Document GetReturn()
        {
            throw new NotImplementedException();
        }

        public override bool ParsePage()
        {
            throw new NotImplementedException();
        }
    }
}