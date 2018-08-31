using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace DocumentManagementSystem.Models.ViewModels.Books4.CreateAddition
{
    public class SelectionWorker
    {
        public SelectionWorker(CreateAddition v)
        {
            var additionCategory_index = new Models.Worker.Books.AdditionCategory.Index();

            this.AdditionCategories = new SelectList(additionCategory_index.List, "AdditionCategoryId", "Name", v.AdditionCategoryId);
        }





        public SelectList AdditionCategories { get; set; }
    }
}