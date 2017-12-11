using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    public delegate void ParamDefinitionTestEventHandler(ParamDefinitionTestEventArgs e);

    public class ParamDefinitionTestEventArgs: EventArgs
    {
        /// <summary>
        /// 获取或设置一个值该值指示是否继续检测，如果为true则Result会覆盖，默认为true
        /// </summary>
        public bool Continue { get; set; } = true;

        /// <summary>
        /// 获取或设置一个值，该值为检测结果
        /// </summary>
        public bool Result
        {
            get;set;
        }

        public ParamDefinition Definition { get; }

        public ParamDefinitionTestEventArgs(ParamDefinition definition)
        {
            Definition = definition;
        }
    }
}