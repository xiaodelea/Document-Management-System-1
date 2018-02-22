using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Services.GetDocument
{
    /// <summary>
    /// 获取单个文档信息。
    /// </summary>
    public class GetDocument
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="document">源域对象。</param>
        public GetDocument(Models.Domains.Entities.Document document)
        {
            this.DocumentId = document.DocumentId;
            //this.ParentDocumentId = document.ParentDocumentId;

            //this.Title = document.Title;
            //this.NodeName = document.NodeName;
            //this.Priority = document.Priority;
            //this.UpdateTimeForHTTPGet = document.UpdateTimeForHTTPGet;
            this.IsChecked = document.IsChecked;
            this.IsNoted = document.IsNoted;
            this.IsGetAllChildren = document.IsGetAllChildren;
            this.IsGetAllChapters = document.IsGetAllChapters;
            this.IsParentGetAllChildren = (document.ParentDocument != null) ? document.ParentDocument.IsGetAllChildren : false;
            //this.Url = document.Url;
            //this.DocumentTime = document.DocumentTime;
            //this.SourceTextMainContain = document.SourceTextMainContain;
            //this.SourceTextMainContainBackup = document.SourceTextMainContainBackup;
            //this.SourceTextHashCode = document.SourceTextHashCode;
            //this.Remarks = document.Remarks;
            //this.UpdateTime = document.UpdateTime;
            this.TotalMinutesToRead = document.TotalMinutesToRead;
            this.IsBookmarked = document.IsBookmarked;
            this.IsFinished = document.IsFinished;
        }





        /// <summary>
        /// 文档ID。
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// 父文档文档ID。
        /// </summary>
        //public Guid? ParentDocumentId { get; set; }





        /// <summary>
        /// 标题。
        /// </summary>
        //public string Title { get; set; }

        /// <summary>
        /// 节点名称。
        /// </summary>
        //public string NodeName { get; set; }





        /// <summary>
        /// 优先级。
        /// </summary>
        //public int? Priority { get; set; }

        /// <summary>
        /// HTTP方式更新数据时间。
        /// </summary>
        //public DateTime UpdateTimeForHTTPGet { get; set; }

        /// <summary>
        /// 是否已查阅。
        /// </summary>
        public bool IsChecked { get; set; }

        /// <summary>
        /// 是否有笔记。
        /// </summary>
        public bool IsNoted { get; set; }

        /// <summary>
        /// 是否已获取全部子节点。
        /// </summary>
        public bool IsGetAllChildren { get; set; }

        public bool IsGetAllChapters { get; set; }

        public bool IsParentGetAllChildren { get; set; }

        ///// <summary>
        ///// 文档日期。
        ///// </summary>
        //public DateTime? DocumentTime { get; set; }

        public int? TotalMinutesToRead { get; set; }

        public bool IsBookmarked { get; set; }

        public bool IsFinished { get; set; }





        /// <summary>
        /// URL。
        /// </summary>
        //public string Url { get; set; }

        /// <summary>
        /// 主体内容源代码。
        /// </summary>
        //public string SourceTextMainContain { get; set; }

        /// <summary>
        /// 主体内容源代码备份。
        /// </summary>
        //public string SourceTextMainContainBackup { get; set; }

        /// <summary>
        /// 主体内容源代码哈希码。
        /// </summary>
        //public string SourceTextHashCode { get; set; }





        /// <summary>
        /// 备注。
        /// </summary>
        //public string Remarks { get; set; }





        //public DateTime UpdateTime { get; set; }
    }
}