using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDesign.IDal;
using DataBaseDesign.DalFactory;

namespace DataBaseDesign.Service
{
    /// <summary>
    /// 所有服务的基类，增加修改等操作发生异常均视为失败
    /// </summary>
    public abstract class BaseService<T> where T : class
    {
        /// <summary>
        /// 创建工厂
        /// </summary>
        protected IDalSession _dalSession = DalSessionFac.GetDalSession();
        /// <summary>
        /// dal层基类接口，通过抽象来来得到实例
        /// </summary>
        protected abstract IBaseDal<T> _BaseDal { get; }
        public bool Add(T t)
        {
            try
            {
                this._BaseDal.Add(t);
            }
            catch
            {
                return false;
            }
            return this._dalSession.SavaChanges() > -1;
        }
        public bool AddRange(IEnumerable<T> tlist)
        {
            try
            {
                this._BaseDal.AddRange(tlist);
            }
            catch
            {
                return false;
            }
            return this._dalSession.SavaChanges() > -1;
        }

        public bool DeleteEntry(T t)
        {
            try
            {
                this._BaseDal.DeleteEntry(t);
            }
            catch
            {
                return false;
            }
            return this._dalSession.SavaChanges() > -1;
        }

        public bool UpdataEntry(T t)
        {
            try
            {
                this._BaseDal.UpdataEntry(t);
            }
            catch
            {
                return false;
            }
            return this._dalSession.SavaChanges() > -1;
        }


        public IEnumerable<T> Where(Func<T, bool> func)
        {
            return this._BaseDal.Where(func);
        }

        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return this._BaseDal.Where(expression);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalcount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderLambda, bool isAsc)
        {
            IQueryable<T> ilist = this._BaseDal.Where(whereLambda);
            totalcount = ilist.Count();
            if (isAsc)
            {
                // 表示升序
                return ilist.OrderBy(orderLambda)
                     .Skip(pageIndex * pageSize)
                     .Take(pageSize);
            }
            // 表示降序
            return ilist.OrderByDescending(orderLambda)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize);
        }

        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderLambda, bool isAsc)
        {
            int totalcount;
            return this.LoadPageEntities(pageIndex, pageSize, out totalcount, whereLambda, orderLambda, isAsc);
        }
    }
}
