using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDesign.IDal
{
    /// <summary>
    /// 会话层接口
    /// </summary>
    public partial interface IDalSession
    {
        /// <summary>
        /// 执行操作SQL语句，参数可直接写，也可以传递构造SqlParameter类
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] objects);

        /// <summary>
        /// 返回查询的对象，参数需要构造形如“new SqlParameter("@h",h1)”
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        DbRawSqlQuery SqlQuery(Type type, string sql, params object[] parameters);
        
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        int SavaChanges();
    }
}
