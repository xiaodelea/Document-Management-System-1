using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.ListShelfForShelf
{
    public class ListShelfForShelf
    {
        public ListShelfForShelf(Guid documentId)
        {
            var shelf = new Worker.Books.Shelf.Details(documentId);

            this.List = new List<Item>();

            if (shelf.ParentDocumentId.HasValue)
                this.AddPrioShelf(new Worker.Books.Shelf.Details(shelf.ParentDocumentId.Value));

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