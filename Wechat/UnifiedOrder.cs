using System.Reflection;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    public class UnifiedOrder : ApiBase<UnifiedOrderResult>
    {
        const string _url = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        public enum Scenes : int
        {
            [EnumValue("{{\"h5_info\": {{\"type\":\"Android\",\"app_name\": \"{0}\",\"package_name\": \"{1}\"}}}}")]
            AndroidApp =1,
            [EnumValue("{{\"h5_info\": {{\"type\":\"IOS\",\"app_name\": \"{0}\",\"bundle_id\": \"{1}\"}}}}")]
            IosApp =2,
            [EnumValue("{{\"h5_info\": {{\"type\":\"Wap\",\"wap_url\": \"{0}\",\"wap_name\": \"{1}\"}}}}")]
            MobileWeb=3
        }

        public override string ApiURL { get { return _url;  } }

        public UnifiedOrder()
        {
            AddParamDefinitions(new ParamDefinition[]{
                new ParamDefinition("device_info", false, 1, 32),
                new ParamDefinition("body", true, 1, 128),
                new ParamDefinition("details", false, 1, 6000),
                new ParamDefinition("attach", false, 1, 127),
                new ParamDefinition("out_trade_no", true, 1, 32),
                new ParamDefinition("fee_type", false, 1, 16),
                new ParamDefinition("total_fee", true, 1, 12, ParamType.Int),
                new ParamDefinition("spbill_create_ip", true, 7, 16),
                new ParamDefinition("time_start", false, 14, 14, ParamType.DateTime),
                new ParamDefinition("time_expire", false, 14, 14, ParamType.DateTime),
                new ParamDefinition("goods_tag", false, 1, 32),
                new ParamDefinition("notify_url", true, 1, 256, ParamType.URL),
                new ParamDefinition("trade_type", true, 1, 16),
                new ParamDefinition("product_id", false, 1, 32),
                new ParamDefinition("limit_pay", false, 1, 32),
                new ParamDefinition("openid", false, 1, 128),
                new ParamDefinition("scene_info", true, 1, 256)
             });
            TSetTradeType();
        }

        /// <summary>
        /// 快速设置商品描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder TSetBody(string value)
        {
            AddParam("body", value);
            return this;
        }
        /// <summary>
        /// 快速设置商家订单号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder TSetOutTradeNo(string value)
        {
            AddParam("out_trade_no", value);
            return this;
        }
        /// <summary>
        /// 快速设置总金额，单位为分
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder TSetTotalFee(string value)
        {
            AddParam("total_fee", value);
            return this;
        }
        /// <summary>
        /// 快速设置订单提交ip
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder TSetSpbillCreateIp(string value)
        {
            AddParam("spbill_create_ip", value);
            return this;
        }
        /// <summary>
        /// 快速设置通知url
        /// 接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder TSetNotifyUrl(string value)
        {
            AddParam("notify_url", value);
            return this;
        }
        /// <summary>
        /// 默认为MWEB
        /// h5支付值为MWEB，请勿修改
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder TSetTradeType(string value= "MWEB")
        {
            AddParam("trade_type", value);
            return this;
        }
        /// <summary>
        /// 快速设置场景信息
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder TSetSceneInfo(Scenes scene, string str1, string str2)
        {
            var _body = (scene.GetType().GetField(scene.ToString()).GetCustomAttribute(typeof(EnumValueAttribute)) as EnumValueAttribute).Value;
            var _scene = string.Format(_body, str1, str2);
            AddParam("scene_info", _scene);
            return this;
        }
        /// <summary>
        /// 快速设置设备号
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetDeviceInfo(string value)
        {
            AddParam("device_info", value);
            return this;
        }
        /// <summary>
        /// 快速设置商品详情
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetDetail(string value)
        {
            AddParam("device_info", value);
            return this;
        }
        /// <summary>
        /// 快速设置附加数据
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetAttach(string value)
        {
            AddParam("attach", value);
            return this;
        }
        /// <summary>
        /// 快速设置货币类型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetFeeType(string value)
        {
            AddParam("fee_type", value);
            return this;
        }
        /// <summary>
        /// 快速设置交易起始时间
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetTimeStart(string value)
        {
            AddParam("time_start", value);
            return this;
        }
        /// <summary>
        /// 快速设置交易结束时间
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetTimeExpire(string value)
        {
            AddParam("time_expire", value);
            return this;
        }
        /// <summary>
        /// 快速设置商品标记
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetGoodsTag(string value)
        {
            AddParam("goods_tag", value);
            return this;
        }
        /// <summary>
        /// 快速设置商品id
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetProductId(string value)
        {
            AddParam("product_id", value);
            return this;
        }
        /// <summary>
        /// 快速设置支付方式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetLimitPay(string value)
        {
            AddParam("limit_pay", value);
            return this;
        }
        /// <summary>
        /// 快速设置用户标识
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public UnifiedOrder SetOpenId(string value)
        {
            AddParam("openid", value);
            return this;
        }
       
    }
}