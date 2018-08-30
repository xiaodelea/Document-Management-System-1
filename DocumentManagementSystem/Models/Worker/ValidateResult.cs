using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker
{
    public class ValidateResult
    {
        public ValidateResult(bool result, params string[] i2)
        {
            this.Result = result;
            this.ValidateErrors = new List<ValidateError>();
            if (i2 == null)
                return;
            while (i2.Length >= 2)
            {
                this.ValidateErrors.Add(new ValidateError(i2[0], i2[1]));
                i2 = i2.Skip(2).ToArray();
            }
        }





        public bool Result { get; set; }

        public List<ValidateError> ValidateErrors { get; set; }





        public override string ToString()
        {
            var builder = new System.Text.StringBuilder();
            foreach (var error in this.ValidateErrors)
                builder.Append(error.Description + ". ");
            return builder.ToString();
        }
    }
}