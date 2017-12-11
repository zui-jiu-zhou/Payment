using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    [Serializable]
    [XmlRoot(ElementName = "xml")]
    public class UnifiedOrderNotify : ResultBase
    {

        /// <summary>
        /// 公众账号ID 
        /// 是 String(32)  wx8888888888888888 微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [XmlElement(ElementName = "appid")]
        public string Appid { get; set; }
        /// <summary>
        /// 商户号
        /// 是 String(32)  1900000109	微信支付分配的商户号
        /// </summary>
        [XmlElement(ElementName = "mch_id")]
        public string Mch_Id { get; set; }

        /// <summary>
        /// 设备号
        ///  否   String(32)  013467007045764	微信支付分配的终端设备号，
        /// </summary>
        [XmlElement(ElementName = "device_info")]
        public string Device_Info { get; set; }

        /// <summary>
        /// 随机字符串
        /// 是 String(32)  5K8264ILTKCH16CQ2502SI8ZNMTM67VS 随机字符串，不长于32位
        /// </summary>
        [XmlElement(ElementName = "nonce_str")]
        public string Nonce_Str { get; set; }

        /// <summary>
        /// 签名
        ///  是   String(32)  C380BEC2BFD727A4B6845133519F3AD6 签名，详见签名算法
        /// </summary>
        [XmlElement(ElementName = "sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 签名类型
        ///  否   String(32)  HMAC-SHA256 签名类型，目前支持HMAC-SHA256和MD5，默认为MD5
        /// </summary>
        [XmlElement(ElementName = "sign_type")]
        public string Sign_Type { get; set; }

        /// <summary>
        /// 业务结果
        ///     是   String(16)  SUCCESS SUCCESS/FAIL
        /// </summary>
        [XmlElement(ElementName = "result_code")]
        public string Result_Code { get; set; }

        /// <summary>
        /// 错误代码
        ///     否   String(32)  SYSTEMERROR 错误返回的信息描述
        /// </summary>
        [XmlElement(ElementName = "err_code")]
        public string Err_Code { get; set; }

        /// <summary>
        /// 错误代码描述
        ///     否 String(128) 系统错误 错误返回的信息描述
        /// </summary>
        [XmlElement(ElementName = "err_code_des")]
        public string Err_Code_Des { get; set; }

        /// <summary>
        /// 用户标识
        ///     是 String(128) wxd930ea5d5a258f4f 用户在商户appid下的唯一标识
        /// </summary>
        [XmlElement(ElementName = "openid")]
        public string Openid { get; set; }

        /// <summary>
        /// 是否关注公众账号
        ///   否 String(1)   Y 用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        /// </summary>
        [XmlElement(ElementName = "is_subscribe")]
        public string Is_Subscribe { get; set; }

        /// <summary>
        /// 交易类型
        ///     是   String(16)  JSAPI JSAPI、NATIVE、APP
        /// </summary>
        [XmlElement(ElementName = "trade_type")]
        public string Trade_Type { get; set; }

        /// <summary>
        /// 付款银行
        ///   是   String(16)  CMC 银行类型，采用字符串类型的银行标识，银行类型见银行列表
        /// </summary>
        [XmlElement(ElementName = "bank_type")]
        public string Bank_Type { get; set; }

        /// <summary>
        /// 订单金额
        ///   是   Int	100	订单总金额，单位为分
        /// </summary>
        [XmlElement(ElementName = "total_fee")]
        public string Total_Fee { get; set; }

        /// <summary>
        /// 应结订单金额
        ///  否   Int	100	应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [XmlElement(ElementName = "setlement_total_fee")]
        public string Setlement_Total_Fee { get; set; }

        /// <summary>
        /// 货币种类
        ///    否 String(8)   CNY 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement(ElementName = "fee_type")]
        public string Fee_Type { get; set; }

        /// <summary>
        /// 现金支付金额
        ///     是   Int	100	现金支付金额订单现金支付金额，详见支付金额
        /// </summary>
        [XmlElement(ElementName = "cash_fee")]
        public string Cash_Fee { get; set; }

        /// <summary>
        /// 现金支付货币类型
        ///  否   String(16)  CNY 货币类型，符合ISO4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement(ElementName = "cash_fee_type")]
        public string Cash_Fee_Type { get; set; }


        /// <summary>
        /// 微信支付订单号
        ///     是   String(32)  1217752501201407033233368018	微信支付订单号
        /// </summary>
        [XmlElement(ElementName = "transaction_id")]
        public string Transaction_Id { get; set; }

        /// <summary>
        /// 商户订单号
        ///  是   String(32)  1212321211201407033568112322	商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        [XmlElement(ElementName = "out_trade_no")]
        public string Out_Trade_No { get; set; }

        /// <summary>
        /// 商家数据包
        ///     否 String(128) 123456	商家数据包，原样返回
        /// </summary>
        [XmlElement(ElementName = "attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间
        ///   是   String(14)  20141030133525	支付完成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        [XmlElement(ElementName = "time_end")]
        public string Time_End { get; set; }
        /// <summary>
        /// 获取一个值，该值指示支付是否成功
        /// </summary>
        public override bool IsSuccessful { get
            {
                return Return_Code == FLAG_SUCCESS
                    && Result_Code == FLAG_SUCCESS;
            } }
    }

}