using System;
using System.Collections.Generic;
using UnityEditor;

namespace DefaultNamespace.Common
{
    public class Observable<T>
    {
        private T _value;
        private Dictionary<string, Action<T>> _subscribers = new Dictionary<string, Action<T>>();

        public Observable(T value)
        {
            _value = value;
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                foreach (var pair in _subscribers)
                {
                    pair.Value.Invoke(value);
                }
            }
        }

        public string Subscribe(Action<T> subscriber, bool invokeOnSubscription = false)
        {
            string guid = DateTime.Now.ToString("yyyyMMddHHmmss");
            
            _subscribers[guid] = subscriber;
            if (invokeOnSubscription)
            {
                subscriber.Invoke(Value);
            }

            return guid;
        }

        public void Unsubscribe(string guid)
        {
            _subscribers.Remove(guid);
        }

    }
}