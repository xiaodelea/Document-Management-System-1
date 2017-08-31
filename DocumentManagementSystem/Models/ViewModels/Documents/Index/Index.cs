using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Documents.Index
{
    /// <summary>
    /// 文档-列表。
    /// </summary>
    public class Index
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <remarks>无需参数，获取所有根文档。</remarks>
        public Index()
        {
            var db = new Models.Domains.Entities.DMsDbContext();

            var query = db.Documents.AsQueryable();
            query = query.Where(c => c.ParentDocumentId == null);

            var queryOrdered = query.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId);

            var list = queryOrdered.ToList();

            this.List = list.Select(c => new Item(c)).ToList();
        }





        /// <summary>
        /// 文档项。
        /// </summary>
        public List<Item> List { get; set; }
    }
}