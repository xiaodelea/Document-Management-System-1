using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HtmlAgilityPackExtension;

namespace DocumentManagementSystem.Models.BusinessModels.PageContentSolver
{
    public class MicrosoftDocsApi : Base
    {
        public MicrosoftDocsApi(string url) : base(url)
        {

        }





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
                //var meta = DOM.DocumentNode.MyGetNode("html",1).MyGetNode("head", 1).MyGetNode("meta", "name", "APIName", 1);
                var div_main = DOM.GetElementbyId("main");
                var div_main_h1 = div_main.MyGetNode("h1", 1);

                this.Document.DocumentId = Guid.NewGuid();
                //this.Document.ParentDocumentId
                this.Document.Title = div_main_h1.InnerText;
                this.Document.Title = System.Web.HttpUtility.HtmlDecode(this.Document.Title);
                this.Document.Title = System.Text.RegularExpressions.Regex.Replace(this.Document.Title, @"\s+", " ").Trim();
                //this.Document.NodeName = meta.Attributes["content"].Value;
                //this.Document.NodeName = System.Web.HttpUtility.HtmlDecode(this.Document.NodeName);
                //this.Document.Priority
                this.Document.UpdateTimeForHTTPGet = DateTime.Now;
                this.Document.Url = this.Url;
                this.Document.UpdateTime = DateTime.Now;

                //处理Chapters
                var h2s= div_main.Descendants("h2");
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
                    chapter.DocumentId = this.Document.DocumentId;
                    chapter.ChapterName = name;
                    chapter.Priority = i++;
                    chapter.UpdateTime = DateTime.Now;

                    this.Document.Chapters.Add(chapter);
                }

                this.Document.IsGetAllChapters = true;
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
    }
}