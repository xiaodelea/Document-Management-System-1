﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.SetCheckedBook
{
    public class SetCheckedBook
    {
        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Book.SetChecked
            {
                DocumentId = this.DocumentId,
                TimeStamp = this.TimeStamp,
            };

            var result = b.Save();

            return result;
        }
    }
}