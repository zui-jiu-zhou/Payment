using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    [Serializable]
    [XmlRootAttribute("xml", Namespace = "", IsNullable = false)]
    public abstract class ResultBase
    {
        public const string FLAG_SUCCESS = "SUCCESS";

        public const string FLAG_FAIL = "FAIL";

        [XmlElement(ElementName = "return_code")]
        public string Return_Code { get; set; }

        [XmlElement(ElementName = "return_msg")]
        public string Return_Msg { get; set; }
        /// <summary>
        /// 获取一个值，该值指示请求是否成功
        /// </summary>
        public bool IsRequestSuccessfully
        {
            get
            {
                return Return_Code == FLAG_SUCCESS || Return_Code == FLAG_FAIL;
            }
        }
        /// <summary>
        /// 获取一个值，该值指示业务处理是否成功
        /// </summary>
        public virtual bool IsSuccessful
        {
            get
            {
                return Return_Code == FLAG_SUCCESS;
            }
        }
    }
}