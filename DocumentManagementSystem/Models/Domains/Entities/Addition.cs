using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentManagementSystem.Models.Domains.Entities
{
    [Table("Additions")]
    public class Addition
    {
        [Key]
        public virtual Guid AdditionId { get; set; }

        [ForeignKey("AdditionCategory")]
        public virtual Guid AdditionCategoryId { get; set; }

        [ForeignKey("Document")]
        public virtual Guid DocumentId { get; set; }





        public virtual string Description { get; set; }





        public virtual DateTime UpdateTime { get; set; }

        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }





        public virtual AdditionCategory AdditionCategory { get; set; }

        public virtual Document Document { get; set; }
    }
}