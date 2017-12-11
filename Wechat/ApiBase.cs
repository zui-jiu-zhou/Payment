using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    public abstract class ApiBase<TResult> where TResult: ResultBase, new()
    {
        private ParamDefinitionCollection _paramDefinitions = new ParamDefinitionCollection();
        /// <summary>
        /// api参数集合
        /// </summary>
        public ParamCollection Params { get; }  
        /// <summary>
        /// api调用结果
        /// </summary>
        public TResult Result
        {
            get;
            protected set;
        }
        /// <summary>
        /// api参数定义
        /// </summary>
        public IReadOnlyList<ParamDefinition> ParamDefinitions { get { return _paramDefinitions; } } 
        /// <summary>
        /// api地址
        /// </summary>
        public abstract string ApiURL { get; }
        /// <summary>
        /// 创建Api实例
        /// </summary>
        public ApiBase()
        {
            Params = new ParamCollection();
            AddParamDefinition(new ParamDefinition("appid", true, 1, 32));
            AddParamDefinition(new ParamDefinition("mch_id", true, 1, 32));
            AddParamDefinition(new ParamDefinition("sub_appid", false, 1, 32));
            AddParamDefinition(new ParamDefinition("sub_mch_id", false, 1, 32));
            AddParamDefinition(new ParamDefinition("nonce_str", true, 1, 32));
            AddParamDefinition(new ParamDefinition("sign", true, 1, 32));
            AddParamDefinition(new ParamDefinition("sign_type", false, 0, 32));
            AddParamDefinition(new ParamDefinition("key", true, 1, 256));
            TSetNonceStr();
        }
        /// <summary>
        /// 添加参数定义
        /// </summary>
        /// <param name="paramDefinition"></param>
        protected void AddParamDefinition(ParamDefinition paramDefinition)
        {
            _paramDefinitions.Add(paramDefinition);
        }
        /// <summary>
        /// 添加参数定义集合
        /// </summary>
        /// <param name="paramDefinitions"></param>
        protected void AddParamDefinitions(IEnumerable<ParamDefinition>  paramDefinitions)
        {
            foreach (var item in paramDefinitions)
            {
                AddParamDefinition(item);
            }
        }
        /// <summary>
        /// 添加参数定义分组，指定分组的参数至少指定一个
        /// </summary>
        /// <param name="paramDefinitions"></param>
        protected void AddParamDefinitionSelection(IEnumerable<ParamDefinition> paramDefinitions)
        {
            _paramDefinitions.AddSelection(paramDefinitions);
        }
        /// <summary>
        /// 移除指定名称的参数定义
        /// </summary>
        /// <param name="name"></param>
        protected void RemoveParamDefiniton(string name)
        {
            _paramDefinitions.Remove(name);
        }
        /// <summary>
        /// 添加指定名称的参数，如果此名称参数已存在则更新此名称参数 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddParam(string name, string value)
        {
            Params.Add(name, value);
        }
        /// <summary>
        /// 添加参数集合
        /// </summary>
        /// <param name="json">参数键值json字符串</param>
        public void AddParams(string json)
        {
            var _obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            foreach (var item in _obj.GetType().GetProperties())
            {
                AddParam(item.Name, item.GetValue(_obj).ToString());
            }
        }
        /// <summary>
        /// 添加参数集合
        /// </summary>
        /// <param name="kvs"></param>
        public void AddParams(IEnumerable<KeyValuePair<string, string>> kvs)
        {
            foreach (var item in kvs)
            {
                AddParam(item.Key, item.Value);
            }
        }
        /// <summary>
        /// 移除指定名称的参数
        /// </summary>
        /// <param name="name"></param>
        public void RemoveParam(string name)
        {
            Params.Remove(name);
        }
        /// <summary>
        /// 获取指定名称的参数值
        /// </summary>
        /// <returns></returns>
        public string GetParamValue(string name)
        {
            if (Params.ContainsKey(name))
            {
                return Params[name];
            }
            return null;
        }
        /// <summary>
        /// 检测参数是否合法
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool TestParams(out string message)
        {
            try
            {
                _paramDefinitions.Test(Params);
                message = "OK";
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            
        }
        /// <summary>
        /// 参数转xml文本
        /// </summary>
        /// <returns></returns>
        public string ToXmlString()
        {
            string message = "";
            if(!TestParams(out message))
            {
                throw new Exception(message);
            }
            StringBuilder _sb = new StringBuilder();
            _sb.Append("<xml>");
            foreach (var item in Params.OrderBy(t=>t.Key))
            {
                if (item.Key == "key")
                    continue;
                _sb .Append('<')
                    .Append(item.Key)
                    .Append("><![CDATA[")
                    .Append(item.Value)
                    .Append("]]><")
                    .Append('/')
                    .Append(item.Key)
                    .Append('>');
            }
            _sb.Append("</xml>");
            return _sb.ToString();
        }
        /// <summary>
        /// 同步调用API
        /// </summary>
        /// <returns></returns>
        public TResult Post()
        {
            HttpContent _hc = new StringContent(ToXmlString());
            _hc.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PostAsync(ApiURL, _hc).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return Util.Xml2Object<TResult>(result);
            }
            return null;
        }
        /// <summary>
        /// 异步调用api
        /// </summary>
        /// <returns></returns>
        public async Task<TResult> PostAsync()
        {
            return await Task.Run(new Func<TResult>(()=> { return Post(); }));
        }
        /// <summary>
        /// 快速设置appid
        /// </summary>
        /// <param name="value">值</param>
        public ApiBase<TResult> TSetAppid(string value)
        {
            AddParam("appid", value);
            return this;
        }
        /// <summary>
        /// 快速设置商户id
        /// </summary>
        /// <param name="value"></param>
        public ApiBase<TResult> TSetMchId(string value)
        {
            AddParam("mch_id", value);
            return this;
        }
        /// <summary>
        /// 快速设置子商户id
        /// </summary>
        /// <param name="value"></param>
        public ApiBase<TResult> TSetSubAppid(string value)
        {
            AddParam("sub_appid", value);
            return this;
        }
        /// <summary>
        /// 快速设置子商户公众号appid
        /// </summary>
        /// <param name="value"></param>
        public ApiBase<TResult> SetSubMchId(string value)
        {
            AddParam("sub_mch_id", value);
            return this;
        }
        /// <summary>
        /// 快速设置key
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ApiBase<TResult> TSetAppkey(string value)
        {
            AddParam("key", value);
            return this;
        }
        /// <summary>
        /// 快速设置随机字符串
        /// 可以不调用，初始化实例时会生成
        /// </summary>
        /// <param name="value"></param>
        public ApiBase<TResult> TSetNonceStr()
        {
            AddParam("nonce_str", Util.GetNonceStr());
            return this;
        }
        /// <summary>
        /// 设置签名，应该在其它参数设置完成后调用
        /// 此参数不参数签名
        /// </summary>
        public ApiBase<TResult> TSetSign(SignatureAlgorithm sa)
        {
            if (!Params.ContainsKey("key"))
                throw new Exception("请先设置支付key");
            switch (sa)
            {
                case SignatureAlgorithm.MD5:
                    AddParam("sign_type", "MD5");
                    break;
                case SignatureAlgorithm.HMAC_SHA256:
                    break;
                default:
                    break;
            }
            var _kvs = Params
                .Where(t => t.Key != "sign" && !string.IsNullOrWhiteSpace(t.Value))
                .OrderBy(t => t.Key)
                .ToDictionary(t => t.Key, t => t.Value);
            var _kvs1 = _kvs.Where(t => t.Key != "key").ToDictionary(k => k.Key, v => v.Value);
            _kvs1.Add("key", _kvs["key"]);
            switch (sa)
            {
                case SignatureAlgorithm.MD5:
                    AddParam("sign", Util.GetTextMD5_32(Util.ToURLQueryString(_kvs1)));
                    break;
                case SignatureAlgorithm.HMAC_SHA256:
                    break;
                default:
                    break;
            }
            return this;
        }
    }
}