using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace DocumentManagementSystem.Models.ViewModels.Documents.InsertPriority
{
    public class InsertPriority
    {
        /// <summary>
        /// 绑定用。
        /// </summary>
        public InsertPriority()
        {

        }

        public InsertPriority(Guid id)
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            this.DocumentId = id;
            this.TargetPriority = target.Priority == null ? 0 : target.Priority.Value;
            this.TimeStamp = target.TimeStamp;
        }





        [Key]
        public Guid DocumentId { get; set; }





        [Display(Name = "目标优先级")]
        public int TargetPriority { get; set; }





        [Timestamp]
        public virtual byte[] TimeStamp { get; set; }





        public bool Save()
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(this.DocumentId);

            if (target == null)
                return false;

            //修改目标项目优先级。
            target.Priority = this.TargetPriority;
            target.TimeStamp = this.TimeStamp;

            //处理所有后续项目，优先度顺接的均递增1。（处理所有隔空项目）
            var postSilbings = db.Documents.Where(c => c.ParentDocumentId == target.ParentDocumentId && c.Priority >= this.TargetPriority && c.DocumentId != this.DocumentId).OrderBy(c => c.Priority).ToList();
            foreach (var silbing in postSilbings)
                silbing.Priority += 1;

            try
            {
                db.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}