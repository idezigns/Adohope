using Adohope.Shared.Utils;
using PListNet;
using PListNet.Nodes;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace Adohope.Shared.PList
{
    public class DynamicPList : DynamicObject
    {

        #region Constructor

        public DynamicPList(Stream stream)
        {
            RootNode = PListUtils.Load(stream);
        }
        public DynamicPList(byte[] buffer)
        {
            RootNode = PListUtils.Load(buffer);
        }
        public DynamicPList(string filePath)
        {
            RootNode = PListUtils.Load(filePath);
        }
        #endregion

        #region Fields
        
        protected DictionaryNode _rootNode;
        
        /**
         * string Key: The key name without spaecs.
         * string Value: The original key name with spaces.
         * */
        protected Dictionary<string, string> _keysDictionary;

        protected IBackup _backup;

        #endregion

        #region Properties

        public DictionaryNode RootNode
        {
            get => _rootNode;
            protected set
            {
                _rootNode = value;

                _keysDictionary = new Dictionary<string, string>();

                string[] keys = new string[RootNode.Keys.Count];
                RootNode.Keys.CopyTo(keys, 0);

                for (int i = 0; i < keys.Length; i++)
                {
                    _keysDictionary.Add(keys[i].Replace(" ", ""), keys[i]);
                }
            }
        }

        public int Count => RootNode.Count;

        #endregion

        #region DynamicObject

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!_keysDictionary.ContainsKey(binder.Name))
            {
                result = null;
                return false;
            }

            string name = _keysDictionary[binder.Name];

            // Try to just return the value of the simple data types like string and boolean
            PNode resultObject;

            bool tryGetValueResult = RootNode.TryGetValue(name, out resultObject);

            object valuePropertyValue = resultObject?.GetType().GetProperty("Value")?.GetValue(resultObject);

            result = valuePropertyValue != null
                ? valuePropertyValue
                : resultObject;

            return tryGetValueResult;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (_keysDictionary.ContainsKey(binder.Name))
                RootNode[_keysDictionary[binder.Name]] = (PNode)value;

            else
            {
                _keysDictionary.Add(binder.Name, binder.Name);

                RootNode.Add(new KeyValuePair<string, PNode>(_keysDictionary[binder.Name], (PNode)value));
            }

            return true;
        }
        public void AddItem(string key, PNode value)
        {
            _keysDictionary.Add(key.Replace(" ", ""), key);

            RootNode.Add(key, value);
        }

        #endregion
    }
}
