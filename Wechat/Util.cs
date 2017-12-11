using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay 
{
    public static class Util
    {
        const string _CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        #region md5
        /// <summary>
        /// 获取文本32位MD5
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetTextMD5_32(string text)
        {
            if (string.IsNullOrEmpty(text)) { return string.Empty; }
            MD5 md5 = MD5.Create();
            byte[] bytValue = Encoding.UTF8.GetBytes(text);
            byte[] bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            StringBuilder sb = new StringBuilder();
            if (bytHash == null)
                return string.Empty;
            else
                foreach (var byt in bytHash)
                {
                    sb.Append(byt.ToString("X2"));
                }
            return sb.ToString().ToUpper();
        }
        #endregion

        #region nonceStr
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        public static string GetNonceStr()
        {
            StringBuilder _sb = new StringBuilder();
            Random _r = new Random();
            while (_sb.Length < 32)
            {
                _sb.Append(_CHARS[_r.Next(1, 52)]);
            }
            return _sb.ToString().ToUpper();
        }
        #endregion

        #region urlparam
        public static string ToURLQueryString(IEnumerable<KeyValuePair<string, string>> kvs)
        {
            bool _first = true;
            StringBuilder _sb = new StringBuilder();
            foreach (var item in kvs)
            {
                if (_first)
                {
                    _first = false;
                }
                else
                {
                    _sb.Append('&');
                }
                _sb.Append(item.Key)
                   .Append('=')
                   .Append(item.Value);
               
            }
            return _sb.ToString();
        }

        public static Dictionary<string, string> ToURLParamArray(string queryString) 
        {
            queryString = queryString.Replace("?", "");
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(queryString))
            {
                string[] _params = queryString.Split(new char[] { '&' });
                foreach (var item in _params)
                {
                    var _index = item.IndexOf('=');
                    if (_index > 0)
                    {
                        var _key = item.Substring(0, _index);
                        var _value = item.Substring(_index + 1);
                        if (result.ContainsKey(_key))
                        {
                            result[_key] = _value;
                        }
                        else
                        {
                            result.Add(_key, _value);
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region xml
        public static T Xml2Object<T>(string xmlStr)
        {
            T obj;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader = new StringReader(xmlStr);
            obj = (T)serializer.Deserialize(reader);
            reader.Close();
            return obj;
        }
        #endregion

        #region ip
        public static string GetRequestIp()
        {
            string ip = "";
            //Request.ServerVariables[""]--获取服务变量集合   
            if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null) //判断发出请求的远程主机的ip地址是否为空  
            {
                //获取发出请求的远程主机的Ip地址  
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            //判断登记用户是否使用设置代理  
            else if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    //获取代理的服务器Ip地址  
                    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    //获取客户端IP  
                    ip = HttpContext.Current.Request.UserHostAddress.ToString();
                }
            }
            else
            {
                //获取客户端IP  
                ip = HttpContext.Current.Request.UserHostAddress.ToString();
            }
            return ip;
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        #endregion

        #region log
        const string _LOG_PATH = "C:\\log.txt";

        public static void Log(string txt)
        {
            if (!File.Exists(_LOG_PATH))
            {
                File.Create(_LOG_PATH);
            }
            File.AppendAllText(_LOG_PATH, "\r\n" + txt);
        }
        #endregion
    }
}