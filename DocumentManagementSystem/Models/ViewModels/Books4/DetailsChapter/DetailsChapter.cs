﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.DetailsChapter
{
    public class DetailsChapter
    {
        public DetailsChapter(Guid id)
        {
            var chapter = new Worker.Books.Chapter.Details(id);
            if (!chapter._isExist)
                return;

            this.DocumentId = chapter.DocumentId;
            this.ParentDocumentId = chapter.ParentDocumentId;
            this.TimeStamp = chapter.TimeStamp;

            this.Title = chapter.Title;
            this.Priority = chapter.Priority;
            this.IsChecked = chapter.IsChecked;
            this.UpdateTime = chapter.UpdateTime;

            var i = new Worker.Books.Chapter.Index(parentDocumentId: id);
            if (i.List.Count() == 0)
                this.IsNoChild = true;

            this._isExist = true;
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public Guid ParentDocumentId { get; set; }

        public long TimeStamp { get; set; }

        public bool IsNoChild { get; set; }





        [Display(Name = "章节名")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }

        [Display(Name = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}