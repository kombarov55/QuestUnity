using System;
using System.Collections.Generic;

namespace DefaultNamespace.Common
{
    public class Observable<T>
    {
        private T _value;
        private List<Action<T>> _subscribers = new List<Action<T>>();

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
                foreach (var subscriber in _subscribers)
                {
                    subscriber.Invoke(value);
                }
            }
        }

        public void Subscribe(Action<T> subscriber, bool invokeOnSubscription = false)
        {
            _subscribers.Add(subscriber);
            if (invokeOnSubscription)
            {
                subscriber.Invoke(Value);
            }
        }
        
        
        
        
    }
}