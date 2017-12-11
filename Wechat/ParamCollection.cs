using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiMeng.Core.WeiXin.Helper.H5Pay
{
    public class ParamCollection : IReadOnlyDictionary<string, string>
    {
        private Dictionary<string, string> _inner = new Dictionary<string, string>();

        public string this[string key] => ((IReadOnlyDictionary<string, string>)_inner)[key];

        public IEnumerable<string> Keys => ((IReadOnlyDictionary<string, string>)_inner).Keys;

        public IEnumerable<string> Values => ((IReadOnlyDictionary<string, string>)_inner).Values;

        public int Count => ((IReadOnlyDictionary<string, string>)_inner).Count;

        public bool ContainsKey(string key)
        {
            return ((IReadOnlyDictionary<string, string>)_inner).ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return ((IReadOnlyDictionary<string, string>)_inner).GetEnumerator();
        }

        public bool TryGetValue(string key, out string value)
        {
            return ((IReadOnlyDictionary<string, string>)_inner).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyDictionary<string, string>)_inner).GetEnumerator();
        }

        /// <summary>
        /// 添加指定名称的参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, string value)
        {
            if (ContainsKey(name))
            {
                _inner[name] = value;
            }
            else
            {
                _inner.Add(name, value);
            }
        }
        /// <summary>
        /// 移除指定名称的参数
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            _inner.Remove(name);
        }
    }
}