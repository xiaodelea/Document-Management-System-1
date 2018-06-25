using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels
{
    public class RouteBase
    {
        public RouteBase(int page, int perPage, int count)
        {
            this.Page = page;
            this.PerPage = perPage;
            this.Count = count;

            if (this.Page <= 0)
                this.Page = 1;
            if (this.PerPage <= 0)
                this.PerPage = 20;
        }





        public int Page { get; set; }

        public int PerPage { get; set; }

        public int Count { get; set; }





        public int MaxPage
        {
            get
            {
                return this.Count == 0 ? 0 : (int)Math.Ceiling((double)this.Count / this.PerPage);
            }
        }
    }
}