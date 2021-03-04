using System;
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


        /// <summary>
        /// WebRequest 请求WebSerivce
        /// </summary>
        /// <param name="url"></param>
        /// <param name="soapAction"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static string HttpPostWebService(string url, string soapAction, string parameter)
        {
            string result = string.Empty;
            byte[] bytes = null;

            Stream writer = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            bytes = Encoding.UTF8.GetBytes(parameter);

            request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("SOAPAction", soapAction);
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
            request.UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:12.0) Gecko/20100101 Firefox/12.0";
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.ContentLength = bytes.Length;

            try
            {
                writer = request.GetRequestStream();        //获取用于写入请求数据的Stream对象
            }
            catch (Exception ex)
            {
                return "";
            }

            writer.Write(bytes, 0, bytes.Length);       //把参数数据写入请求数据流
            writer.Close();

            try
            {
                response = (HttpWebResponse)request.GetResponse();      //获得响应
            }
            catch (WebException ex)
            {
                return "";
            }

            #region 这种方式读取到的是一个返回的结果字符串
            //Stream stream = response.GetResponseStream();        //获取响应流
            //XmlTextReader Reader = new XmlTextReader(stream);
            //Reader.MoveToContent();
            //result = Reader.ReadInnerXml();

            //Reader.Dispose();
            //Reader.Close();

            //stream.Dispose();
            //stream.Close();
            #endregion

            #region 这种方式读取到的是一个Xml格式的字符串
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            result = reader.ReadToEnd();

            response.Dispose();
            response.Close();

            reader.Close();
            reader.Dispose();
            #endregion

            return result;
        }
    }
}