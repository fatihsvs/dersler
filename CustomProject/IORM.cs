using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customProject.Common
{
    public interface IORM<T> where T: class//tip class olmalı
    {
        List<T> Select();//abstract metod

        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);


    }
}
