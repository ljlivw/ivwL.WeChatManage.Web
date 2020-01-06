using ivwL.WeChat.IDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Services
{
    public class BaseService<T> where T : class
    {
        private readonly IBaseDao<T> dao;
        public BaseService(IBaseDao<T> dao) => this.dao = dao;
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetList() => await this.dao.GetList();
        /// <summary>
        /// 筛选查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<T>> GetList(Expression<Func<T, bool>> predicate) => await this.dao.GetList(predicate);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="iSkip"></param>
        /// <param name="iTake"></param>
        /// <returns></returns>
        public async Task<List<T>> GetPadList(int iSkip, int iTake) => await this.dao.GetPadList(iSkip, iTake);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="iSkip"></param>
        /// <param name="iTake"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<List<T>> GetPadList(int iSkip, int iTake, Expression<Func<T, bool>> predicate) => await this.dao.GetPadList(iSkip, iTake, predicate);
        /// <summary>
        /// 根据主键查询数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<T> GetItemByKey(object key) => await this.dao.GetItemByKey(key);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> Add(T t) => await this.dao.Add(t);
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public async Task<bool> AddRange(List<T> ts) => await this.dao.AddRange(ts);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> Update(T t) => await this.dao.Update(t);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> UpdateRange(List<T> ts) => await this.dao.UpdateRange(ts);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> Remove(T t) => await this.dao.Remove(t);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<bool> RemoveRange(List<T> ts) => await this.dao.RemoveRange(ts);
    }
}
