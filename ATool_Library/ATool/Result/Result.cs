namespace ATool
{
    /// <summary>
    /// 返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result
    {
        /// <summary>
        /// 返回值异常
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <returns></returns>
        public new static Result<T> Error(string message)
        {
            return new Result<T>
            {
                Code = 1,
                Message = message,
                TotalCount = 0
            };
        }

        /// <summary>
        /// 返回结果主体
        /// </summary>
        public T Data { get; set; }
    }

    /// <summary>
    /// 返回类
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 返回值异常
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <returns></returns>
        public static Result Error(string message)
        {
            return new Result()
            {
                Code = 1,
                Message = message
            };
        }

        /// <summary>
        /// 返回值成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static Result<T> Ok<T>(T data)
        {
            return new Result<T>
            {
                Code = 0,
                Message = string.Empty,
                Data = data
            };
        }

        /// <summary>
        /// 返回值成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="count">数据的行数</param>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static Result<T> Ok<T>(T data, int count)
        {
            return new Result<T>
            {
                Code = 0,
                Message = string.Empty,
                TotalCount = count,
                Data = data
            };
        }

        /// <summary>
        /// 0 正常，1 错误
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回函数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess => Code == 0;
    }
}