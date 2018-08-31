using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexAddition
{
    public class IndexAddition
    {
        public IndexAddition(Guid documentId)
        {
            var b = new Worker.Books.Addition.Index(documentId: documentId);

            this.List = b.List.Select(c => new Item(c)).ToList();
        }





        public List<Item> List { get; set; }
    }
}