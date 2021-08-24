using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DataAccess
{
    public class DalSession
    {
        public  SqlConnection con = new SqlConnection();

        public DalSession()
        {
            con = new SqlConnection(SqlDataAccess.GiveConnectionString());
            con.Open();
        }
        public  void BeginTransaction()
        {
            con.Query("Begin Transaction");
        }
        public  void Commit()
        {
           var result = con.Query("commit");
        }
        public  void RollBack()
        {
            try
            {
               var result = con.Query("rollback");

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public  int InsertData(string Query, DynamicParameters dbargs)
        {
                try
                {
                    return con.Execute(Query, dbargs);
                }
                catch (Exception ex)
                {
                   throw;
                }
        }
        public  int ReturnIdentity(string Query, DynamicParameters dbargs)
        {
                try
                {
                    con.Execute(Query, dbargs);
                    return dbargs.Get<int>("@Id");
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw;
                }
        }
        public  T GetSingleDataValues<T>(string Query, DynamicParameters dbargs)
        {
                try
                {
                    return con.ExecuteScalar<T>(Query, dbargs);

                }
                catch (Exception ex)
                {

                    string e = ex.Message;
                    throw;

                }
        }
        public  T GetDataModel<T>(string Query, DynamicParameters dbargs)
        {
                try
                {
                    return con.QueryFirstOrDefault<T>(Query, dbargs);

                }
                catch (Exception ex)
                {
                    throw;
                }
        }
        public  List<T> LoadDataList<T>(string Query, DynamicParameters dbargs)
        {
            try
            {
                var result = con.Query<T>(Query, dbargs);
                return result.AsList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  void Dispose()
        {
            con.Close();
        }
    }
    public class SqlDataAccess
    {
        public  SqlConnection con = new SqlConnection();
        public SqlDataAccess()
        {
          
        }
      
       
        public static List<T> LoadDataList<T>(string Query, DynamicParameters dbargs)
        {
            using (IDbConnection Dbcon = new SqlConnection(GiveConnectionString()))
            {
                var result = Dbcon.Query<T>(Query, dbargs);
                return result.AsList();
            }

        }
       
      
    
       
        public static int insertDataDapper(string Query, DynamicParameters dbargs)
        {
            using (IDbConnection con = new SqlConnection(GiveConnectionString()))
            {
                try
                {
                    return con.Execute(Query, dbargs);
                    

                }
                catch (Exception ex)
                {
                    string s=ex.Message;
                    return 0;
                    
                }

            }
        }
        public static int ReturnWithIdentity(string Query, DynamicParameters dbargs)
        {
            using (IDbConnection con = new SqlConnection(GiveConnectionString()))
            {
                try
                {
                    con.Execute(Query, dbargs);
                    return dbargs.Get<int>("@Id");
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw;
                }
             
            }
        }
        public static string GiveConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            return configuration.GetConnectionString("ConnectionString");

        }
        public static T GetSingleDataValues<T>(string Query, DynamicParameters dbargs)
        {
            using (IDbConnection cnn = new SqlConnection(GiveConnectionString()))
            {
                try
                {
                    return cnn.ExecuteScalar<T>(Query, dbargs);

                }
                catch (Exception ex)
                {

                    string e=ex.Message;

                }

            }
            return default(T);
        }
        public static T GetDataModel<T>(string Query, DynamicParameters dbargs)
        {
            using (IDbConnection cnn = new SqlConnection(GiveConnectionString()))
            {
                try
                {
                return cnn.QueryFirstOrDefault<T>(Query, dbargs);

                }
                catch (Exception ex)
                {

                        throw;
                }
            }
        }
    }
}
