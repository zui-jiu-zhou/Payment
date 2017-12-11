using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    public class OrderQuery : ApiBase<OrderQueryResult>
    {
        private const string _url = "https://api.mch.weixin.qq.com/pay/orderquery";

        public override string ApiURL => _url;

        public OrderQuery()
        {
            AddParamDefinitionSelection(new ParamDefinition[] {
                new ParamDefinition("transaction_id", true, 1, 32),
                new ParamDefinition("out_trade_no", true, 1, 32)
            });
        }

        /// <summary>
        /// 快速设置微信订单号
        /// 与商家订单号之间只用设置其中一个
        /// 微信的订单号，建议优先使用
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public OrderQuery TSetTransactionId(string value)
        {
            AddParam("transaction_id", value);
            return this;
        }
        /// <summary>
        /// h5支付值为mweb，请勿修改
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public OrderQuery TSetOutTradeNo(string value)
        {
            AddParam("out_trade_no", value);
            return this;
        }
    }
}