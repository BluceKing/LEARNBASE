using Newtonsoft.Json;

namespace AnchorSystem.Core.Exceptions
{
    /// <summary>
    /// API 返回结果
    /// </summary>
    public class ApiResult<T>
    {
        public ApiResult()
        {

        }

        public ApiResult(T data)
        {
            Data = data;
        }

        public ApiResult(UserFriendlyException ex)
        {
            Success = false;

            ErrorCode = ex.ErrorCode;
            ErrorMessage = ex.Message;
            Host = ex.Host;
        }

        /// <summary>
        /// 请求成功
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 错误代码 如果是空值
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]  // 如果是空值,序列化会跳过此字段
        public ApiErrorCode? ErrorCode { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// HTTP请求ID
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TraceId { get; set; }

        /// <summary>
        /// 服务器主机名称
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Host { get; set; }

    }
}
