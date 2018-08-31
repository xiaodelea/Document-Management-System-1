using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentManagementSystem.Models.Domains.Entities
{
    [Table("AdditionCategories")]
    public class AdditionCategory
    {
        [Key]
        public virtual Guid AdditionCategoryId { get; set; }





        public virtual string Name { get; set; }





        public virtual bool IsUseForBook { get; set; }





        public virtual DateTime UpdateTime { get; set; }

        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }
    }
}