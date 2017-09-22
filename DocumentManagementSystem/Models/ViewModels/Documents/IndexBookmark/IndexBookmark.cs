using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Documents.IndexBookmark
{
    public class IndexBookmark
    {
        public IndexBookmark()
        {
            var db = new Models.Domains.Entities.DMsDbContext();

            var query = db.Documents.AsQueryable();
            query = query.Where(c => c.IsBookmarked);

            var queryOrdered = query.OrderByDescending(c => c.UpdateTime).ThenBy(c => c.DocumentId);

            var list = queryOrdered.ToList();

            this.List = list.Select(c => new Item(c)).ToList();
        }





        public List<Item> List { get; set; }
    }
}