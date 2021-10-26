using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TracingSystem.Models
{
    public class ServiceResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }

        public object Data { get; set; }

        /// <summary>
        /// 設定成功回傳結果
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        /// <param name="message">訊息</param>
        /// <param name="data">回傳資料</param>
        public static ServiceResult Success(string message = "", object data = null)
        {
            return new ServiceResult()
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 設定失敗回傳結果
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ServiceResult Fail(string message, object data = null)
        {
            return new ServiceResult()
            {
                IsSuccess = false,
                Message = message,
                Data = data
            };
        }

        public static ServiceResult Result(bool success, string message, object data)
        {
            return new ServiceResult()
            {
                IsSuccess = success,
                Message = message,
                Data = data
            };
        }
    }
}
