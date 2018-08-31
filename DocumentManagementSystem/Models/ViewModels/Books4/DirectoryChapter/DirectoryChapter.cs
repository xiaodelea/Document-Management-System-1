using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.DirectoryChapter
{
    public class DirectoryChapter
    {
        public DirectoryChapter(Guid documentId)
        {
            this.List = new List<Item>();

            var chapter = new Worker.Books.Chapter.Details(documentId);
            if (!chapter._isExist)
                return;

            this.AddSilbingChapter(chapter.ParentDocumentId, documentId);

            this.AddParent(chapter.ParentDocumentId, -1);

            this.Solve();
        }

        private void AddSilbingChapter(Guid parentDocumentId, Guid documentId)
        {
            var chapters = new Models.Worker.Books.Chapter.Index(parentDocumentId: parentDocumentId);

            foreach (var chapter in chapters.List)
            {
                this.List.Insert(0, new Item(chapter, 0, chapter.DocumentId == documentId));
            }
        }

        private void AddParent(Guid parentDocumentId, int level)
        {
            var chapter = new Worker.Books.Chapter.Details(parentDocumentId);

            if (chapter._isExist)
            {
                this.List.Add(new Item(chapter, level, false));
                this.AddParent(chapter.ParentDocumentId, level - 1);
            }
            else
            {
                var book = new Worker.Books.Book.Details(parentDocumentId);
                this.List.Add(new Item(book, level));
            }
        }

        private void Solve()
        {
            this.List.Reverse();

            var max = -this.List.First().Level;

            this.List.ForEach(c => c.Level += max);
        }





        public List<Item> List { get; set; }
    }
}