using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.AdditionCategory
{
    public class Details
    {
        public Details(Guid id)
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.AdditionCategories.Find(id);
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

            var target = (Domains.Entities.AdditionCategory)origin;

            this.AdditionCategoryId = target.AdditionCategoryId;

            this.Name = target.Name;

            this.IsUseForBook = target.IsUseForBook;

            this.UpdateTime = target.UpdateTime;
            this.TimeStamp = BitConverter.ToInt64(target.TimeStamp, 0);
        }





        public bool _isExist { get; set; }





        public Guid AdditionCategoryId { get; set; }





        public string Name { get; set; }





        public bool IsUseForBook { get; set; }





        public DateTime UpdateTime { get; set; }

        public long TimeStamp { get; set; }
    }
}