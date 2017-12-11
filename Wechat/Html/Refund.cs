using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Wechat.Html
{
    public class Refund : ApiBase<RefundResult>
    {
        const string _URL = "https://api.mch.weixin.qq.com/secapi/pay/refund";
        public override string ApiURL => _URL;

        public Refund()
        {
            AddParamDefinitions(
                new ParamDefinition[] 
                {
                    new ParamDefinition("out_refund_no", true, 1, 64),
                    new ParamDefinition("total_fee", true, 1, 12, ParamType.Int),
                    new ParamDefinition("refund_fee", true, 1, 12, ParamType.Int),
                    new ParamDefinition("refund_fee_type", false, 1, 8),
                    new ParamDefinition("refund_desc", false, 1, 80),
                    new ParamDefinition("refund_account", false, 1, 30),
                });
            AddParamDefinitionSelection(
                new ParamDefinition[]
                {
                    new ParamDefinition("transaction_id", true, 1, 32),
                    new ParamDefinition("out_trade_no", true, 1, 32),
                });
        }

        /// <summary>
        /// 快速设置微信生成的订单号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Refund TSetTransactionId(string value)
        {
            AddParam("transaction_id", value);
            return this;
        }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Refund TSetOutTradeNo(string value)
        {
            AddParam("out_trade_no", value);
            return this;
        }

        /// <summary>
        /// 
        /// 与商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Refund TSetOutRefundNo(string value)
        {
            AddParam("out_refund_no", value);
            return this;
        }

        /// <summary>
        /// 订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Refund TSetTotalFee(string value)
        {
            AddParam("total_fee", value);
            return this;
        }
        /// <summary>
        /// 退款总金额，订单总金额，单位为分，只能为整数，详见支付金额
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Refund TSetRefundFee(string value)
        {
            AddParam("refund_fee", value);
            return this;
        }
        /// <summary>
        /// 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Refund SetRefundFeeType(string value)
        {
            AddParam("refund_fee_type", value);
            return this;
        }
        /// <summary>
        /// 若商户传入，会在下发给用户的退款消息中体现退款原因
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Refund SetRefundDesc(string value)
        {
            AddParam("refund_desc", value);
            return this;
        }
        /// <summary>
        /// 仅针对老资金流商户使用
        /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款（默认使用未结算资金退款）
        /// REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Refund SetRefundAccount(string value)
        {
            AddParam("refund_account", value);
            return this;
        }
    }
}