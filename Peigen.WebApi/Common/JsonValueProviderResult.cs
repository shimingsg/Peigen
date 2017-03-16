using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peigen.WebApi
{
    public class JsonValueProviderResult : ValueProviderResult
    {
        public JsonValueProviderResult(object rawValue, string attemptedValue, CultureInfo culture) : base(rawValue, attemptedValue, culture)
        { }

        public override object ConvertTo(Type type, CultureInfo culture)
        {
            if (RawValue != null)
            {
                string content = RawValue.ToString();
                try
                {
                    JsonSerializerSettings setting = new JsonSerializerSettings();
                    return JsonConvert.DeserializeObject(content, type);
                }
                catch (Exception err)
                {
                    throw new Exception($"无法转换成{type.Name}类型", err);
                }
            }

            return null;
        }
    }
}