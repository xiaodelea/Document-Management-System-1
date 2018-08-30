using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Books3.Index
{
    public class Item
    {
        public Item(Guid documentId, int indent = 0)
        {
            var d = new Models.BusinessModels.Entities.Document.Details(documentId);

            this.Initial(d, indent);
        }

        public Item(Models.BusinessModels.Entities.Document.Details d, int indent = 0)
        {
            this.Initial(d, indent);
        }

        private void Initial(Models.BusinessModels.Entities.Document.Details d, int indent = 0)
        {
            if (!d._isExist)
            {
                this._isExist = false;
                return;
            }
            else
                this._isExist = true;

            this.DocumentId = d.DocumentId;

            this.Title = /*new string('　', indent) + */d.Title;
            this.Priority = d.Priority;
            this.IsChecked = d.IsChecked;

            this.IsBookshelf = d.IsBookshelf;
            this.IsBookRoot = d.IsBookRoot;
            this.Indent = indent;

            this.TimeStamp = d.TimeStamp;
        }





        public bool _isExist { get; set; }





        public Guid? DocumentId { get; set; }





        [Display(Name = "标题")]
        public string Title { get; set; }

        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        [Display(Name = "查看")]
        public bool IsChecked { get; set; }





        public bool IsBookshelf { get; set; }

        public bool IsBookRoot { get; set; }

        /// <summary>
        /// 缩进量。
        /// </summary>
        public int Indent { get; set; }





        public byte[] TimeStamp { get; set; }
    }
}