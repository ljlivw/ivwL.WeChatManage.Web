using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.IDao
{
    public interface IBaseDao<T> where T : class
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetList();
        /// <summary>
        /// 筛选查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<T>> GetList(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="iSkip"></param>
        /// <param name="iTake"></param>
        /// <returns></returns>
        Task<List<T>> GetPadList(int iSkip, int iTake);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="iSkip"></param>
        /// <param name="iTake"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<T>> GetPadList(int iSkip, int iTake, Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 根据主键查询数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetItemByKey(object key);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> Add(T t);
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        Task<bool> AddRange(List<T> ts);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> Update(T t);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> UpdateRange(List<T> ts);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> Remove(T t);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> RemoveRange(List<T> ts);
    }
}
