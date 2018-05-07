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

            var query = db.Documents.Where(c => c.ParentDocumentId == null);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var list = queryOrdered.ToList();
            list = list.Where(c => c.IsBookAbstract || c.IsBookMain).ToList();

            this.List = new List<Item>();

            this.CreateItems(list, 0);
        }





        public List<Item> List { get; set; }





        private void CreateItems(List<Domains.Entities.Document> list, int level)
        {
            foreach (var item in list)
            {
                this.List.Add(new Item(item, level));

                this.CreateItems(item.ChildDocuments.Where(c => c.IsBookAbstract || c.IsBookMain).OrderBy(c => c.Priority).ToList(), level + 1);
            }
        }

    }
}