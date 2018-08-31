﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.EditChapter
{
    public class EditChapter
    {
        public EditChapter()
        {

        }

        public EditChapter(Guid documentId)
        {
            var b = new Worker.Books.Chapter.Details(documentId);

            this._isExist = b._isExist;
            if (!b._isExist)
                return;

            this.DocumentId = b.DocumentId;
            this.TimeStamp = b.TimeStamp;

            this.Title = b.Title;
            this.Priority = b.Priority;
            this.IsChecked = b.IsChecked;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public long TimeStamp { get; set; }





        [Display(Name = "名称")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }





        public Worker.ValidateResult Save()
        {
            var b = new Worker.Books.Chapter.Edit
            {
                DocumentId = this.DocumentId,
                TimeStamp = this.TimeStamp,
                Title = this.Title,
                Priority = this.Priority.Value,
                IsChecked = this.IsChecked
            };

            var result = b.Save();

            return result;
        }
    }
}