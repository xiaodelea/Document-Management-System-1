using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books4.IndexBook
{
    public class Route : RouteBase
    {
        public Route(string titlePart, bool? isChecked, int page, int perpage, int count) : base(page, perpage, count)
        {
            this.TitlePart = titlePart;
            this.IsChecked = isChecked;
        }

        public Route() : base(0, 0, 0)
        {

        }





        [Display(Name = "标题")]
        public string TitlePart { get; set; }

        [Display(Name = "查阅")]
        public bool? IsChecked { get; set; }





        public Route GetRoute(int page)
        {
            return new Route(this.TitlePart, this.IsChecked, page, this.PerPage, this.Count);
        }
    }
}