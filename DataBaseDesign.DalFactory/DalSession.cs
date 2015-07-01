using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DataBaseDesign.IDal;

namespace DataBaseDesign.DalFactory
{
    /// <summary>
    /// 内部默认的DalSession实例
    /// </summary>
    internal partial class DalSession : IDalSession
    {
        private readonly DbContext _DbContext = DbContextFac.GetDbContext();

        /// <summary>
        /// 执行操作SQL语句，参数可直接写，也可以传递构造SqlParameter类
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params object[] objects)
        {
            return this._DbContext.Database.ExecuteSqlCommand(sql, objects);
        }

        /// <summary>
        /// 返回查询的对象，参数需要构造形如“new SqlParameter("@h",h1)”
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DbRawSqlQuery SqlQuery(Type type, string sql, params object[] parameters)
        {
            return this._DbContext.Database.SqlQuery(type, sql, parameters);
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public int SavaChanges()
        {
            return this._DbContext.SaveChanges();
        }
    }
}
