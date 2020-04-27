using System.Collections.Generic;

namespace JassToCsMain
{
    public static class Extensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            return dictionary != null && key != null
                && dictionary.TryGetValue(key, out TValue value) ? value : defaultValue;
        }
    }
}
