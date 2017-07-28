using Dapper.Contrib.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Repository
{
    public abstract class DapperRepositoryBase<T> where T:class  
    {
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, string> TypeTableName = new ConcurrentDictionary<RuntimeTypeHandle, string>();
        private static string GetTableName(Type type)
        {
            string name;
            if (!TypeTableName.TryGetValue(type.TypeHandle, out name))
            {
                name = DataBaseContext.GetTableName(type);
                TypeTableName[type.TypeHandle] = name;
            }
            return name;
        }

        #region 增删查改
        /// <summary>
        /// 添加单条记录
        /// </summary>
        /// <param name="entity">实体类</param>
        public void Add(T entity)
        {
            using (var conn= DataBaseContext.GetDefaultConnection())
            {
                conn.Insert(entity);                
            }
        }
        /// <summary>
        /// 添加多条
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddAll(IEnumerable<T> entities)
        {
            throw new NotImplementedException();//请自己写sql并写事务
        }
        /// <summary>
        /// 更新一条
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            using (var conn = DataBaseContext.GetDefaultConnection())
            {
                conn.Update<T>(entity);
            }
        }
        /// <summary>
        /// 更新多条
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Update(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除单条
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            using (var conn = DataBaseContext.GetDefaultConnection())
            {
                conn.Delete<T>(entity);
            }
        }
        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <param name="where"></param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="entities"></param>
        public virtual void DeleteAll(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
        public virtual void Clear()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据Id得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(long id)
        {
            using (var conn = DataBaseContext.GetDefaultConnection())
            {
                return conn.Get<T>(id);
            }
        }
        /// <summary>
        /// 根据Id得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(string id)
        {
            using (var conn = DataBaseContext.GetDefaultConnection())
            {
                return conn.Get<T>(id);
            }
        }
        /// <summary>
        /// 得到所有实体
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 按条件得到多条实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 按条件得到单条实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAllLazy()
        {
            throw new NotImplementedException();
        }

        #endregion 
    }
}
