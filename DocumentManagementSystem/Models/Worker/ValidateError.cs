using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker
{
    public class ValidateError
    {
        public ValidateError(string paraName, string description)
        {
            this.ParaName = paraName;
            this.Description = description;
        }





        public readonly string ParaName;

        public readonly string Description;
    }
}