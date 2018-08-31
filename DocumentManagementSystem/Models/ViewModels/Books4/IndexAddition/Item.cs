using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexAddition
{
    public class Item
    {
        public Item(Worker.Books.Addition.Details d)
        {
            if (!d._isExist)
                return;

            this.AdditionId = d.AdditionId;

            this.Name = d.Name;
            this.Description = d.Description;

            this._isExist = true;
        }





        public bool _isExist { get; set; }





        public Guid AdditionId { get; set; }





        public string Name { get; set; }

        public string Description { get; set; }
    }
}