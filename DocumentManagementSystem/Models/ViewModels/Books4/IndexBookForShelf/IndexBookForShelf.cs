using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexBookForShelf
{
    public class IndexBookForShelf
    {
        public IndexBookForShelf(Guid parentDocumentId)
        {
            var b = new Worker.Books.Book.Index(parentDocumentId: parentDocumentId, order: 1);

            this.List = b.List.Select(c => new Item(c)).ToList();
        }





        public List<Item> List { get; set; }
    }
}