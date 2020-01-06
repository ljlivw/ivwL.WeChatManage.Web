using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Dao
{
    public class BaseDao<T> where T : class
    {
        protected readonly string sqlConn;
        private readonly string sqlDataBaseType;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sqlConn"></param>
        public BaseDao(string sqlConn, string sqlDataBaseType)
        {
            this.sqlConn = sqlConn;
            this.sqlDataBaseType = sqlDataBaseType.ToLower();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<T>> GetList()
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                return await db.Set<T>().ToListAsync();
            }
        }
        /// <summary>
        /// 筛选查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> GetList(Expression<Func<T, bool>> predicate)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                return await db.Set<T>().Where(predicate).ToListAsync();
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="iSkip"></param>
        /// <param name="iTake"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> GetPadList(int iSkip, int iTake)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                return await db.Set<T>().Skip(iSkip).Take(iTake).ToListAsync();
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="iSkip"></param>
        /// <param name="iTake"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> GetPadList(int iSkip, int iTake, Expression<Func<T, bool>> predicate)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                return await db.Set<T>().Skip(iSkip).Take(iTake).Where(predicate).ToListAsync();
            }
        }
        /// <summary>
        /// 根据主键查询数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual async Task<T> GetItemByKey(object key)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                return await db.Set<T>().FindAsync(key);
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<bool> Add(T t)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                await db.Set<T>().AddAsync(t);
                return await db.SaveChangesAsync() > 0;
            }
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public virtual async Task<bool> AddRange(List<T> ts)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                await db.Set<T>().AddRangeAsync(ts);
                return await db.SaveChangesAsync() > 0;
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<bool> Update(T t)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                db.Set<T>().Update(t);
                return await db.SaveChangesAsync() > 0;
            }
        }
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<bool> UpdateRange(List<T> ts)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                db.Set<T>().UpdateRange(ts);
                return await db.SaveChangesAsync() > 0;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<bool> Remove(T t)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                db.Set<T>().Remove(t);
                return await db.SaveChangesAsync() > 0;
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public virtual async Task<bool> RemoveRange(List<T> ts)
        {
            using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
            {
                db.Set<T>().RemoveRange(ts);
                return await db.SaveChangesAsync() > 0;
            }
        }
        ///// <summary>
        ///// 执行sql语句
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        //protected virtual async Task<List<T>> ExecSql(FormattableString sql)
        //{
        //    using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
        //    {
        //        return await db.Set<T>().FromSqlInterpolated(sql).ToListAsync();
        //    }
        //}
        ///// <summary>
        ///// 执行sql语句
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="predicate"></param>
        ///// <returns></returns>
        //protected virtual async Task<List<T>> ExecSql(FormattableString sql, Expression<Func<T, bool>> predicate)
        //{
        //    using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
        //    {
        //        return await db.Set<T>().FromSqlInterpolated(sql).Where(predicate).ToListAsync();
        //    }
        //}
        ///// <summary>
        ///// 执行存储过程
        ///// </summary>
        ///// <param name="proc"></param>
        ///// <param name="sqlParameters"></param>
        ///// <returns></returns>
        //protected virtual async Task<List<T>> ExecProc(string proc, List<SqlParameter> sqlParameters)
        //{
        //    using (DbContext db = new DbContext(sqlConn, sqlDataBaseType))
        //    {
        //        return await db.Set<T>().FromSqlRaw($"{proc}", sqlParameters.ToArray()).ToListAsync();
        //    }
        //}
    }
}
