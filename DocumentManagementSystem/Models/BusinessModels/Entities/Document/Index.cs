using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Entities.Document
{
    public class Index
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="parentDocumentId">null也纳入筛选。</param>
        /// <param name="titlePart"></param>
        /// <param name="isChecked"></param>
        /// <param name="page"></param>
        /// <param name="perpage"></param>
        public Index(Guid? documentId, Guid? parentDocumentId, string titlePart, bool? isChecked, int page, int perpage)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var query = db.Documents.AsQueryable();

            query = query.Where(c => c.IsBook);

            if (documentId.HasValue)
                query = query.Where(c => c.DocumentId == documentId);
            if (parentDocumentId.HasValue)
                query = query.Where(c => c.ParentDocumentId == parentDocumentId);
            else
                query = query.Where(c => c.ParentDocumentId == null);
            if (!string.IsNullOrWhiteSpace(titlePart))
            {
                titlePart = titlePart.Trim();
                query = query.Where(c => c.Title.Contains(titlePart));
            }
            if (isChecked.HasValue)
                query = query.Where(c => c.IsChecked == isChecked);

            this.Count = query.Count();

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);
            var queryCurrentPage = queryOrdered.Skip((page - 1) * perpage).Take(perpage);

            this.List = queryCurrentPage.ToList().Select(c => new Details(c)).ToList();
        }





        public int Count { get; set; }

        public List<Details> List { get; set; }
    }
}