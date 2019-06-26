using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentManagementSystem.Models.Domains.MySQL.Entities
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





        public virtual AdditionCategory AdditionCategory { get; set; }

        public virtual Document Document { get; set; }
    }
}