using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace Peigen.WebApi
{
    public class APIValueProvider : IValueProvider
    {
        private IDictionary<string, object> Value { get; set; }

        public APIValueProvider(IDictionary<string, object> innerDic)
        {
            Value = new Dictionary<string, object>(innerDic, StringComparer.OrdinalIgnoreCase);
        }

        public bool ContainsPrefix(string prefix)
        {
            return Value.ContainsKey(prefix);
        }

        public ValueProviderResult GetValue(string key)
        {
            if (Value.ContainsKey(key))
            {
                object value = Value[key];

                return ConvertValueResult(value);
            }

            return null;
        }

        private static Type[] jsonTypeArr = new Type[] { typeof(JObject), typeof(JToken) };

        protected virtual ValueProviderResult ConvertValueResult(object value)
        {
            if (value == null)
            {
                return null;
            }
            ValueProviderResult result = null;
            if (value == null)
                return result;

            if (jsonTypeArr.Contains(value.GetType()))
            {
                result = new JsonValueProviderResult(value, value.ToString(), CultureInfo.CurrentCulture);
            }
            else
            {
                result = new ValueProviderResult(value, value.ToString(), CultureInfo.CurrentCulture);
            }

            return result;
        }
    }
}