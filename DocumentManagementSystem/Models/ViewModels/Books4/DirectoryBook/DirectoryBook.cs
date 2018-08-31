using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.DirectoryBook
{
    public class DirectoryBook
    {
        public DirectoryBook(Guid documentId)
        {
            this.List = new List<Item>();

            var book = new Worker.Books.Book.Details(documentId);
            if (!book._isExist)
                return;

            var chapters = new Worker.Books.Chapter.Index(parentDocumentId: documentId);

            this.AddChapter(chapters, 0);
        }

        private void AddChapter(Worker.Books.Chapter.Index i, int level)
        {
            foreach (var chapter in i.List)
            {
                this.List.Add(new Item(chapter, level));

                var subChapter = new Worker.Books.Chapter.Index(parentDocumentId: chapter.DocumentId);

                this.AddChapter(subChapter, level + 1);
            }
        }





        public List<Item> List { get; set; }
    }
}