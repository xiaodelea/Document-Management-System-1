using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.Details
{
    /// <summary>
    /// 文档-详情。
    /// </summary>
    public class Details
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="target">源域对象。</param>
        public Details(Models.Domains.Entities.Document target)
        {
            this.DocumentId = target.DocumentId;
            this.ParentDocumentId = target.ParentDocumentId;

            this.Title = target.Title;
            this.NodeName = target.NodeName;
            this.Priority = target.Priority;
            this.IsChecked = target.IsChecked;
            //this.IsNoted = target.IsNoted;
            this.IsGetAllChildren = target.IsGetAllChildren;
            this.Url = target.Url;
            this.DocumentTime = target.DocumentTime;
            this.Remarks = target.Remarks;
            this.MinutesToRead = target.MinutesToRead;
            this.TotalMinutesToRead = target.TotalMinutesToRead;
            this.IsBookmarked = target.IsBookmarked;

            this.ListChildDocuments = target.ChildDocuments.OrderBy(c => c.Priority).ThenBy(c => c.DocumentId).Select(c => new ItemChildDocument(c)).ToList();

            this.ListChapters = target.Chapters.OrderBy(c => c.Priority).ThenBy(c => c.ChapterId).Select(c => new ItemChapter(c)).ToList();

            //this.DocumentLink = new List<Domains.Entities.Document>();
            //var current = target;
            //do
            //{
            //    current = current.ParentDocument;

            //    if (current != null)
            //    {
            //        this.DocumentLink.Add(current);
            //    }
            //} while (current != null);
            //this.DocumentLink.Reverse();
        }





        /// <summary>
        /// 文档ID。
        /// </summary>
        [Display(Name = "ID")]
        public Guid DocumentId { get; set; }

        /// <summary>
        /// 父文档文档ID。
        /// </summary>
        public Guid? ParentDocumentId { get; set; }





        /// <summary>
        /// 标题。
        /// </summary>
        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }

        /// <summary>
        /// 节点名称。
        /// </summary>
        [Required]
        [Display(Name = "节点名称")]
        public string NodeName { get; set; }

        /// <summary>
        /// 优先级。
        /// </summary>
        [Display(Name = "优先级")]
        public int? Priority { get; set; }

        /// <summary>
        /// 是否已查阅。
        /// </summary>
        [Display(Name = "查阅")]
        public bool IsChecked { get; set; }

        ///// <summary>
        ///// 是否有笔记。
        ///// </summary>
        //[Display(Name = "笔记")]
        //public bool IsNoted { get; set; }

        /// <summary>
        /// 是否已获取全部子节点。
        /// </summary>
        [Display(Name = "子节点")]
        public bool IsGetAllChildren { get; set; }

        /// <summary>
        /// URL。
        /// </summary>
        [Url]
        public string Url { get; set; }

        /// <summary>
        /// 文档日期。
        /// </summary>
        [Display(Name = "文档日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DocumentTime { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Display(Name = "备注")]
        public string Remarks { get; set; }

        [Display(Name = "阅读时间")]
        public int? MinutesToRead { get; set; }

        [Display(Name = "累计时间")]
        public int? TotalMinutesToRead { get; set; }

        [Display(Name = "书签")]
        public bool IsBookmarked { get; set; }





        /// <summary>
        /// 子文档集合。
        /// </summary>
        public List<ItemChildDocument> ListChildDocuments { get; set; }

        /// <summary>
        /// 子章节集合。
        /// </summary>
        public List<ItemChapter> ListChapters { get; set; }

        //public List<Models.Domains.Entities.Document> DocumentLink { get; set; }
    }
}