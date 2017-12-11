using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    [Serializable]
    [XmlRoot("xml", IsNullable = false)]
    public class OrderQueryResult : ResultBase
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
        public string sub_mch_id { get; set; }
        /// <summary>
        /// 设备号
        /// 否 String(32)  013467007045764	调用接口提交的终端设备号，
        /// </summary>
        [XmlElement(ElementName = "device_info")]
        public string Device_Info { get; set; }
        /// <summary>
        /// 随机字符串
        /// 是 String(32)  5K8264ILTKCH16CQ2502SI8ZNMTM67VS 微信返回的随机字符串
        /// </summary>
        [XmlElement(ElementName = "nonce_str")]
        public string Nonce_Str { get; set; }
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
        public string Err_Code { get; set; }
        /// <summary>
        /// 错误代码描述
        /// 否 String(128) 系统错误 错误返回的信息描述
        /// </summary>
        [XmlElement(ElementName = "err_code_des")]
        public string Err_Code_Des { get; set; }

        /// <summary>
        /// 用户标识
        /// 是	String(128)	oUpF8uMuAJO_M2pxb1Q9zNjWeS6o	用户在商户appid下的唯一标识
        /// </summary>
        [XmlElement(ElementName = "openid")]
        public string OpenId { get; set; }
        /// <summary>
        /// 是否关注公众账号
        /// 否	String(1)	Y	用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        /// </summary>
        [XmlElement(ElementName = "is_subscribe")]
        public string Is_Subscribe { get; set; }


        /// <summary>
        /// 交易类型
        /// 是 String(16)  JSAPI 调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，MICROPAY，详细说明见参数规定
        /// </summary>
        [XmlElement(ElementName = "trade_type")]
        public string Trade_Type { get; set; }
        /// <summary>
        /// 交易状态
        /// 是   String(32)  SUCCESS
        ///SUCCESS—支付成功
        ///REFUND—转入退款
        ///NOTPAY—未支付
        ///CLOSED—已关闭
        ///REVOKED—已撤销（刷卡支付）
        ///USERPAYING--用户支付中
        ///PAYERROR--支付失败(其他原因，如银行返回失败)
        ///支付状态机请见下单API页面
        /// </summary>
        [XmlElement(ElementName = "trade_state")]
        public string Trade_State { get; set; }

        /// <summary>
        /// 付款银行
        /// 是   String(16)  CMC 银行类型，采用字符串类型的银行标识
        /// </summary>
        [XmlElement(ElementName = "bank_type")]
        public string Bank_Type { get; set; }


        /// <summary>
        /// 标价金额
        ///   是   Int	100	订单总金额，单位为分
        /// </summary>
        [XmlElement(ElementName = "total_fee")]
        public string Total_Fee { get; set; }

        /// <summary>
        /// 应结订单金额
        ///  否   Int	100	当订单使用了免充值型优惠券后返回该参数，应结订单金额=订单金额-免充值优惠券金额。
        /// </summary>
        [XmlElement(ElementName = "settlement_total_fee")]
        public string Settlement_Total_Fee { get; set; }

        /// <summary>
        /// 标价币种
        ///  否 String(8)   CNY 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        [XmlElement(ElementName = "fee_type")]
        public string Fee_Type { get; set; }

        /// <summary>
        /// 现金支付金额
        ///  是   Int	100	现金支付金额订单现金支付金额，详见支付金额
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
        /// 微信支付订单号
        /// 是   String(32)  1009660380201506130728806387	微信支付订单号
        /// </summary>
        [XmlElement(ElementName = "transaction_id")]
        public string Transaction_Id { get; set; }

        /// <summary>
        /// 商户订单号
        /// 是   String(32)  20150806125346	商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        [XmlElement(ElementName = "out_trade_no")]
        public string Out_Trade_No { get; set; }

        /// <summary>
        /// 附加数据
        /// 否 String(128) 深圳分店 附加数据，原样返回
        /// </summary>
        [XmlElement(ElementName = "attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 支付完成时间
        /// 是   String(14)  20141030133525	订单支付时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        [XmlElement(ElementName = "time_end")]
        public string Time_End { get; set; }

        /// <summary>
        /// 交易状态描述
        /// 是   String(256) 支付失败，请重新下单支付 对当前查询订单状态的描述和下一步操作的指引
        /// </summary>
        [XmlElement(ElementName = "trade_state_desc")]
        public string Trade_State_Desc { get; set; }
        /// <summary>
        /// 获取一个值
        /// </summary>
        public override bool IsSuccessful {
            get
            {
                return Return_Code == FLAG_SUCCESS
                    && Result_Code == FLAG_SUCCESS
                    && (Trade_State == FLAG_SUCCESS);
            }
        }


    }
}