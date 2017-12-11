using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment.Wechat
{
    public class ParamDefinitionCollection : IReadOnlyList<ParamDefinition>
    {
        private List<ParamDefinition> _inner = new List<ParamDefinition>();

        private List<List<ParamDefinition>> _selections = new List<List<ParamDefinition>>();

        public ParamDefinition this[int index] => ((IReadOnlyList<ParamDefinition>)_inner)[index];

        public int Count => ((IReadOnlyList<ParamDefinition>)_inner).Count;

        public IEnumerator<ParamDefinition> GetEnumerator()
        {
            return ((IReadOnlyList<ParamDefinition>)_inner).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IReadOnlyList<ParamDefinition>)_inner).GetEnumerator();
        }
        /// <summary>
        /// 添加参数定义，参数定义名称不能重复
        /// </summary>
        /// <param name="definition"></param>
        public void Add(ParamDefinition definition)
        {
            if(_inner.Count(t=>t.Name == definition.Name) == 0)
            {
                _inner.Add(definition);
            }
            else
            {
                throw new Exception($"存在相同名称的参数定义\"{definition.Name}\"");
            }
        }
        /// <summary>
        /// 添加参数定义集合
        /// </summary>
        /// <param name="definitions"></param>
        public void Add(IEnumerable<ParamDefinition> definitions)
        {
            foreach (var item in definitions)
            {
                Add(item);
            }
        }
        /// <summary>
        /// 添加参数选择分组，此分组定义的参数至少指定一个
        /// </summary>
        /// <param name="definitions"></param>
        public void AddSelection(IEnumerable<ParamDefinition> definitions)
        {
            Add(definitions);
            _selections.Add(definitions.ToList());

        }
        /// <summary>
        /// 移除指定名称的参数定义
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            _inner.Remove(_inner.FirstOrDefault(t=>t.Name == name));
            foreach (var item in _selections)
            {
                item.Remove(item.FirstOrDefault(t=>t.Name == name));
            }
        }
        /// <summary>
        /// 用本定义集合检测指定的参数集合是否合法
        /// </summary>
        /// <param name="params"></param>
        public void Test(ParamCollection @params)
        {
            foreach (var item in _inner)
            {
                var _bool = @params.ContainsKey(item.Name);
                var _v = _bool ? @params[item.Name] : null;
                if (item.Requierd)
                {
                    if(!_bool)
                    {
                        var _selection = _selections.FirstOrDefault(t => t.Count(m => m.Name == item.Name) > 0);
                        if(_selection == null)
                        {
                            throw new Exception($"参数\"{item.Name}\"是必须的");
                        }
                        else
                        {
                            if(_selection.Count(t => @params.ContainsKey(t.Name)) == 0)
                            {
                                throw new Exception($"参数{string.Join(",", _selection.Select((v, i) => v.Name))}必须指定一个");
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                if (item.Test(_v))
                {
                    continue;
                }
                else
                {
                    throw new Exception($"值\"{_v}\"对于参数\"{item.Name}\"是不合法的");
                }
            }
        }
    }
}