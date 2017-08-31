using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.Details
{
    /// <summary>
    /// 文档-明细-子文档项。
    /// </summary>
    public class ItemChildDocument
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="document">域对象。</param>
        /// <remarks>进行字段赋值。</remarks>
        public ItemChildDocument(Models.Domains.Entities.Document document)
        {
            this.DocumentId = document.DocumentId;

            this.NodeName = document.NodeName;
            this.Priority = document.Priority;
            this.IsChecked = document.IsChecked;
            this.IsNoted = document.IsNoted;
            this.IsGetAllChildren = document.IsGetAllChildren;
            this.IsHasRemarks = !string.IsNullOrEmpty(document.Remarks);
        }





        /// <summary>
        /// 文档ID。
        /// </summary>
        public Guid DocumentId { get; set; }





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

        /// <summary>
        /// 是否有笔记。
        /// </summary>
        [Display(Name = "笔记")]
        public bool IsNoted { get; set; }

        /// <summary>
        /// 是否已获取全部子节点。
        /// </summary>
        [Display(Name = "子节点")]
        public bool IsGetAllChildren { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Display(Name = "备注")]
        public bool IsHasRemarks { get; set; }
    }
}