using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumValueAttribute : Attribute
    {
        public string Value { get; }


        public EnumValueAttribute(string value)
        {
            Value = value;
        }
    }
}