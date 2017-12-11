using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Wechat
{
    public enum ParamType : int
    {
        Text=1,
        URL=2,
        Int=3,
        Double=4,
        Date=5,
        Time=6,
        DateTime=7

    }
}