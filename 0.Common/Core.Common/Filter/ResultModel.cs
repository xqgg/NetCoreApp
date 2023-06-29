using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Filter
{
    public class ResultModel
    {
        /// <summary>
        /// 服务返回的状态
        /// </summary>
        public ResultCode Code { get; set; }

        /// <summary>
        /// 服务返回状态的提示内容
        /// </summary>
        public string? Info { get; set; }

        /// <summary>
        /// 当前数据条数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 返回的数据结果
        /// </summary>
        public object? Data { get; set; }
    }
}
