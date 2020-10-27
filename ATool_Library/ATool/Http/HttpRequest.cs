using System.IO;
using System.Net;
using System.Text;

namespace ATool
{
    /// <summary>
    /// Http 请求类
    /// </summary>
    public static class HttpRequest
    {
        /// <summary>
        /// Get 请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="postDataStr">参数</param>
        /// <returns>返回结果</returns>
        public static string HttpGet(string url, string postDataStr)
        {
            HttpWebRequest request =
                (HttpWebRequest) WebRequest.Create(url + (string.IsNullOrWhiteSpace(postDataStr) ? "" : "?") +
                                                   postDataStr);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        /// <summary>
        /// Get 请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public static string HttpGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        /// <summary>
        /// HttpPost 请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="json">Json</param>
        /// <returns></returns>
        public static string HttpPost(string url, string json)
        {
            string strUrl = url;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(strUrl);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = json;
            byte[] payload = Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            var response = (HttpWebResponse) request.GetResponse();
            var s = response.GetResponseStream();
            string strDate = "";
            string strValue = "";
            StreamReader reader = new StreamReader(s, Encoding.UTF8);
            while ((strDate = reader.ReadLine()) != null)
            {
                strValue += strDate + "\r\n";
            }

            return strValue;
        }
    }
}