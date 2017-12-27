using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class SecurityLoginsLogRepository: BaseConnection,IDataRepository<SecurityLoginsLogPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params SecurityLoginsLogPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Security_Logins_Log]
               ([Id]
               ,[Login]
               ,[Source_IP]
               ,[Logon_Date]
               ,[Is_Succesful])
                VALUES
               (@Id
               ,@Login
               ,@Source_IP
               ,@Logon_Date
               ,@Is_Succesful";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginsLogPoco poco in items)
                    {
                        SecurityLoginsLogPoco oPoco = new SecurityLoginsLogPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Login", poco.Login);
                        cmd.Parameters.AddWithValue("Source_IP", poco.SourceIP);
                        cmd.Parameters.AddWithValue("Logon_Date", poco.LogonDate);
                        cmd.Parameters.AddWithValue("Is_Succesful", poco.IsSuccesful);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginsLogPoco.Add-->Insertion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Login]
              ,[Source_IP]
              ,[Logon_Date]
              ,[Is_Succesful] 
              FROM [dbo].[Security_Logins_Log]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    SecurityLoginsLogPoco[] arrPoco = new SecurityLoginsLogPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Login = (Guid)reader["Login"];
                        poco.SourceIP = (String)reader["Source_IP"];
                        poco.LogonDate = (DateTime)reader["Logon_Date"];
                        poco.IsSuccesful = (bool)reader["Is_Succesful"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("SecurityLoginsLogPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<SecurityLoginsLogPoco> GetList(Func<SecurityLoginsLogPoco, bool> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Func<SecurityLoginsLogPoco, bool> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            try
            {
                SecurityLoginsLogPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("SecurityLoginsLogPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Security_Logins_Log] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginsLogPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginsLogPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Security_Logins_Log] 
                SET [Id]
               ,[Login]=@Login
               ,[Source_IP]=@Source_IP
               ,[Logon_Date]=@Logon_Date
               ,[Is_Succesful]=@Is_Succesful 
               WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginsLogPoco poco in items)
                    {
                        SecurityLoginsLogPoco oPoco = new SecurityLoginsLogPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Login", poco.Login);
                        cmd.Parameters.AddWithValue("Source_IP", poco.SourceIP);
                        cmd.Parameters.AddWithValue("Logon_Date", poco.LogonDate);
                        cmd.Parameters.AddWithValue("Is_Succesful", poco.IsSuccesful);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginsLogPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
