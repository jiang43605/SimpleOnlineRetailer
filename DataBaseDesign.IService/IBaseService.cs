/*
 * 向各种Service层提供基础服务
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDesign.IService
{
    /// <summary>
    /// Service基类接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T>
    {
        /// <summary>
        /// 增加单个
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Add(T t);
        /// <summary>
        /// 按范围增加
        /// </summary>
        /// <param name="tlist"></param>
        /// <returns></returns>
        bool AddRange(IEnumerable<T> tlist);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool DeleteEntry(T t);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool UpdataEntry(T t);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 分页查询，不返回总数目
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc);
        /// <summary>
        /// 分页查询，返回总数目totalcount
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalcount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalcount, Expression<Func<T, bool>> whereLambda, Expression<Func<T, s>> orderLambda, bool isAsc);
    }
}
