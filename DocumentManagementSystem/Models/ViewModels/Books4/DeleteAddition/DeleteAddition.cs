using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.DeleteAddition
{
    public class DeleteAddition
    {
        public Guid AdditionId { get; set; }

        public long TimeStamp { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Addition.Delete
            {
                AdditionId = this.AdditionId,
                TimeStamp = this.TimeStamp,
            };

            var result = b.Save();

            return result;
        }
    }
}