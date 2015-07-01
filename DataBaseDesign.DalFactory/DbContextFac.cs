using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataBaseDesign.Model;

namespace DataBaseDesign.DalFactory
{
    /// <summary>
    /// 生产DbContext，并保证线程内对象的唯一
    /// </summary>
    public static class DbContextFac
    {
        private const string _dbcontext = "dbcontext";
        /// <summary>
        /// 创建EF对象
        /// </summary>
        /// <returns></returns>
        public static DbContext GetDbContext()
        {
            DbContext dbContext = CallContext.GetData(_dbcontext) as DbContext;
            if (dbContext != null) return dbContext;
            dbContext = new DataBaseDesignModelContainer();
            
            CallContext.SetData(_dbcontext,dbContext);
            return dbContext;
        }
        
    }
}
