
namespace MVVMLib
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A notification mediator.
    /// </summary>
    public class Mediator
    {
        private static IDictionary<string, List<Action<object>>> map = new Dictionary<string, List<Action<object>>>();

        /// <summary>
        /// Notify subscribers.
        /// </summary>
        /// <param name="token">The target notification token.</param>
        /// <param name="args">The callback arguments.</param>
        public static void Notify(string token, object args)
        {
            if (map.ContainsKey(token))
            {
                foreach (var callback in map[token])
                {
                    callback(args);
                }
            }
        }

        /// <summary>
        /// Subscribe to notifications.
        /// </summary>
        /// <param name="token">The token to subscribe to.</param>
        /// <param name="callback">The callback activity.</param>
        public static void Subscribe(string token, Action<object> callback)
        {
            if (!map.ContainsKey(token))
            {
                var callbacks = new List<Action<object>>();
                callbacks.Add(callback);
                map.Add(token, callbacks);
            }
            else
            {
                bool isFound = false;

                foreach (var item in map[token])
                {
                    string existingCallback = $"{item.Target.ToString()}.{item.Method.ToString()}";
                    string newCallback = $"{callback.Target.ToString()}.{callback.Method.ToString()}";

                    if (newCallback.Equals(existingCallback))
                    {
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                {
                    map[token].Add(callback);
                }
            }
        }

        /// <summary>
        /// Unsubscribe to a notification token.
        /// </summary>
        /// <param name="token">The target notification token.</param>
        /// <param name="callback">The action to unsubscribe.</param>
        public static void Unsubscribe(string token, Action<object> callback)
        {
            if (map.ContainsKey(token))
            {
                map[token].Remove(callback);
            }
        }
    }
}
