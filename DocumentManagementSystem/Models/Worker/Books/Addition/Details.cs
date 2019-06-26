using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Addition
{
    public class Details
    {
        public Details(Guid id)
        {
            var db = new Domains.MySQL.Entities.DMsDbContext();
            var target = db.Additions.Find(id);
            this.Initial(target);
        }

        public Details(object origin)
        {
            this.Initial(origin);
        }

        private void Initial(object origin)
        {
            if (origin == null)
            {
                this._isExist = false;
                return;
            }
            else
                this._isExist = true;

            var target = (Domains.MySQL.Entities.Addition)origin;

            this.AdditionId = target.AdditionId;
            this.DocumentId = target.DocumentId;

            this.Name = target.AdditionCategory.Name;
            this.Description = target.Description;

            this.UpdateTime = target.UpdateTime;
            //this.TimeStamp = BitConverter.ToInt64(target.TimeStamp, 0);
        }





        public bool _isExist { get; set; }





        public Guid AdditionId { get; set; }

        public Guid DocumentId { get; set; }





        public string Name { get; set; }

        public virtual string Description { get; set; }





        public DateTime UpdateTime { get; set; }

        public long TimeStamp { get; set; }
    }
}