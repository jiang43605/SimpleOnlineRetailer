using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataBaseDesign.IDal;
using DataBaseDesign.Model;

namespace DataBaseDesign.Dal
{
    /// <summary>
    /// Dal的基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class BaseDal<T> where T : class
    {
        private readonly DbContext _dbContext = DalFactory.DbContextFac.GetDbContext();

        public T Add(T t)
        {
            return _dbContext.Set<T>().Add(t);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> tlist)
        {
            return _dbContext.Set<T>().AddRange(tlist);
        }

        public T DeleteEntry(T t)
        {
            return _dbContext.Set<T>().Remove(t);
        }

        public void UpdataEntry(T t)
        {
            // 设置状态为修改状态
            _dbContext.Entry(t).State = EntityState.Modified;
        }

        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public IEnumerable<T> Where(Func<T, bool> func)
        {
            return _dbContext.Set<T>().Where(func);
        }
    }
}
