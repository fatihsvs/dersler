using System;
using System.Collections.Generic;
using Customproject.Entity;
using CustomProject.ORM;
using System.Reflection;
using customProject.Common;



namespace CustomProjectView2
{
    class Program
    {
        public static void Main(string[] args)
        {
            CategoriesORM orm = new CategoriesORM();
            List<Categories> kategoriler = orm.Select();
            foreach (var item in kategoriler)
            {
                Console.WriteLine(item.CategoryID + "  " + item.CategoryName);
            }

            //Categories ctg = new Categories();
            //ctg.CategoryName = "foods";
            //ctg.Description = "food category details.";
            //CategoriesORM.Current.Insert(ctg);
        }
    }
}