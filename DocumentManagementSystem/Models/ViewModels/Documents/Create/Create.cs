using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.Create
{
    /// <summary>
    /// 文档-新增。
    /// </summary>
    public class Create
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="parentDocumentId">父文档文档ID。留空即为根文档。</param>
        public Create(Guid? parentDocumentId)
        {
            this.ParentDocumentId = parentDocumentId;
        }

        /// <summary>
        /// 初始化。
        /// </summary>
        /// <remarks>默认为根文档。</remarks>
        public Create()
        {

        }





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

        [Display(Name = "阅读时间")]
        public int? MinutesToRead { get; set; }





        /// <summary>
        /// 获取域对象。
        /// </summary>
        /// <returns>域对象。</returns>
        public Models.Domains.Entities.Document GetReturn()
        {
            var target = new Models.Domains.Entities.Document();

            target.DocumentId = Guid.NewGuid();
            target.ParentDocumentId = this.ParentDocumentId;

            target.Title = this.Title;
            target.NodeName = this.NodeName;
            target.Priority = this.Priority;
            target.Url = this.Url;
            target.DocumentTime = this.DocumentTime;
            target.MinutesToRead = this.MinutesToRead;

            target.UpdateTimeForHTTPGet = new DateTime(1900, 1, 1);

            target.UpdateTime = DateTime.Now;

            return target;
        }
    }
}