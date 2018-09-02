using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.EditAddition
{
    public class EditAddition
    {
        public EditAddition()
        {

        }

        public EditAddition(Guid additionId)
        {
            var b = new Worker.Books.Addition.Details(additionId);

            this._isExist = b._isExist;
            if (!b._isExist)
                return;

            this.AdditionId = b.AdditionId;
            this.TimeStamp = b.TimeStamp;

            this.Description = b.Description;

            this.DocumentId = b.DocumentId;
        }





        public bool _isExist { get; set; }





        public Guid AdditionId { get; set; }

        public long TimeStamp { get; set; }





        [Display(Name = "说明")]
        public string Description { get; set; }





        public Guid? DocumentId { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Addition.Edit
            {
                AdditionId = this.AdditionId,
                TimeStamp = this.TimeStamp,
                Description = this.Description,
            };

            var result = b.Save();

            if (result.Result)
                this.DocumentId = b.DocumentId.Value;

            return result;
        }
    }
}