using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books.Index
{
    public class Index
    {
        public Index()
        {
            var db = new Domains.Entities.DMsDbContext();

            var query = db.Documents.Where(c => c.ParentDocumentId == null && ((c.IsBook && c.IsAbstract) || (c.IsBook && c.IsMain)));

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            this.List = new List<Item>();

            this.CreateItems(queryOrdered.ToList(), 0);
        }

        public void CreateItems(List<Domains.Entities.Document> list, int level)
        {
            foreach (var item in list)
            {
                this.List.Add(new Item(item, level));

                this.CreateItems(item.ChildDocuments.Where(c => c.IsBook && c.IsAbstract || c.IsBook && c.IsMain).OrderBy(c => c.Priority).ToList(), level + 1);
            }
        }





        public List<Item> List { get; set; }
    }
}