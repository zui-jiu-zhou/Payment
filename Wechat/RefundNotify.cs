using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    [XmlRoot(ElementName = "xml")]
    public class RefundNotify : ResultBase
    {

        /// <summary>
        /// 公众账号ID
        /// 是String(32)wx8888888888888888微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        [XmlElement(ElementName = "appid")]
        public string Appid { get; set; }

        /// <summary>
        /// 退款的商户号
        /// 是 String(32) 1900000109 微信支付分配的商户号
        /// </summary>
        [XmlElement(ElementName = "mch_id")]
        public string Mch_Id { get; set; }

        /// <summary>
        /// 随机字符串
        /// 是 String(32) 5K8264ILTKCH16CQ2502SI8ZNMTM67VS 随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        [XmlElement(ElementName = "nonce_str")]
        public string Nonce_Str { get; set; }


        /// <summary>
        /// 加密信息
        ///  是 String(1024) 加密信息请用商户秘钥进行解密，详见解密方式 以下为返回的加密字段： 字段名 变量名 必填 类型 示例值 描述
        /// </summary>
        [XmlElement(ElementName = "req_info")]
        public string Req_Info { get; set; }



        /// <summary>
        /// 微信订单号
        ///  是 String(32) 1217752501201407033233368018 微信订单号
        /// </summary>
        [XmlElement(ElementName = "transaction_id")]
        public string Transaction_Id { get; set; }


        /// <summary>
        /// 商户订单号
        /// 是 String(32) 1217752501201407033233368018 商户系统内部的订单号
        /// </summary>
        [XmlElement(ElementName = "out_trade_no")]
        public string Out_Trade_No { get; set; }


        /// <summary>
        /// 微信退款单号
        /// 是 String(32) 1217752501201407033233368018 微信退款单号
        /// </summary>
        [XmlElement(ElementName = "refund_id")]
        public string Refund_Id { get; set; }


        /// <summary>
        /// 商户退款单号
        /// 是 String(64) 1217752501201407033233368018 商户退款单号
        /// </summary>
        [XmlElement(ElementName = "out_refund_no")]
        public string Out_Refund_No { get; set; }


        /// <summary>
        /// 订单金额
        /// 是 Int 100 订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        [XmlElement(ElementName = "total_fee")]
        public string Total_Fee { get; set; }


        /// <summary>
        /// 应结订单金额
        /// 否 Int 100 当该订单有使用非充值券时，返回此字段。应结订单金额=订单金额-非充值代金券金额，应结订单金额<=订单金额。
        /// </summary>
        [XmlElement(ElementName = "settlement_total_fee")]
        public string Settlement_Total_Fee { get; set; }


        /// <summary>
        /// 申请退款金额
        /// 是 Int 100 退款总金额,单位为分
        /// </summary>
        [XmlElement(ElementName = "refund_fee")]
        public string Refund_Fee { get; set; }


        /// <summary>
        /// 退款金额
        /// 是 Int 100 退款金额=申请退款金额-非充值代金券退款金额，退款金额<=申请退款金额
        /// </summary>
        [XmlElement(ElementName = "settlement_refund_fee")]
        public string Settlement_Refund_Fee { get; set; }


        /// <summary>
        /// 退款状态
        /// 是 String(16) SUCCESS SUCCESS-退款成功 CHANGE-退款异常 REFUNDCLOSE—退款关闭
        /// </summary>
        [XmlElement(ElementName = "refund_status")]
        public string Refund_Status { get; set; }


        /// <summary>
        /// 退款成功时间
        /// 否 String(20) 20160725152626
        /// </summary>
        [XmlElement(ElementName = "success_time")]
        public string Success_Time { get; set; }

        /// <summary>
        /// 退款入账账户
        /// 是 String(64) 招商银行信用卡0403 取当前退款单的退款入账方 1）退回银行卡： {银行名称  }{卡类型 }{卡尾号} 2）退回支付用户零钱: 支付用户零钱 3）退还商户: 商户基本账户 商户结算银行账户 4）退回支付用户零钱通: 支付用户零钱通
        /// </summary>
        [XmlElement(ElementName = "refund_recv_accout")]
        public string Refund_Recv_Accout { get; set; }


        /// <summary>
        /// 退款资金来源
        /// 是 String(30) REFUND_SOURCE_RECHARGE_FUNDS REFUND_SOURCE_RECHARGE_FUNDS 可用余额退款/基本账户 REFUND_SOURCE_UNSETTLED_FUNDS 未结算资金退款
        /// </summary>
        [XmlElement(ElementName = "refund_account")]
        public string Refund_Account { get; set; }


        /// <summary>
        /// 退款发起来源
        /// 是 String(30) API API接口 VENDOR_PLATFORM商户平台
        /// </summary>
        [XmlElement(ElementName = "refund_request_source")]
        public string Refund_Request_Source { get; set; }

    }
}