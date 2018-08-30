using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books3.Index
{
    public class Route : RouteBase
    {
        public Route(Guid? parentDocumentId, string titlePart, bool? isChecked, int page, int perpage, int count) : base(page, perpage, count)
        {
            this.ParentDocumentId = parentDocumentId;
            this.TitlePart = titlePart;
            this.IsChecked = isChecked;
        }

        public Route() : base(0, 0, 0)
        {

        }





        [Display(Name = "父节点")]
        public Guid? ParentDocumentId { get; set; }

        [Display(Name = "标题")]
        public string TitlePart { get; set; }

        [Display(Name = "查阅")]
        public bool? IsChecked { get; set; }





        public Route GetRoute(int page)
        {
            return new Route(this.ParentDocumentId, this.TitlePart, this.IsChecked, page, this.PerPage, this.Count);
        }
    }
}