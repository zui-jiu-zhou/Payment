using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    public enum SignatureAlgorithm : int
    {
        [EnumValue("MD5")]
        MD5=1,
        [EnumValue("HMAC-SHA256")]
        HMAC_SHA256=2
    }
}