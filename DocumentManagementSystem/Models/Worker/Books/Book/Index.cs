using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Book
{
    public class Index
    {
        public Index(int page = 1, int perpage = int.MaxValue, Guid? parentDocumentId = null, string titlePart = null, bool? isChecked = null, int? order = 0)
        {
            var db = new Models.Domains.MySQL.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.IsBook && c.IsMain && !c.IsAbstract);

            if (parentDocumentId.HasValue)
                query = query.Where(c => c.ParentDocumentId == parentDocumentId);
            if (!string.IsNullOrWhiteSpace(titlePart))
            {
                titlePart = titlePart.Trim();
                query = query.Where(c => c.Title.Contains(titlePart));
            }
            if (isChecked.HasValue)
                query = query.Where(c => c.IsChecked == isChecked);

            this.Count = query.Count();

            IOrderedQueryable<Domains.MySQL.Entities.Document> queryOrdered;
            if (order == 1)
                queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);
            else
                queryOrdered = query.OrderByDescending(c => c.UpdateTime).ThenBy(c => c.DocumentId);
            var queryCurrentPage = queryOrdered.Skip((page - 1) * perpage).Take(perpage);

            this.List = queryCurrentPage.ToList().Select(c => new Details(c)).ToList();
        }





        public int Count { get; set; }

        public List<Details> List { get; set; }
    }
}