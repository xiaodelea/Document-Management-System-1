using System;
using System.Linq;

namespace DocumentManagementSystem.Models.ViewModels.Books4.TransDB
{
    public class TransDB
    {
        public Worker.ValidateResult Do()
        {
            var old_Db = new Domains.Entities.DMsDbContext();
            var old_Shelves = old_Db.Documents.Where(c => c.IsBook && c.IsAbstract && !c.IsMain && c.ParentDocumentId == null);

            var new_Db = new Domains.MySQL.Entities.DMsDbContext();

            foreach (var old_shelf in old_Shelves.ToList())
                this.Shelf(old_shelf, new_Db);

            new_Db.SaveChanges();

            return new Worker.ValidateResult(false);
        }

        public void Shelf(Domains.Entities.Document old, Domains.MySQL.Entities.DMsDbContext new_Db)
        {
            var shelf = new Domains.MySQL.Entities.Document
            {
                DocumentId = old.DocumentId,
                ParentDocumentId = old.ParentDocumentId,
                Title = old.Title,
                NodeName = old.Title,
                Priority = old.Priority,
                UpdateTimeForHTTPGet = DateTime.Now,
                IsBook = true,
                IsAbstract = true,
                UpdateTime = old.UpdateTime,
            };
            new_Db.Documents.Add(shelf);

            foreach (var old_shelf in old.ChildDocuments.Where(c => c.IsBook && c.IsAbstract && !c.IsMain))
                this.Shelf(old_shelf, new_Db);
        }
    }
}