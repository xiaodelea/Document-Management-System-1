using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.ListShelfForBook
{
    public class Item
    {
        public Item(Worker.Books.Shelf.Details d)
        {
            if (!d._isExist)
                return;

            this.DocumentId = d.DocumentId;

            this.Title = d.Title;

            this._isExist = true;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }





        [Display(Name = "子书架名")]
        public string Title { get; set; }
    }
}