using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace customProject.Common
{
    public static class Tools
    {
        private static SqlConnection _connection; 
        public static SqlConnection Connection
        {
            get
            {

                if (_connection == null)
                {
                    _connection = new SqlConnection($"Server=.; Database=Northwind; user=sa; pwd=48529758996");
                }
                return _connection;
            }
            set { _connection = value; }
        }
        public static List<ET> ToList<ET>(this DataTable dt) where ET:class,new()
        {
            Type type = typeof(ET); //gelen tipin ne kategorimi product mmı başka birşeymi
            List<ET> list = new List<ET>();//gelen tipten nesnelerin olduğu liste
            PropertyInfo[] properties = type.GetProperties();//sınıfa ait özellikleri bir siziye attık.
            foreach(DataRow dr in dt.Rows)
            {
                ET tip = new ET();
                foreach (PropertyInfo pi in properties)
                {
                    object value = dr[pi.Name]; //sınıf özelliğinin adı ileveri tabanındaki tablodan veri çektik
                    if (value != null)
                        pi.SetValue(tip, value);
                }
                list.Add(tip);
            }
            return list;

        }
    }
}
