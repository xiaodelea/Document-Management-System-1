using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Documents.Directory
{
    public class Directory
    {
        public Directory(Models.Domains.Entities.Document target)
        {
            this.Create(target.DocumentId);
        }

        public Directory(Guid id)
        {
            this.Create(id);
        }

        private void Create(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();
            var target = db.Documents.Find(id);

            this.Root = target;
            this.NodeName = target.NodeName;
            this.Path = target.Path;
            this.List = new List<Item>();

            this.Fill(target, 0);
        }





        private Models.Domains.Entities.Document Root { get; set; }





        public string NodeName { get; set; }

        public string Path { get; set; }





        public List<Item> List { get; set; }





        private void Fill(Models.Domains.Entities.Document target, int layer)
        {
            foreach (var item in target.ChildDocuments.OrderBy(c => c.Priority))
            {
                string preSpace = "";
                for (var i = 0; i < layer; i++)
                    preSpace += "　　　";

                var newItem = new Item(item.DocumentId, preSpace, item.NodeName, item.IsFinished);
                this.List.Add(newItem);

                this.Fill(item, layer + 1);
            }
        }
    }
}