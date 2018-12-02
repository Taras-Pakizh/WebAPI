using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Tamagochi.Data.Contracts;
using Tamagochi.Data.Entities;

namespace Tamagochi.Data.ADO.NET.Repository
{
    public abstract class AdoRepository<T> : IRepository<T> where T : class
    {
        protected string ConnectionString = "Data Source=.;Initial Catalog=Tamagochi;Integrated Security=True;";

        public void Insert(T Entity)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                List<string> parameters = GetProcedureParameters("spAdd" + typeof(T).Name);
                SqlCommand cmd = new SqlCommand("spAdd" + typeof(T).Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var property in typeof(T).GetProperties())
                {
                    if (parameters.Contains("@" + property.Name))
                        cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(Entity));
                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Update(T Entity)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdate" + typeof(T).Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var property in typeof(T).GetProperties())
                {
                    cmd.Parameters.AddWithValue("@" + property.Name, property.GetValue(Entity));
                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(T Entity)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spDelete" + typeof(T).Name, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", (Entity as BaseEntity)?.Id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public T GetById(long Id)
        {
            T instance;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string sqlQuery = "SELECT * FROM " + typeof(T).Name + "s WHERE Id= " + Id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                var res = RowToEntity(cmd);
                instance = res.FirstOrDefault();
                con.Close();
            }

            return instance;
        }

        public IEnumerable<T> All()
        {
            IEnumerable<T> resultList;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAll" + typeof(T).Name, con);
                cmd.CommandType = CommandType.StoredProcedure;

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

        protected List<string> GetProcedureParameters(string procedureName)
        {
            List<string> result = new List<string>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                string sqlQuery = "select PARAMETER_NAME from information_schema.parameters where specific_name= \'" + procedureName + "\'";
                SqlCommand parametersCommand = new SqlCommand(sqlQuery, con);
                con.Open();

                var record = parametersCommand.ExecuteReader();
                while (record.Read())
                {
                    result.Add((string)record["PARAMETER_NAME"]);
                }
                con.Close();
            }
            return result;
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