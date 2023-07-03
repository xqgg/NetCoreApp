using Core.Enum;

namespace Core.Models.Base
{
    public class BaseModel
    {

        /// <summary>
        /// 指定主键和自增列，当然数据库中也要设置主键和自增列才会有效
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 状态（1-启用；0-停用）
        /// </summary>
        public virtual EnumEnable Enable { get; set; } = EnumEnable.Enable;
    }
}
