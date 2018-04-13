using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Books.Directory
{
    public class Directory
    {
        public Directory(Guid id)
        {
            var db = new Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            while (!target.IsBookMain)
            {
                if (target.ParentDocument != null)
                    target = target.ParentDocument;
                else
                {
                    target = null;
                    break;
                }
            };

            this.Initial(target, id);
        }

        private void Initial(Domains.Entities.Document target, Guid id)
        {
            this.List = new List<Item>();

            //target==null时表示id指示的节点不存在属性main的自身或父节点。
            if (target != null)
            {
                this.AddItem(target, id, 0);
                this.IsHasContent = true;
            }
            else
                this.IsHasContent = false;
        }

        private void AddItem(Domains.Entities.Document target, Guid id, int level)
        {
            if (target.IsBookMain || target.IsBookNormal)
            {
                this.List.Add(new Item(target, id, level));

                foreach (var item in target.ChildDocuments.OrderBy(c => c.Priority))
                    this.AddItem(item, id, level + 1);
            }
        }





        public bool IsHasContent { get; set; }

        public List<Item> List { get; set; }
    }
}