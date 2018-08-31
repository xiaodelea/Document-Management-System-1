using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.CreateAddition
{
    public class CreateAddition
    {
        public Guid DocumentId { get; set; }

        [Required]
        [Display(Name = "类别")]
        public Guid? AdditionCategoryId { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Addition.Create();

            b.DocumentId = this.DocumentId;
            b.AdditionCategoryId = this.AdditionCategoryId.Value;
            b.Description = this.Description;

            var result = b.Save();

            return result;
        }
    }
}