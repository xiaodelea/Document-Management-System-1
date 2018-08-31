﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexChapterForChapter
{
    public class IndexChapterForChapter
    {
        public IndexChapterForChapter(Guid parentDocumentId)
        {
            var chapter = new Worker.Books.Chapter.Index(parentDocumentId: parentDocumentId);

            this.List = chapter.List.Select(c => new Item(c)).ToList();
        }





        public List<Item> List { get; set; }
    }
}