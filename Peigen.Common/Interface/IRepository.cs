using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Common.Interface
{
    public interface IRepository<T> where T:class
    {
        void Save();
        void AsyncSave();
        //增
        void Add(T entity);
        void AddAll(IEnumerable<T> entities);
        //改
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        //删
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        void DeleteAll(IEnumerable<T> entities);

        void Clear();
        //查
        T GetById(long Id);
        T GetById(string Id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAllLazy();
    }
}
