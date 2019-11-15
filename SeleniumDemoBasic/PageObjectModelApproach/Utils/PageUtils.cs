using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SeleniumDemoBasic.PageObjectModelApproach.Utils
{
    public static class PageUtils
    {
        public static bool IsLinkOk(string url)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "HEAD";

            bool isOk = false;

            try
            {
                var response = (HttpWebResponse) request.GetResponse();
                isOk = response.StatusCode == HttpStatusCode.OK;
            }
            catch { }

            return isOk;
        }
    }
}
