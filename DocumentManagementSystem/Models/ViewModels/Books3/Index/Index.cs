using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books3.Index
{
    public class Index
    {
        public Index(Route route)
        {
            //var b = new Models.BusinessModels.Entities.Document.Index(null, route.ParentDocumentId, route.TitlePart, route.IsChecked, route.Page, route.PerPage);

            this.List = new List<Item>();

            this.Route = route;
            this.Route.Count = route.Count;

            this.Solve(null, route.TitlePart, route.IsChecked, 0);
        }





        public Route Route { get; set; }

        public List<Item> List { get; set; }





        public void Solve(Guid? parentDocumentId, string titlePart, bool? isChecked, int indent)
        {
            var i = new Models.BusinessModels.Entities.Document.Index(null, parentDocumentId, titlePart, isChecked, 1, int.MaxValue);

            foreach (var d in i.List)
            {
                if (d.IsBookshelf || d.IsBookRoot)
                {
                    this.List.Add(new Item(d, indent));

                    this.Solve(d.DocumentId, titlePart, isChecked, indent + 1);
                }
            }
        }
    }
}