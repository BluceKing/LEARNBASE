using System;

namespace AnchorSystem.Core.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public int HttpStatusCode { get; set; } = 200;

        /// <summary>
        /// Additional information about the exception.
        /// </summary>
        public object Details { get; private set; }

        public string Host { get; set; }

        public ApiErrorCode ErrorCode { get; set; }

        public bool IsLog { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public UserFriendlyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="errorCode">错误码</param>
        /// <param name="httpStatusCode">响应码</param>
        /// <param name="islog">是否记录日志</param>
        public UserFriendlyException(object message,
            ApiErrorCode errorCode,
            int httpStatusCode = 200, bool islog = true)
            : base($"{message} - {(int)errorCode}")
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
            IsLog = islog;
        }

        public UserFriendlyException(ApiErrorCode errorCode,
            int httpStatusCode = 200)
            : base(errorCode.ToString())
        {
            Details = errorCode.ToString();
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
        }
    }
}
