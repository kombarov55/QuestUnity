using System;
using System.Collections.Generic;

namespace DefaultNamespace.Common
{
    public class SignalObservable
    {
        private Dictionary<string, Action> _subscribers = new Dictionary<string, Action>();
        
        public void Emit()
        {
            foreach (var pair in _subscribers)
            {
                pair.Value.Invoke();
            }
        }

        public string Subscribe(Action subscriber, bool invokeOnSubscription = false)
        {
            string guid = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            
            _subscribers[guid] = subscriber;
            if (invokeOnSubscription)
            {
                subscriber.Invoke();
            }

            return guid;
        }

        public void Unsubscribe(string guid)
        {
            _subscribers.Remove(guid);
        }
    }
}