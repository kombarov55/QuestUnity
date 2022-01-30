using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace.Common
{
    public class DictionaryObservable<K, V>
    {
        private Dictionary<K, V> _innerDictionary;
        
        private Dictionary<string, Action<Dictionary<K, V>>> _subscribersOnDictChange = new Dictionary<string, Action<Dictionary<K, V>>>();

        public DictionaryObservable()
        {
            _innerDictionary = new Dictionary<K, V>();
        }

        public DictionaryObservable(Dictionary<K, V> innerDictionary)
        {
            _innerDictionary = innerDictionary;
        }

        public V this[K key]
        {
            get => _innerDictionary[key];
            set
            {
                _innerDictionary[key] = value;
                foreach (var pair in _subscribersOnDictChange)
                {
                    pair.Value.Invoke(_innerDictionary);
                }
            }
        }

        public void SetValues(Dictionary<K, V> v)
        {
            _innerDictionary = v;

            foreach (var pair in _subscribersOnDictChange)
            {
                pair.Value.Invoke(v);
            }
        }

        public bool Contains(K key)
        {
            return _innerDictionary.ContainsKey(key);
        }

        public void Remove(K key)
        {
            V value = _innerDictionary[key];
            _innerDictionary.Remove(key);
            foreach (var pair in _subscribersOnDictChange)
            {
                pair.Value.Invoke(_innerDictionary);
            }
        }

        public void SubscribeOnChanges(Action<Dictionary<K, V>> action)
        {
            string guid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            _subscribersOnDictChange[guid] = action;
        }

        public void Unsubscribe(string guid)
        {
            _subscribersOnDictChange.Remove(guid);
        }

    }
}