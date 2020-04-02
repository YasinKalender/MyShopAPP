using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyProjectShopApp.DataAccess.Abstract
{
    public interface IRepository<T>
    {

        //Bütün sınıflar için ortak işlemler için yaptık.

        T GetById(int id);

        T GetOne(Expression<Func<T, bool>> expression);

        List<T> GetAll(Expression<Func<T, bool>> expression=null);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
