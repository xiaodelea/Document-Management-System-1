using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HtmlAgilityPackExtension;

namespace DocumentManagementSystem.Models.BusinessModels.PageContentSolver
{
    public class MicrosoftDocsChapters : Base
    {
        public MicrosoftDocsChapters(string url, Guid documentId) : base(url)
        {
            this.DocumentId = documentId;
        }





        public Guid DocumentId { get; set; }





        public override bool GetPage()
        {
            try
            {
                this.SourceText = Models.BusinessModels.Communication.HTTPCommunicator.HttpGetString(this.Url, null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool ParsePage()
        {
            this.Document = new Models.Domains.Entities.Document();

            var DOM = new HtmlAgilityPack.HtmlDocument();
            DOM.LoadHtml(this.SourceText);

            try
            {
                var div = DOM.GetElementbyId("main");
                var h2s = div.MyChildNodeFilter("h2");

                var i = 1;

                foreach (var h2 in h2s)
                {
                    if (h2.Attributes["class"].Value == "hiddenAnchor")
                        continue;

                    var name = h2.InnerText;

                    if (string.IsNullOrEmpty(name))
                        continue;

                    var chapter = new Models.Domains.Entities.Chapter();
                    chapter.ChapterId = Guid.NewGuid();
                    chapter.DocumentId = this.DocumentId;
                    chapter.ChapterName = name;
                    chapter.Priority = i++;
                    chapter.UpdateTime = DateTime.Now;

                    this.Document.Chapters.Add(chapter);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public override Models.Domains.Entities.Document GetReturn()
        {
            return this.Document;
        }

        public List<Models.Domains.Entities.Chapter> GetChapters()
        {
            return this.Document.Chapters;
        }
    }
}