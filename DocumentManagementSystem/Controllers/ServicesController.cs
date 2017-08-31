using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentManagementSystem.Controllers
{
    /// <summary>
    /// 服务控制器。
    /// </summary>
    public class ServicesController : Controller
    {
        /// <summary>
        /// 获取文档信息。
        /// </summary>
        /// <param name="id">文档ID。</param>
        /// <returns>文档信息。</returns>
        public JsonResult GetDocument(Guid id)
        {
            var db = new Models.Domains.Entities.DMsDbContext();

            var target = db.Documents.Find(id);
            if (target == null)
                return Json(new { result = false });

            var targetV = new Models.ViewModels.Services.GetDocument.GetDocument(target);

            return Json(targetV);
        }

        /// <summary>
        /// 设置文档标记。
        /// </summary>
        /// <param name="id">文档ID。</param>
        /// <param name="property">属性名称。</param>
        /// <param name="value">值。</param>
        /// <returns>是否成功执行。</returns>
        public JsonResult SetDocumentFlag(Guid id, string property, bool value)
        {
            var db = new Models.Domains.Entities.DMsDbContext();

            var target = db.Documents.Find(id);
            if (target == null)
                return Json(new { result = false });

            switch (property)
            {
                case "IsChecked":
                    target.IsChecked = value;
                    break;
                case "IsNoted":
                    target.IsNoted = value;
                    break;
                case "IsGetAllChildren":
                    target.IsGetAllChildren = value;
                    break;
                default:
                    return Json(new { result = false });
            }
            db.SaveChanges();

            return Json(new { result = true });
        }

        //public JsonResult OpenLocalFile(Guid id)
        //{
        //    var folder = "D:\\DocumentLibraries";
        //    var fullFileName = folder + "\\" + id.ToString() + ".pdf";

        //    if (System.IO.File.Exists(fullFileName))
        //    {
        //        //System.Diagnostics.Process.Start(fullFileName);
        //        var process = new System.Diagnostics.Process();
        //        process.StartInfo.FileName = fullFileName;
        //        process.Start();

        //        return Json(new { result = true });
        //    }
        //    else
        //    {
        //        return Json(new { result = false });
        //    }
        //}
    }
}