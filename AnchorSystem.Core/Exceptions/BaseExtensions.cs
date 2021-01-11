using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;

namespace AnchorSystem.Core.Exceptions
{
    /// <summary>
    /// 常用扩展
    /// </summary>
    public static class BaseExtensions
    {
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static int ToInt(this string str)
        {
            if (int.TryParse(str, out var result))
                return result;
            throw new AbandonedMutexException(str + " 不能转换为Int");
        }

        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);
        public static T FromJson<T>(this string jsonStr) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
            catch
            {
                throw new Exception("DeserializeObject Error");
            }
        }

        public static byte[] ToBytes(this object obj) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
    }
}
