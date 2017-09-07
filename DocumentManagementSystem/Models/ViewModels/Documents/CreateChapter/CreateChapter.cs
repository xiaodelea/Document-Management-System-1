using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.CreateChapter
{
    public class CreateChapter
    {
        public CreateChapter(Guid documentId)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var document = db.Documents.Find(documentId);

            this.DocumentId = documentId;
            if (document.Chapters.Count() == 0)
                this.Priority = 1;
            else
                this.Priority = document.Chapters.Max(c => c.Priority) + 1;
        }

        public CreateChapter()
        {

        }





        public Guid DocumentId { get; set; }





        [Required]
        [Display(Name = "章节名称")]
        public string ChapterName { get; set; }

        [Display(Name = "序号")]
        public int Priority { get; set; }





        /// <summary>
        /// 获取域对象。
        /// </summary>
        /// <returns>域对象。</returns>
        public Models.Domains.Entities.Chapter GetReturn()
        {
            var target = new Models.Domains.Entities.Chapter();

            target.ChapterId = Guid.NewGuid();
            target.DocumentId = this.DocumentId;

            target.ChapterName = this.ChapterName.Trim();
            target.Priority = this.Priority;

            target.UpdateTime = DateTime.Now;

            return target;
        }
    }
}