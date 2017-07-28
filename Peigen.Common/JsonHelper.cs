using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Common
{
    public static class JsonHelper
    {
        static JsonHelper()
        {

        }

        public static object Deserialize(string content, Type deserializeType)
        {
            object result = null;

            try
            {
                result = JsonConvert.DeserializeObject(content, deserializeType);
            }
            catch (Exception err)
            {
                throw new Exception(string.Format("传入了错误的数据，无法转换成{0}类型，Content：{1}", deserializeType.Name, content), err);
            }

            return result;
        }

        public static T Deserialize<T>(string content)
        {
            T result = default(T);
            try
            {
                result = JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception err)
            {
                throw new Exception(string.Format("传入了错误的数据，无法转换成{0}类型，Content：{1}", typeof(T).Name, content), err);
            }

            return result;
        }

        public static string Serialize(object obj)
        {
            string result = null;
            try
            {
                result = JsonConvert.SerializeObject(obj);
            }
            catch (Exception err)
            {
                throw new Exception(string.Format("传入了错误的数据，无法转类型{0}无法转换成JSON格式", obj.GetType().Name), err);
            }

            return result;
        }
    }
}
