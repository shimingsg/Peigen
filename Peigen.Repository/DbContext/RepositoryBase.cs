using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Repository
{
    public abstract class RepositoryBase<T> where T: class
    {
        private DataBaseContext dataContext;
        private readonly DbSet<T> dbset;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }
        protected DataBaseContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        #region 增删查改
        /// <summary>
        /// 添加单条记录
        /// </summary>
        /// <param name="entity">实体类</param>
        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        /// <summary>
        /// 添加多条
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddAll(IEnumerable<T> entities)
        {
            dbset.AddRange(entities);
        }
        /// <summary>
        /// 更新一条
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            //Attach要附加的实体。
            dbset.Attach(entity);           
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// 更新多条
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Update(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                dbset.Attach(item);
                dataContext.Entry(item).State = EntityState.Modified;
            }
        }
        /// <summary>
        /// 删除单条
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <param name="where"></param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            dbset.RemoveRange(objects);
        }
        /// <summary>
        /// 删除多条
        /// </summary>
        /// <param name="entities"></param>
        public virtual void DeleteAll(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
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
            return dbset.Find(id);
        }
        /// <summary>
        /// 根据Id得到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        /// <summary>
        /// 得到所有实体
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        /// <summary>
        /// 按条件得到多条实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
        /// <summary>
        /// 按条件得到单条实体
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }

        public virtual IEnumerable<T> GetAllLazy()
        {
            return dbset;
        }

        #endregion

    }
}
