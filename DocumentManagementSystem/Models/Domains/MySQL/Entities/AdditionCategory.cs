using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentManagementSystem.Models.Domains.MySQL.Entities
{
    [Table("AdditionCategories")]
    public class AdditionCategory
    {
        [Key]
        public virtual Guid AdditionCategoryId { get; set; }





        public virtual string Name { get; set; }





        public virtual bool IsUseForBook { get; set; }





        public virtual DateTime UpdateTime { get; set; }
    }
}