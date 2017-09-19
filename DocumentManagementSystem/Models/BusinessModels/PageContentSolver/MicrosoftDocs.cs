using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HtmlAgilityPackExtension;

namespace DocumentManagementSystem.Models.BusinessModels.PageContentSolver
{
    public class MicrosoftDocs : Base
    {
        public MicrosoftDocs(string url, string nodeName) : base(url)
        {
            this.NodeName = nodeName;
        }

        public MicrosoftDocs(Models.ViewModels.Documents.CreateByUrlMicrosoftDocs.CreateByUrlMicrosoftDocs targetV) : base(targetV.Url)
        {
            this.NodeName = targetV.NodeName;
            this.MinutesToRead = targetV.MinutesToRead;
        }





        public string NodeName { get; set; }

        public int? MinutesToRead { get; set; }





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
                var div_main = DOM.GetElementbyId("main");
                var div_main_h1 = div_main.MyGetNode("h1", 1);
                var div_main_div1 = div_main.MyGetNode("div", "class", "metadata loading", 1);
                var div_main_div1_div1 = div_main_div1.MyGetNode("div", 1);
                var div_main_div1_div1_time = div_main_div1_div1.MyGetNode("time", "class", "date", 1);

                this.Document.Title = div_main_h1.InnerText;
                this.Document.NodeName = this.NodeName;
                this.Document.DocumentTime = DateTime.Parse(div_main_div1_div1_time.Attributes["datetime"].Value);
                this.Document.UpdateTimeForHTTPGet = DateTime.Now;
                this.Document.Url = this.Url;
                this.Document.MinutesToRead = this.MinutesToRead;
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