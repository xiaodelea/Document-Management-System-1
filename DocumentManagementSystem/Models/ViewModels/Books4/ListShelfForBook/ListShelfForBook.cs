using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.ListShelfForBook
{
    public class ListShelfForBook
    {
        public ListShelfForBook(Guid documentId)
        {
            var book = new Worker.Books.Book.Details(documentId);

            this.List = new List<Item>();
            this.AddPrioShelf(new Worker.Books.Shelf.Details(book.ParentDocumentId));

            this.List.Reverse();
        }

        private void AddPrioShelf(Worker.Books.Shelf.Details shelf)
        {
            this.List.Add(new Item(shelf));

            if (shelf.ParentDocumentId.HasValue)
                this.AddPrioShelf(new Worker.Books.Shelf.Details(shelf.ParentDocumentId.Value));
        }





        public List<Item> List { get; set; }
    }
}