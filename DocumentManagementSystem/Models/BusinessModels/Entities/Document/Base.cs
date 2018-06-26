using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Entities.Document
{
    public class Base
    {
        public Guid? DocumentId { get; set; }





        public Guid? ParentDocumentId { get; set; }





        public string Title { get; set; }

        public int? Priority { get; set; }

        public bool IsChecked { get; set; }

        public string Url { get; set; }

        public string Remarks { get; set; }

        public string ISBN { get; set; }





        public bool IsBookshelf { get; set; }

        public bool IsBookRoot { get; set; }

        public bool IsChapterNormal { get; set; }

        public bool IsChapterMain { get; set; }





        public byte[] TimeStamp { get; set; }
    }
}