using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileDev.App
{
    /// <summary>
    /// 结果类型
    /// </summary>
    public enum HttpResult
    {
        /// <summary>
        /// 成功
        /// </summary>
        success = 200,
        /// <summary>
        /// 警告
        /// </summary>
        warning = 201,
        /// <summary>
        /// 失败
        /// </summary>
        fail = 202,
        /// <summary>
        /// 异常
        /// </summary>
        error = 203,
        /// <summary>
        /// 超时
        /// </summary>
        timeout = 204
    }
}
