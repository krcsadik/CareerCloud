using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class SecurityLoginsRoleRepository: BaseConnection,IDataRepository<SecurityLoginsRolePoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Security_Logins_Roles]
               ([Id]
               ,[Login]
               ,[Role])
                VALUES
               (@Id
               ,@Login
               ,@Role)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginsRolePoco poco in items)
                    {
                        SecurityLoginsRolePoco oPoco = new SecurityLoginsRolePoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Login", poco.Login);
                        cmd.Parameters.AddWithValue("Role", poco.Role);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginsRolePoco.Add-->Insertion error : " + e.ToString());
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

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Login]
              ,[Role]
              ,[Time_Stamp] 
              FROM [dbo].[Security_Logins_Roles]";

            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    SecurityLoginsRolePoco[] arrPoco = new SecurityLoginsRolePoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Login = (Guid)reader["Login"];
                        poco.Role = (Guid)reader["Role"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("SecurityLoginsRolePoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<SecurityLoginsRolePoco> GetList(Func<SecurityLoginsRolePoco, bool> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Func<SecurityLoginsRolePoco, bool> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            try
            {
                SecurityLoginsRolePoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("SecurityLoginsRolePoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Security_Logins_Roles] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginsRolePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginsRolePoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Security_Logins_Roles] 
                SET [Login]=@Login
                ,[Role]=@Role 
                WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginsRolePoco poco in items)
                    {
                        SecurityLoginsRolePoco oPoco = new SecurityLoginsRolePoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Login", poco.Login);
                        cmd.Parameters.AddWithValue("Role", poco.Role);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginsRolePoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
