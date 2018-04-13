using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Details
{
    public class Main
    {
        public Main()
        {

        }





        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }
    }
}