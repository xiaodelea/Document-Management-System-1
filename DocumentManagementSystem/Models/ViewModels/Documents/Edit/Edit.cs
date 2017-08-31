using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.Edit
{
    /// <summary>
    /// 文档-编辑。
    /// </summary>
    public class Edit
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="document">域对象。</param>
        public Edit(Models.Domains.Entities.Document document)
        {
            this.DocumentId = document.DocumentId;
            this.ParentDocumentId = document.ParentDocumentId;

            this.Title = document.Title;
            this.NodeName = document.NodeName;
            this.Priority = document.Priority;
            this.Url = document.Url;
            this.DocumentTime = document.DocumentTime;
            this.Remarks = document.Remarks;
        }

        /// <summary>
        /// 初始化。
        /// </summary>
        public Edit()
        {

        }





        /// <summary>
        /// 文档ID。
        /// </summary>
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
        /// URL。
        /// </summary>
        [Url]
        public string Url { get; set; }

        /// <summary>
        /// 文档日期。
        /// </summary>
        [Display(Name = "文档日期")]
        public DateTime? DocumentTime { get; set; }

        /// <summary>
        /// 备注。
        /// </summary>
        [Display(Name = "备注")]
        public string Remarks { get; set; }





        /// <summary>
        /// 获取域对象。
        /// </summary>
        /// <param name="document">源域对象。将被修改。</param>
        public void GetReturn(Models.Domains.Entities.Document document)
        {
            document.Title = this.Title;
            document.NodeName = this.NodeName;
            document.Priority = this.Priority;
            document.Url = this.Url;
            document.DocumentTime = this.DocumentTime;
            document.Remarks = this.Remarks;
        }
    }
}