using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentManagementSystem.Models.Domains.Entities
{
    /// <summary>
    /// 文档。
    /// </summary>
    [Table("Documents")]
    public class Document
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        public Document()
        {
            this.ChildDocuments = new List<Document>();
            this.Chapters = new List<Chapter>();
        }





        /// <summary>
        /// 文档ID。
        /// </summary>
        [Key]
        public virtual Guid DocumentId { get; set; }

        /// <summary>
        /// 父文档文档ID。
        /// </summary>
        [ForeignKey("ParentDocument")]
        public virtual Guid? ParentDocumentId { get; set; }





        /// <summary>
        /// 标题。
        /// </summary>
        [Required]
        [Display(Name = "标题")]
        public virtual string Title { get; set; }

        /// <summary>
        /// 节点名称。
        /// </summary>
        [Required]
        [Display(Name = "节点名称")]
        public virtual string NodeName { get; set; }





        /// <summary>
        /// 优先级。
        /// </summary>
        /// <remarks>排序用。</remarks>
        [Display(Name = "优先级")]
        public virtual int? Priority { get; set; }

        /// <summary>
        /// HTTP方式更新数据时间。
        /// </summary>
        /// <remarks>通过HTTP获取文本内容的本地更新时间。</remarks>
        [Display(Name = "更新数据时间")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public virtual DateTime UpdateTimeForHTTPGet { get; set; }

        /// <summary>
        /// 是否已查阅。
        /// </summary>
        [Display(Name = "查阅")]
        public virtual bool IsChecked { get; set; }

        /// <summary>
        /// 是否有笔记。
        /// </summary>
        [Display(Name = "笔记")]
        public virtual bool IsNoted { get; set; }

        /// <summary>
        /// 是否已获取全部子节点。
        /// </summary>
        [Display(Name = "子节点")]
        public virtual bool IsGetAllChildren { get; set; }

        /// <summary>
        /// 文档日期。
        /// </summary>
        /// <remarks>文档本身更新的日期。</remarks>
        [Display(Name = "文档日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public virtual DateTime? DocumentTime { get; set; }





        /// <summary>
        /// URL。
        /// </summary>
        /// <remarks>留空即为无内容。</remarks>
        [Url]
        public virtual string Url { get; set; }

        /// <summary>
        /// 主体内容源代码。
        /// </summary>
        /// <remarks>可能在使用中会被本地修改。</remarks>
        [Display(Name = "主体内容源代码")]
        public virtual string SourceTextMainContain { get; set; }

        /// <summary>
        /// 主体内容源代码备份。
        /// </summary>
        /// <remarks>需独立赋值。</remarks>
        [Display(Name = "主体内容源代码备份")]
        public virtual string SourceTextMainContainBackup { get; set; }

        /// <summary>
        /// 主体内容源代码哈希码。
        /// </summary>
        [Display(Name = "主体内容源代码哈希码")]
        public virtual string SourceTextHashCode { get; set; }





        /// <summary>
        /// 备注。
        /// </summary>
        public virtual string Remarks { get; set; }

        /// <summary>
        /// 阅读时间。
        /// </summary>
        public virtual int? MinutesToRead { get; set; }





        public virtual DateTime UpdateTime { get; set; }

        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }





        /// <summary>
        /// 父文档。
        /// </summary>
        public virtual Document ParentDocument { get; set; }





        /// <summary>
        /// 子文档集合。
        /// </summary>
        [ForeignKey("ParentDocumentId")]
        public virtual List<Document> ChildDocuments { get; set; }

        /// <summary>
        /// 章节集合。
        /// </summary>
        public virtual List<Chapter> Chapters { get; set; }





        public int TotalMinutesToRead
        {
            get
            {
                return this.ChildDocuments.Sum(c => c.TotalMinutesToRead) + ((this.IsChecked && this.MinutesToRead.HasValue) ? this.MinutesToRead.Value : 0);
            }
        }
    }
}