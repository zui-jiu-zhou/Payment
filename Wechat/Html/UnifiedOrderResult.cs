using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Payment.Wechat.Html
{
    [XmlRoot("xml", IsNullable = false)]
    public class UnifiedOrderResult : ResultBase
    {
        /// <summary>
        /// 公众账号ID 
        /// 是 String(32)  wx8888888888888888 调用接口提交的公众账号ID
        /// </summary>
        [XmlElement(ElementName = "appid")]
        public string Appid { get; set; }
        /// <summary>
        /// 商户号 
        /// 是 String(32)  1900000109	调用接口提交的商户号
        /// </summary>
        [XmlElement(ElementName = "mch_id")]
        public string  Mch_Id { get; set; }
        /// <summary>
        /// 子商户公众账号ID
        /// 否 String(32)  wx8888888888888887 微信分配的子商户公众账号ID
        /// </summary>
        [XmlElement(ElementName = "sub_appid")]
        public string sub_appid { get; set; }
        /// <summary>
        /// 子商户号
        /// 是 String(32)  1900000109	微信支付分配的子商户号
        /// </summary>
        [XmlElement(ElementName = "sub_mch_id")]
        public string sub_mch_id { get; set; }
        /// <summary>
        /// 设备号
        /// 否 String(32)  013467007045764	调用接口提交的终端设备号，
        /// </summary>
        [XmlElement(ElementName = "device_info")]
        public string  Device_Info { get; set; } 
        /// <summary>
        /// 随机字符串
        /// 是 String(32)  5K8264ILTKCH16CQ2502SI8ZNMTM67VS 微信返回的随机字符串
        /// </summary>
        [XmlElement(ElementName = "nonce_str")]
        public string  Nonce_Str { get; set; } 
        /// <summary>
        /// 签名
        /// 是 String(32) C380BEC2BFD727A4B6845133519F3AD6 微信返回的签名，详见签名算法
        /// </summary>
        [XmlElement(ElementName = "sign")]
        public string Sign { get; set; } 
        /// <summary>
        /// 业务结果 
        /// 是 String(16)  SUCCESS SUCCESS/FAIL
        /// </summary>
        [XmlElement(ElementName = "result_code")]
        public string Result_Code { get; set; } 
        /// <summary>
        /// 错误代码 
        /// 否 String(32) SYSTEMERROR 详细参见第6节错误列表
        /// </summary>
        [XmlElement(ElementName = "err_code")]
        public string  Err_Code { get; set; }
        /// <summary>
        /// 错误代码描述
        /// 否 String(128) 系统错误 错误返回的信息描述
        /// </summary>
        [XmlElement(ElementName = "err_code_des")]
        public string Err_Code_Des { get; set; }

        /// <summary>
        /// 交易类型
        /// 是 String(16)  MWEB 调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，,H5支付固定传MWEB
        /// </summary>
        [XmlElement(ElementName = "trade_type")]
        public string Trade_Type { get; set; }
        /// <summary>
        /// 预支付交易会话标识
        /// 是   String(64)  wx201410272009395522657a690389285100 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时,针对H5支付此参数无特殊用途
        /// </summary>
        [XmlElement(ElementName = "prepay_id")]
        public string Prepay_Id { get; set; }
        /// <summary>
        /// 支付跳转链接  
        /// 是 String(64)  https://wx.tenpay.com/cgi-bin/mmpayweb-bin/checkmweb?prepay_id=wx2016121516420242444321ca0631331346&package=1405458241	mweb_url为拉起微信支付收银台的中间页面，可通过访问该url来拉起微信客户端，完成支付,mweb_url的有效期为5分钟。
        /// </summary>
        [XmlElement(ElementName = "mweb_url")]
        public string Mweb_Url { get; set; } 
    }
}