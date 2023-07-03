using Core.Common.Modules;
using Core.Enum;
using Core.Models.Base;

namespace Core.IBusiness.Base
{
    public interface IBaseBusiness<T> : IAutoInject where T : BaseModel
    {

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public Task<int> Add(params T[] items);

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public Task<bool> Update(params T[] items);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public Task<bool> Delete(params int[] ids);

        /// <summary>
        /// 根据Id获取信息
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public Task<T> GetById(int id);

        /// <summary>
        /// 启用/停用
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <param name="enable">状态</param>
        /// <returns></returns>
        public Task<bool> Enable(int id, EnumEnable enable);
    }
}
