using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentManagementSystem.Models.BusinessModels.Communication
{
    /// <summary>
    /// HTTP通讯器。
    /// </summary>
    /// <remarks>处理HTTP通讯相关操作，如GET、POST等。</remarks>
    public static class HTTPCommunicator
    {
        /// <summary>
        /// 使用HTTP的GET方法。
        /// </summary>
        /// <param name="url">URL。</param>
        /// <param name="cookie">Cookie容器。</param>
        /// <param name="isAllowAutoRedirect">是否允许跳转。</param>
        /// <param name="referer">引用页面。</param>
        /// <param name="times">尝试次数。</param>
        /// <returns>返回的内容（字符串）。</returns>
        /// <exception cref="ArgumentNullException">参数为空。</exception>
        /// <exception cref="ArgumentOutOfRangeException">尝试次数不大于0。</exception>
        public static string HttpGetString(string url, System.Net.CookieContainer cookie = null, bool isAllowAutoRedirect = false, string referer = "", int times = 5)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            if (times <= 0)
                throw new ArgumentOutOfRangeException("times");

            for (var i = 0; i < times; i++)
            {
                System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                httpWebRequest.CookieContainer = cookie;
                httpWebRequest.AllowAutoRedirect = isAllowAutoRedirect;
                httpWebRequest.Headers.Add("Pragma: no-cache");
                httpWebRequest.Timeout = 20000;
                if (referer.Length > 0)
                    httpWebRequest.Referer = referer;

                System.Net.HttpWebResponse httpWebResponse;
                try
                {
                    httpWebResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();

                    if (httpWebResponse.StatusCode != System.Net.HttpStatusCode.OK && httpWebResponse.StatusCode != System.Net.HttpStatusCode.Redirect)
                    {
                        System.Threading.Thread.Sleep(500);
                        continue;
                    }

                    System.IO.Stream stream = httpWebResponse.GetResponseStream();
                    System.IO.StreamReader reader = new System.IO.StreamReader(stream);

                    string returnString = reader.ReadToEnd();
                    return returnString;
                }
                catch
                {
                    System.Threading.Thread.Sleep(500);
                    continue;
                }
            }

            throw new HTTPTryOutTimesException(url, times);
        }
    }
}