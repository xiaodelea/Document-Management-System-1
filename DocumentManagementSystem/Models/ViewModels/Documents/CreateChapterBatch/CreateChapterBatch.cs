using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.CreateChapterBatch
{
    public class CreateChapterBatch
    {
        public CreateChapterBatch(Guid documentId, string input)
        {
            this.DocumentId = documentId;
            this.Input = input;
        }

        public CreateChapterBatch(Guid documentId)
        {
            this.DocumentId = documentId;
        }

        public CreateChapterBatch()
        {

        }





        public Guid DocumentId { get; set; }

        [Required]
        [Display(Name = "章节目录全文")]
        public string Input { get; set; }





        public List<Models.Domains.Entities.Chapter> GetReturnList()
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var document = db.Documents.Find(this.DocumentId);
            int maxPriority;
            if (document.Chapters.Count() == 0)
                maxPriority = 0;
            else
                maxPriority = document.Chapters.Max(c => c.Priority);

            var listInput = new List<string>(this.Input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries));
            var listChapter = new List<Models.Domains.Entities.Chapter>();

            foreach (var itemInput in listInput)
            {
                var itemChapter = new Models.Domains.Entities.Chapter();

                itemChapter.ChapterId = Guid.NewGuid();
                itemChapter.DocumentId = this.DocumentId;

                itemChapter.ChapterName = itemInput;
                itemChapter.Priority = ++maxPriority;

                itemChapter.UpdateTime = DateTime.Now;

                listChapter.Add(itemChapter);
            }

            return listChapter;
        }
    }
}