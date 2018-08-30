using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexBook
{
    public class IndexBook
    {
        public IndexBook(Route route)
        {
            var b = new Worker.Books.Book.Index(page: route.Page, perpage: route.PerPage, titlePart: route.TitlePart, isChecked: route.IsChecked);

            this.Route = route;
            this.Route.Count = b.Count;

            this.List = b.List.Select(c => new Item(c)).ToList();
        }





        public Route Route { get; set; }

        public List<Item> List { get; set; }
    }
}