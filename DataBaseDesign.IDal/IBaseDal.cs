/*
 * Dal层向Service层提供的基接口
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDesign.IDal
{
    /// <summary>
    /// 数据层基类接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDal<T>
    {
        /// <summary>
        /// 添加单个对象
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Add(T t);
        /// <summary>
        /// 添加一组对象
        /// </summary>
        /// <param name="tlist"></param>
        /// <returns></returns>
        IEnumerable<T> AddRange(IEnumerable<T> tlist);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T DeleteEntry(T t);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        void UpdataEntry(T t);

        /// <summary>
        /// 查询（针对数据库的表达式树）
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 普通查询方式
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        IEnumerable<T> Where(Func<T, bool> func);
    }
}
