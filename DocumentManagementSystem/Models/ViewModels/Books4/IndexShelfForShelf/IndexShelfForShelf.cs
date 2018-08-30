using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexShelfForShelf
{
    public class IndexShelfForShelf
    {
        public IndexShelfForShelf(Guid parentDocumentId)
        {
            var shelf = new Worker.Books.Shelf.Index(parentDocumentId: parentDocumentId);

            this.List = shelf.List.Select(c => new Item(c)).ToList();
        }





        public List<Item> List { get; set; }
    }
}