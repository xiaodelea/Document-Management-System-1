﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.Worker.Books.Addition
{
    public class Delete
    {
        public Guid AdditionId { get; set; }

        public long TimeStamp { get; set; }





        public Guid? DocumentId { get; set; }





        public ValidateResult Save()
        {
            var db = new Domains.MySQL.Entities.DMsDbContext();
            lock (Atom.GetInstance())
            {
                //验证信息。
                var addition = db.Additions.Find(this.AdditionId);
                //if (this.TimeStamp != System.BitConverter.ToInt64(addition.TimeStamp, 0))
                //    return new ValidateResult(false, "TimeStamp", "时间戳不吻合！");

                //检测节点。
                var document = db.Documents.Find(addition.DocumentId);
                if (document == null)
                    return new ValidateResult(false, "DocumentId", "节点不存在！");

                //删除信息。
                db.Additions.Remove(addition);

                //修改节点。
                document.UpdateTime = DateTime.Now;

                db.SaveChanges();

                //回传参数。
                this.DocumentId = document.DocumentId;
            }

            return new ValidateResult(true);
        }
    }
}