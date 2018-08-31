using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Addition
{
    public class Index
    {
        public Index(int page = 1, int perpage = int.MaxValue, Guid? documentId = null)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Additions.AsQueryable();

            if (documentId.HasValue)
                query = query.Where(c => c.DocumentId == documentId);

            var queryOrdered = query.OrderBy(c => c.AdditionCategory.Name).ThenBy(c => c.Description).ThenBy(c => c.AdditionId);
            var queryCurrentPage = queryOrdered.Skip((page - 1) * perpage).Take(perpage);

            this.List = queryCurrentPage.ToList().Select(c => new Details(c)).ToList();
        }





        public int Count { get; set; }

        public List<Details> List { get; set; }
    }
}