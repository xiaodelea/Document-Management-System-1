using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentManagementSystem.Models.Domains.MySQL.Entities
{
    /// <summary>
    /// 章节。
    /// </summary>
    /// <remarks>表示一个文档中的章节。</remarks>
    [Table("Chapters")]
    public class Chapter
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        public Chapter()
        {

        }





        /// <summary>
        /// 章节ID。
        /// </summary>
        [Key]
        public virtual Guid ChapterId { get; set; }

        /// <summary>
        /// 归属的文档ID。
        /// </summary>
        [ForeignKey("Document")]
        public virtual Guid DocumentId { get; set; }





        /// <summary>
        /// 章节名称。
        /// </summary>
        [Required]
        [Display(Name = "章节名称")]
        public virtual string ChapterName { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        [Display(Name = "序号")]
        public virtual int Priority { get; set; }





        /// <summary>
        /// 归属的文档。
        /// </summary>
        public virtual Document Document { get; set; }





        public virtual DateTime UpdateTime { get; set; }
    }
}