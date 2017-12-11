using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    public class ParamDefinition
    {
        const string _DATE = @"^(?<year>\\d{4})(?<month>\\d{2})(?<day>\\d{2})$";//20170101
        const string _TIME = "\\d{6}";// @"^(?<hour>\\d{2})(?<minute>\\d{2})(?<second>\\d{2})$";//235959
        const string _DATETIME = "\\d{14}";//@"^(?<year>\\d{4})(?<month>\\d{2})(?<day>\\d{2})(?<hour>\\d{2})(?<minute>\\d{2})(?<second>\\d{2})$";
        const string _URL = @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";

        /// <summary>
        /// 检测开始时发生
        /// </summary>
        public event ParamDefinitionTestEventHandler BeforeTest;

        /// <summary>
        /// 获取参数名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 获取一个值，该值指示参数是不是必需的
        /// </summary>
        public bool Requierd { get; }
        /// <summary>
        /// 获取一个值，该值指示参数的最小长度
        /// </summary>
        public int MinLength { get; }
        /// <summary>
        /// 获取一个值，该值指示参数的最大长度
        /// </summary>
        public int MaxLength { get; }
        /// <summary>
        /// 获取一个值，该值指示参数类型
        /// </summary>
        public ParamType Type { get; } 
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="required"></param>
        /// <param name="minlength"></param>
        /// <param name="maxlength"></param>
        /// <param name="type"></param>
        public ParamDefinition(string name, bool required = true, int minlength = 0, int maxlength = 256, ParamType type = ParamType.Text)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception($"参数{nameof(name)}不能为空");
            if (minlength < 0) throw new Exception($"参数{nameof(minlength)}不能为空");
            if (maxlength < 0) throw new Exception($"参数{nameof(maxlength)}不能为空");
            if (maxlength < minlength) throw new Exception($"参数{nameof(maxlength)}不能小于参数{nameof(minlength)}");
            Requierd = required;
            MaxLength = maxlength;
            MinLength = minlength;
            Type = type;
            Name = name;
        }
        /// <summary>
        /// 用当前定义检测一个值是否合法
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool Test(string value)
        {
            var _be = new ParamDefinitionTestEventArgs(this);
            BeforeTest?.Invoke(_be);
            if (_be.Continue)
            {
                var _return = false;
                switch (Type)
                {
                    case ParamType.Text:
                        if (Requierd)
                        {
                            _return = value != null && value.Length >= MinLength && value.Length <= MaxLength;
                        }
                        else
                        {
                            _return = value == null || value.Length >= MinLength && value.Length <= MaxLength;
                        }
                        break;
                    case ParamType.URL:
                        bool _result = Regex.IsMatch(value ?? "", _URL);
                        if (Requierd)
                        {
                            _return = _result;
                        }
                        else
                        {
                            _return = value == null || _result;
                        }
                        break;
                    case ParamType.Int:
                        int _intVal;
                        _result = int.TryParse(value, out _intVal);
                        if (Requierd)
                        {
                            _return = _result;
                        }
                        else
                        {
                            _return = value == null || _result;
                        }
                        break;
                    case ParamType.Double:
                        double _doubleVal;
                        _result = double.TryParse(value, out _doubleVal);
                        if (Requierd)
                        {
                            _return = _result;
                        }
                        else
                        {
                            _return = value == null || _result;
                        }
                        break;
                    case ParamType.Date:
                        _result = Regex.IsMatch(value ?? "", _DATE);
                        if (Requierd)
                        {
                            _return = _result;
                        }
                        else
                        {
                            _return = value == null || _result;
                        }
                        break;
                    case ParamType.Time:
                        _result = Regex.IsMatch(value ?? "", _TIME);
                        if (Requierd)
                        {
                            _return = _result;
                        }
                        else
                        {
                            _return = value == null || _result;
                        }
                        break;
                    case ParamType.DateTime:
                        _result = Regex.IsMatch(value ?? "", _DATETIME);
                        if (Requierd)
                        {
                            _return = _result;
                        }
                        else
                        {
                            _return = value == null || _result;
                        }
                        break;
                    default:
                        _return = true;
                        break;
                }
                return _return;
            }
            else
            {
                return _be.Result;
            }
        }
    }
}