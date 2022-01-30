using System;
using System.Collections.Generic;

namespace DefaultNamespace.Common
{
    public class ListObservable <T>
    {
        private List<T> _value;
        private Dictionary<string, Action<List<T>>> _subscribersOnListChange = new Dictionary<string, Action<List<T>>>();

        public ListObservable()
        {
            _value = new List<T>(); 
        }
        
        public ListObservable(List<T> value)
        {
            _value = value;
        }

        public List<T> GetCopy()
        {
            // копия только по смыслу. ничего в префсах измзеняться не будет и подписчики не дёрнутся.
            return _value;
        }

        public void SetValues(List<T> list)
        {
            _value = new List<T>(list);
            foreach (var pair in _subscribersOnListChange)
            {
                pair.Value.Invoke(_value);
            }
        }
        
        public void Add(T v) 
        {
            _value.Add(v);
            foreach (var pair in _subscribersOnListChange)
            {
                pair.Value.Invoke(_value);
            }
        }

        public void Remove(T v)
        {
            _value.Remove(v);
            foreach (var pair in _subscribersOnListChange)
            {
                pair.Value.Invoke(_value);
            }
        }

        public string SubscribeForChanges(Action<List<T>> subscriber, bool invokeOnSubscription = false)
        {
            string guid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            
            _subscribersOnListChange[guid] = subscriber;
            if (invokeOnSubscription)
            {
                subscriber.Invoke(_value);
            }

            return guid;
        }

        public void UnsubscribeFromChanges(string guid)
        {
            _subscribersOnListChange.Remove(guid);
        }
    }
}