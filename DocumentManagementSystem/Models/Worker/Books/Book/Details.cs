using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Book
{
    public class Details
    {
        public Details(Guid id)
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);
            this.Initial(target);
        }

        public Details(object origin)
        {
            this.Initial(origin);
        }

        private void Initial(object origin)
        {
            if (origin == null)
            {
                this._isExist = false;
                return;
            }
            else
                this._isExist = true;

            var target = (Domains.Entities.Document)origin;

            if ( !target.IsBookBook)
            {
                this._isExist = false;
                return;
            }

            this.DocumentId = target.DocumentId;
            this.ParentDocumentId = target.ParentDocumentId.Value;

            this.Title = target.Title;
            this.Priority = target.Priority;
            this.IsChecked = target.IsChecked;

            this.UpdateTime = target.UpdateTime;
            this.TimeStamp = BitConverter.ToInt64(target.TimeStamp, 0);
        }





        public bool _isExist { get; set; }





        public Guid DocumentId { get; set; }

        public Guid ParentDocumentId { get; set; }





        public string Title { get; set; }

        public int? Priority { get; set; }

        public bool IsChecked { get; set; }





        public DateTime UpdateTime { get; set; }

        public long TimeStamp { get; set; }
    }
}