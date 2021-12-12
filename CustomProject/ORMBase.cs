using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using customProject.Common;
using System.Reflection;

namespace CustomProject.ORM
{
    public class ORMBase<ET,OT> : IORM<ET> 
        where ET : class, new()
        where OT: class, new()


    {
        private static OT _current;
        public static OT Current
        {
            get
            {
                if (_current == null)
                    _current = new OT();
                return _current;
                
            }
        }

        public bool Delete(ET entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ET entity)
        {
            string command = "INSERT INTO";
            string table  = $"{TableAtt.TableName}";
            PropertyInfo[] properties = ETTYPE.GetProperties();
            string props="";
            string values = "";
            foreach (var pi in properties)
            {
                if (pi.Name == TableAtt.IdendityColum)
                    continue;
                else
                props += pi.Name + ",";
            }
            props = props.Remove(props.Length - 1, 1);
           
            foreach(PropertyInfo pi in properties)
            {
                if (pi.Name != TableAtt.IdendityColum)
                    values += string.Format("'{0}',", pi.GetValue(entity));
            }
            values = values.Remove(values.Length - 1, 1);

            string query = $"{command} {table} ({props}) values ({values});";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.Connection = Tools.Connection;
            Tools.Connection.Open();
            int affectedRows = cmd.ExecuteNonQuery();
            Tools.Connection.Close();
            if (affectedRows > 0)            
                return true;
            else
                    return false;

            

        }
        public Type ETTYPE
        {
            get
            {
                return typeof(ET);
            }
        }

        public Table TableAtt
        {
            get
            {
                var attributes = ETTYPE.GetCustomAttributes(typeof(Table), false);
                if(attributes !=null&& attributes.Any())
                {
                    Table tbl = (Table)attributes[0];
                    return tbl;
                }
                return null;
            }
            
        }

        public List<ET> Select()
        {
            Type type = typeof(ET);
            string query = "SELECT * FROM ";
            var attributes = type.GetCustomAttributes(typeof(Table), false);
            if (attributes != null && attributes.Any())
            {
                Table tbl = (Table)attributes[0];
                query += tbl.TableName + ";";

            }
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.CommandText = query;
            adp.SelectCommand.Connection = Tools.Connection;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt.ToList<ET>(); 

        }

        public ET Select(int etID)
        {
            
            string query = "SELECT * FROM ";
            var attributes = ETTYPE.GetCustomAttributes(typeof(Table), false);
            if (attributes != null && attributes.Any())
            {
                Table tbl = (Table)attributes[0];
                query += tbl.TableName;

            }
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.CommandText = query;
            adp.SelectCommand.Connection = Tools.Connection;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt.ToList<ET>();

        }

        public bool Update(ET entity) 
        {
            
            string command = $"update {TableAtt.TableName} Set {} where {}";
            string table = $"{TableAtt.TableName}";
            PropertyInfo[] properties = ETTYPE.GetProperties();
            string props = "";
            string values = "";
            foreach (var pi in properties)
            {
                if (pi.Name == TableAtt.IdendityColum)
                    continue;
                else
                    props += pi.Name + ",";
            }
            props = props.Remove(props.Length - 1, 1);



            return true;
        }
    }
}
