using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Communication
{
    /// <summary>
    /// HTTP通讯超尝试次数异常。
    /// </summary>
    /// <remarks>HTTP操作中失败重试超过设置的次数时发生此异常。</remarks>
    public class HTTPTryOutTimesException : Exception
    {
        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="url">目标URL。</param>
        /// <param name="times">设置的尝试次数。</param>
        public HTTPTryOutTimesException(string url, int times)
        {
            this.Url = url;
            this.Times = times;
        }





        /// <summary>
        /// 目标URL。
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 设置的尝试次数。
        /// </summary>
        public int Times { get; set; }
    }
}