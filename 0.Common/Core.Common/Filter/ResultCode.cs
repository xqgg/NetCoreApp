using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Filter
{
    /// <summary>
    /// 代码枚举值
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        [Text("操作成功")]
        SUCCESS = 0,
        /// <summary>
        /// 操作失败
        /// </summary>
        [Text("操作失败")]
        FAIL = 1,
        /// <summary>
        /// 用户无此权限
        /// </summary>
        [Text("用户无此权限")]
        NOPERMISSION = 2,
        /// <summary>
        /// 查无此用户信息
        /// </summary>
        [Text("查无此用户信息")]
        NOUSER = 3,
        /// <summary>
        /// 此用户权限已经被禁用
        /// </summary>
        [Text("此用户权限已经被禁用")]
        USER_PROHIBIT = 4,
        /// <summary>
        /// 密码错误
        /// </summary>
        [Text("密码错误")]
        ERROR_PASSWORD = 5,
        /// <summary>
        /// 数据不存在
        /// </summary>
        [Text("数据不存在")]
        NO_DATA = 6,
        /// <summary>
        /// 参数不能为空
        /// </summary>
        [Text("参数不能为空")]
        NO_EMPTY = 7,
        /// <summary>
        /// 重复数据
        /// </summary>
        [Text("重复数据")]
        REPEAT_DATA = 8,
        /// <summary>
        /// 用户已被禁用
        /// </summary>
        [Text("用户已被禁用")]
        PROHIBIT = 9,
        /// <summary>
        /// 数据被占用
        /// </summary>
        [Text("数据被占用")]
        OCCUPY = 10,
        /// <summary>
        /// 父级编号不存在
        /// </summary>
        [Text("父级编号不存在")]
        NO_PARENT_DATA = 11,
        /// <summary>
        /// 无效参数
        /// </summary>
        [Text("无效参数")]
        NO_PARAM = 12,
        /// <summary>
        /// 无效参数
        /// </summary>
        [Text("操作进行中")]
        PROGRESSING = 13,
        /// <summary>
        /// token验证失败
        /// </summary>
        [Text("无权限")]
        NO_AUTHOR = 401,
        /// <summary>
        /// 资源丢失
        /// </summary>
        [Text("资源丢失")]
        RESOURCE_LOSS = 404,
        /// <summary>
        /// 服务内部异常
        /// </summary>
        [Text("服务内部异常")]
        MethodException = 500,
    }
}
