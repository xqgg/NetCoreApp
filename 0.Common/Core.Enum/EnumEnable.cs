using System.ComponentModel;

namespace Core.Enum
{
    /// <summary>
    /// 状态
    /// </summary>
    public enum EnumEnable
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 1,

        /// <summary>
        /// 停用
        /// </summary>
        [Description("停用")]
        Deactivate = 0,
    }


}