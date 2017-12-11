using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    [Serializable]
    [XmlRoot(ElementName = "xml")]
    public class RefundResult : ResultBase
    {

        /// <summary>
        /// 业务结果 是 String(16)  SUCCESS
        /// SUCCESS/FAIL
        /// SUCCESS退款申请接收成功，结果通过退款查询接口查询
        /// FAIL 提交业务失败
        /// </summary>
        [XmlElement(ElementName = "result_code")]
        public string Result_Code { get; set; }

        /// <summary>
        /// 错误代码
        /// 否   String(32)  SYSTEMERROR 列表详见错误码列表
        /// </summary>
        [XmlElement(ElementName = "err_code")]
        public string Err_Code { get; set; }


        /// <summary>
        /// 错误代码描述
        /// 否 String(128) 系统超时 结果信息描述
        /// </summary>
        [XmlElement(ElementName = "err_code_des")]
        public string Err_Code_Des { get; set; }


        /// <summary>
        /// 公众账号ID
        /// 是 String(32)  wx8888888888888888 微信分配的公众账号ID
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
        /// <summary>
        /// 随机字符串
        /// 是   String(32)  5K8264ILTKCH16CQ2502SI8ZNMTM67VS 随机字符串，不长于32位
        /// </summary>
        [XmlElement(ElementName = "nonce_str")]
        public string Nonce_Str { get; set; }

        /// <summary>
        /// 签名
        /// 是   String(32)  5K8264ILTKCH16CQ2502SI8ZNMTM67VS 签名，详见签名算法
        /// </summary>
        [XmlElement(ElementName = "sign")]
        public string Sign { get; set; }


        /// <summary>
        /// 微信订单号
        /// 是   String(32)  4007752501201407033233368018	微信订单号
        /// </summary>
        [XmlElement(ElementName = "transaction_id")]
        public string Transaction_Id { get; set; }


        /// <summary>
        /// 商户订单号
        /// 是   String(32)  33368018	商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        [XmlElement(ElementName = "out_trade_no")]
        public string Out_Trade_No { get; set; }


        /// <summary>
        /// 商户退款单号
        /// 是 String(64)  121775250	商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
        /// </summary>
        [XmlElement(ElementName = "out_refund_no")]
        public string Out_Refund_No { get; set; }


        /// <summary>
        /// 微信退款单号
        /// 是 String(32)  2007752501201407033233368018	微信退款单号
        /// </summary>
        [XmlElement(ElementName = "refund_id")]
        public string Refund_Id { get; set; }


        /// <summary>
        /// 退款金额
        /// 是   Int	100	退款总金额,单位为分,可以做部分退款
        /// </summary>
        [XmlElement(ElementName = "refund_fee")]
        public string Refund_Fee { get; set; }


        /// <summary>
        /// 应结退款金额
        /// 否   Int	100	去掉非充值代金券退款金额后的退款金额，退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [XmlElement(ElementName = "settlement_refund_fee")]
        public string Settlement_Refund_Fee { get; set; }


        /// <summary>
        /// 标价金额
        /// 是   Int	100	订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement(ElementName = "total_fee")]
        public string Total_Fee { get; set; }


        /// <summary>
        /// 应结订单金额
        /// 否   Int	100	去掉非充值代金券金额后的订单总金额，应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [XmlElement(ElementName = "settlement_total_fee")]
        public string Settlement_Total_Fee { get; set; }


        /// <summary>
        /// 标价币种 
        /// 否 String(8)   CNY 订单金额货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement(ElementName = "fee_type")]
        public string Fee_Type { get; set; }


        /// <summary>
        /// 现金支付金额
        /// 是   Int	100	现金支付金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement(ElementName = "cash_fee")]
        public string Cash_Fee { get; set; }


        /// <summary>
        /// 现金支付币种
        /// 否   String(16)  CNY 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement(ElementName = "cash_fee_type")]
        public string Cash_Fee_Type { get; set; }


        /// <summary>
        /// 现金退款金额
        /// 否   Int	100	现金退款金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement(ElementName = "cash_refund_fee")]
        public string Cash_Refund_Fee { get; set; }

        /// <summary>
        /// 获取一个值该值指示是否退款成功
        /// </summary>
        public override bool IsSuccessful { get
            {
                return Return_Code == FLAG_SUCCESS && Result_Code == FLAG_SUCCESS;
            } }
    }
}