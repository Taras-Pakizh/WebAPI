using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab8.ViewModel
{
    public class ADOTask<T> : IModelTask
    {
        private string _connection;

        public ADOTask(string connection)
        {
            _connection = connection;
        }

        public void Execute(object obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> All()
        {
            IEnumerable<T> resultList;

            using (SqlConnection con = new SqlConnection(_connection))
            {
                string sql = "select * from " + typeof(T).Name + "s";
                SqlCommand cmd = new SqlCommand(sql, con);
                
                con.Open();
                resultList = RowToEntity(cmd);
                con.Close();
            }

            return resultList;
        }

        protected IEnumerable<T> RowToEntity(IDbCommand cmd)
        {
            List<T> resultList = new List<T>();
            var record = cmd.ExecuteReader();
            while (record.Read())
            {
                T instance = Activator.CreateInstance<T>();
                foreach (var property in typeof(T).GetProperties())
                {
                    if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                        property.SetValue(instance, record[property.Name]);
                }

                resultList.Add(instance);
            }

            return resultList;
        }

        public void Insert(T Entity)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into " + typeof(T).Name + "s values (");
                var properties = GetProperties();
                foreach(var property in properties)
                {
                    var Column = typeof(T).GetProperty(property);
                    sql.Append("'" + Column.GetValue(Entity) + "', ");
                }
                sql.Remove(sql.Length - 2, 2);
                sql.Append(")");

                SqlCommand command = new SqlCommand(sql.ToString(), con);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(T Entity)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into " + typeof(T).Name + " values (");

                sql.Append(")");

                SqlCommand command = new SqlCommand(sql.ToString(), con);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(T Entity)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into " + typeof(T).Name + " values (");

                sql.Append(")");

                SqlCommand command = new SqlCommand(sql.ToString(), con);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<string> GetProperties()
        {
            List<string> properties = new List<string>();
            if(typeof(T) == typeof(Department))
            {
                properties.Add("departmentID");
                properties.Add("dname");
                return properties;
            }
            if(typeof(T) == typeof(Position))
            {

            }
            if (typeof(T) == typeof(Employee))
            {

            }
            if (typeof(T) == typeof(EmployeeOrder))
            {

            }
            if (typeof(T) == typeof(OrderType))
            {

            }
            return null;
        }
    }

    public static class DataRecordExtensions
    {
        public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }

            return false;
        }
    }
}
