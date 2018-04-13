using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books.Details
{
    public class Concrete
    {
        public Concrete()
        {

        }





        public Guid DocumentId { get; set; }





        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }

        [Display(Name = "书签")]
        public bool IsBookmarked { get; set; }
    }
}