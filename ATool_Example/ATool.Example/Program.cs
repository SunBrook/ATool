using System;
using ATool.Example.DbOperate;

namespace ATool.Example
{
    static class Program
    {
        /// <summary>
        /// 全部示例的入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            #region DateTime

            //获取日期的时间戳 字符串
            DateTimeXEg.GetTimeStampStr();

            //获取日期的时间戳 Long
            DateTimeXEg.GetTimeStampLong();

            #endregion

            #region Encrypt

            //AES 加密
            AesEg.Encrypt();
            
            //AES 解密
            AesEg.Decrypt();
            
            //DES 加密
            DesEg.Encrypt();
            
            //DES 解密
            DesEg.Decrypt();
            
            //MD5 加密 16位 大小写
            Md5XEg.Encrypt16();
            
            //MD5 加密 32位 大小写
            Md5XEg.Encrypt32();

            #endregion

            //Encrypt

            //File

            //Http
            var url = "http://172.16.20.29/soap/JHIPLIB.SOAP.BS.XmlService.cls?CfgItem=JH1801获取检验标本信息服务";
            var soapAction = "http://bjgoodwillcis.com/JHIPLIB.SOAP.BS.XmlService.XMLMessageServer";
            var parameter = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:good=\"http://goodwillcis.com\" xmlns:bjg=\"http://bjgoodwillcis.com\">\r\n   <soapenv:Header>\r\n      <good:JiaheSecurity>\r\n         <!--Optional:-->\r\n         <good:UserName>?</good:UserName>\r\n         <!--Optional:-->\r\n         <good:Password>?</good:Password>\r\n         <!--Optional:-->\r\n         <good:Timestamp>?</good:Timestamp>\r\n         <!--Optional:-->\r\n         <good:FromSYS>?</good:FromSYS>\r\n         <!--Optional:-->\r\n         <good:IV>?</good:IV>\r\n      </good:JiaheSecurity>\r\n   </soapenv:Header>\r\n   <soapenv:Body>\r\n      <bjg:XMLMessageServer>\r\n         <!--Optional:-->\r\n         <bjg:Message><![CDATA[<Request><cardno>1000</cardno></Request>]]></bjg:Message>\r\n      </bjg:XMLMessageServer>\r\n   </soapenv:Body>\r\n</soapenv:Envelope>";
            HttpRequest.HttpPostWebService(url, soapAction, parameter);

            //Random

            //Result

            //Text

            #region DbOperate
            
            //BulkCopy
            SqlConnectionExtensionEg.BulkCopyEg();

            #endregion
        }
    }
}