using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.ViewModels.Documents.BreadField
{
    /// <summary>
    /// 文档链面包屑。
    /// </summary>
    /// <remarks>基于一个文档获取完整文档链，并调整顺序。</remarks>
    public class BreadField
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="document">当前文档。</param>
        /// <remarks>初始化时进行文档链处理。</remarks>
        public BreadField(Models.Domains.Entities.Document document, bool activeCurrentNode)
        {
            this.Current = document;
            this.ActiveCurrentNode = activeCurrentNode;

            this.List = new List<Domains.Entities.Document>();
            var current = document.ParentDocument;
            while (current != null)
            {
                this.List.Add(current);
                current = current.ParentDocument;
            }
            this.List.Reverse();
        }





        /// <summary>
        /// 当前文档。
        /// </summary>
        public Models.Domains.Entities.Document Current { get; set; }

        /// <summary>
        /// 当前文档节点可跳转。
        /// </summary>
        public bool ActiveCurrentNode { get; set; }





        /// <summary>
        /// 文档链。
        /// </summary>
        /// <remarks>已排序。</remarks>
        public List<Models.Domains.Entities.Document> List { get; set; }
    }
}