using System;
using System.IO;
using System.Net;
using System.Text;

namespace ATool.Http
{
    //TODO 旧版本使用
    //TODO 替换为 System.Net.Http.HttpClient
    //TODO https://docs.microsoft.com/zh-cn/dotnet/api/system.net.http.httpclient?view=netframework-4.5



    class HttpRequest_temp
    {
        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="allowAutoRedirect">302重定向，需要设置为false</param>
        /// <param name="json">传参</param>
        /// <returns></returns>
        public static string GetCookies(string url, bool? allowAutoRedirect = null, string json = "")
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                if (allowAutoRedirect.HasValue) request.AllowAutoRedirect = allowAutoRedirect.Value;
                string paraUrlCoded = json;
                byte[] payload = Encoding.UTF8.GetBytes(paraUrlCoded);
                request.CookieContainer = new CookieContainer();
                request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    StringBuilder sbCookie = new StringBuilder();
                    foreach (Cookie cook in response.Cookies)
                    {
                        sbCookie.Append($"{cook.Name}={cook.Value}; Path={cook.Path}; Domain={cook.Domain};");
                    }
                    return sbCookie.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        /// <summary>
        /// Get 请求
        /// Get为Select操作
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string HttpGet(string url, string cookie = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            if (!string.IsNullOrEmpty(cookie)) request.Headers.Add(HttpRequestHeader.Cookie, cookie);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        /// <summary>
        /// HttpPost 请求
        /// Post为Insert操作
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="json">Json</param>
        /// <param name="cookie">cookie</param>
        /// <returns></returns>
        public static string HttpPost(string url, string json = "", string cookie = null)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                request.Headers.Add(HttpRequestHeader.Cookie, cookie);
                string paraUrlCoded = json;
                byte[] payload = Encoding.UTF8.GetBytes(paraUrlCoded);
                request.ContentLength = payload.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();
                var response = (HttpWebResponse)request.GetResponse();
                var s = response.GetResponseStream();
                string strDate = "";
                string strValue = "";
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                while ((strDate = reader.ReadLine()) != null)
                {
                    strValue += strDate + "\r\n";
                }

                s.Close();
                response.Close();

                return strValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        /// <summary>
        /// HttpPut请求
        /// Put为Update操作
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string HttpPut(string url, string json = "", string cookie = null)
        {
            try
            {
                //构造http请求的对象
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //转成网络流
                byte[] buf = Encoding.GetEncoding("UTF-8").GetBytes(json);
                //设置
                request.Method = "PUT";
                request.ContentLength = buf.Length;
                request.ContentType = "application/json";
                request.MaximumAutomaticRedirections = 1;
                request.AllowAutoRedirect = true;
                request.Headers.Add(HttpRequestHeader.Cookie, cookie);

                // 发送请求
                Stream newStream = request.GetRequestStream();
                newStream.Write(buf, 0, buf.Length);
                newStream.Close();
                // 获得接口返回值
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var s = response.GetResponseStream();
                string strDate = "";
                string strValue = "";
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                while ((strDate = reader.ReadLine()) != null)
                {
                    strValue += strDate + "\r\n";
                }

                s.Close();
                reader.Close();

                return strValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        /// <summary>
        /// HttpDelete请求
        /// Delete为Delete操作
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string HttpDelete(string url, string json = "", string cookie = null)
        {
            try
            {
                //构造http请求的对象
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //转成网络流
                byte[] buf = Encoding.GetEncoding("UTF-8").GetBytes(json);
                //设置
                request.Method = "DELETE";
                request.ContentLength = buf.Length;
                request.ContentType = "application/json";
                request.MaximumAutomaticRedirections = 1;
                request.AllowAutoRedirect = true;
                request.Headers.Add(HttpRequestHeader.Cookie, cookie);

                // 发送请求
                Stream newStream = request.GetRequestStream();
                newStream.Write(buf, 0, buf.Length);
                newStream.Close();
                // 获得接口返回值
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                var s = response.GetResponseStream();
                string strDate = "";
                string strValue = "";
                StreamReader reader = new StreamReader(s, Encoding.UTF8);
                while ((strDate = reader.ReadLine()) != null)
                {
                    strValue += strDate + "\r\n";
                }

                s.Close();
                reader.Close();

                return strValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }
    }
}
