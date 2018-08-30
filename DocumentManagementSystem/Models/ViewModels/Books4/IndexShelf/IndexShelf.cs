using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexShelf
{
    public class IndexShelf
    {
        public IndexShelf()
        {
            var shelf = new Worker.Books.Shelf.Index(isRoot: true);

            this.List = new List<Item>();
            var level = 0;

            this.AddShelf(shelf, level);
        }

        private void AddShelf(Worker.Books.Shelf.Index i, int level)
        {
            foreach (var shelf in i.List)
            {
                this.List.Add(new Item(shelf, level));

                var subShelf = new Worker.Books.Shelf.Index(parentDocumentId: shelf.DocumentId);

                this.AddShelf(subShelf, level + 1);
            }
        }





        public List<Item> List { get; set; }
    }
}