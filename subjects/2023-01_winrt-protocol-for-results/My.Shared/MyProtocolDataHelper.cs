using Windows.Foundation.Collections;

namespace My
{
    public static class MyProtocolDataHelper 
    {
        public static string GetRequestMessage(this ValueSet values) => GetValue<string>(values, "Request");

        public static ValueSet SetRequestMessage(this ValueSet values, string value) => SetValue(values, "Request", value);

        public static string GetResponseMessage(this ValueSet values) => GetValue<string>(values, "Response");

        public static ValueSet SetResponseMessage(this ValueSet values, string value) => SetValue(values, "Response", value);


        static T GetValue<T>(ValueSet values, string key)
        {
            return values.TryGetValue(key, out var obj) && obj is T s ? s : default;
        }

        static ValueSet SetValue<T>(ValueSet values, string key, T value)
        {
            values[key] = value;

            return values;
        }
    }
}
