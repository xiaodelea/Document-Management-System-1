using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Entities.Document
{
    public class Details : Base
    {
        public Details(Guid documentId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(documentId);
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

            var target = (Models.Domains.Entities.Document)origin;

            this.DocumentId = target.DocumentId;

            this.ParentDocumentId = target.ParentDocumentId;

            this.Title = target.Title;
            this.Priority = target.Priority;
            this.IsChecked = target.IsChecked;
            this.Url = target.Url;
            this.Remarks = target.Remarks;
            this.ISBN = target.ISBN;

            this.IsBookshelf = target.IsBook && target.IsAbstract && !target.IsMain;
            this.IsBookRoot = target.IsBook && !target.IsAbstract && target.IsMain;
            this.IsChapterNormal = target.IsBook && !target.IsAbstract && !target.IsMain;
            this.IsChapterMain = target.IsBook && target.IsAbstract && target.IsMain;

            this.TimeStamp = target.TimeStamp;
        }





        public bool _isExist { get; set; }
    }
}