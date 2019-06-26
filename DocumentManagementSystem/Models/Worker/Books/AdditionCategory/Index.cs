using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.AdditionCategory
{
    public class Index
    {
        public Index(int page = 1, int perpage = int.MaxValue)
        {
            var db = new Models.Domains.MySQL.Entities.DMsDbContext();
            var query = db.AdditionCategories.AsQueryable();

            var queryOrdered = query.OrderBy(c => c.Name);
            var queryCurrentPage = queryOrdered.Skip((page - 1) * perpage).Take(perpage);

            this.List = queryCurrentPage.ToList().Select(c => new Details(c)).ToList();
        }





        public int Count { get; set; }

        public List<Details> List { get; set; }
    }
}