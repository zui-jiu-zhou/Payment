using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    public class RefundQuery : ApiBase<RefundQueryResult>
    {
        const string _URL = "https://api.mch.weixin.qq.com/pay/refundquery";

        public override string ApiURL => _URL;

        public RefundQuery()
        {
            AddParamDefinitions(new ParamDefinition[] {
                new ParamDefinition("offset", false, 1, short.MaxValue),
            });
            AddParamDefinitionSelection(new ParamDefinition[] {
                new ParamDefinition("transaction_id", true,1, 32),
                new ParamDefinition("out_trade_no", true,1, 32),
                new ParamDefinition("out_refund_no", true,1, 32),
                new ParamDefinition("refund_id", true,1, 64),
            });
        }

        void Test(ParamDefinitionTestEventArgs e)
        {
            
        }
    }
}