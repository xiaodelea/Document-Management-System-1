using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.Details
{
    /// <summary>
    /// 文档-详情-章节子项
    /// </summary>
    public class ItemChapter
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        public ItemChapter(Models.Domains.Entities.Chapter target)
        {
            this.ChapterName = target.ChapterName;
            this.Priority = target.Priority;
        }





        /// <summary>
        /// 章节名称。
        /// </summary>
        [Display(Name = "章节名称")]
        public string ChapterName { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        [Display(Name = "序号")]
        public int Priority { get; set; }
    }
}