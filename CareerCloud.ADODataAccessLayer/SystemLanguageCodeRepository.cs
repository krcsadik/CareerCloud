using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class SystemLanguageCodeRepository: BaseConnection,IDataRepository<SystemLanguageCodePoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params SystemLanguageCodePoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[System_Language_Codes]
               ([LanguageID]
               ,[Name]
               ,[Native_Name]) 
                VALUES 
               (@LanguageID
               ,@Name
               ,@Native_Name)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SystemLanguageCodePoco poco in items)
                    {
                        SystemLanguageCodePoco oPoco = new SystemLanguageCodePoco();
                        cmd.Parameters.AddWithValue("LanguageID", poco.LanguageID);
                        cmd.Parameters.AddWithValue("Name", poco.Name);
                        cmd.Parameters.AddWithValue("Native_Name", poco.NativeName);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SystemLanguageCodePoco.Add-->Insertion error : " + e.ToString());
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

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [LanguageID]
                ,[Name]
                ,[Native_Name] 
                FROM [dbo].[System_Language_Codes]";

            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    SystemLanguageCodePoco[] arrPoco = new SystemLanguageCodePoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
                        poco.LanguageID= (String)reader["LanguageID"];
                        poco.Name = (String)reader["Name"];
                        poco.NativeName = (String)reader["Native_Name"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("SystemLanguageCodePoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<SystemLanguageCodePoco> GetList(Func<SystemLanguageCodePoco, bool> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Func<SystemLanguageCodePoco, bool> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            try
            {
                SystemLanguageCodePoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("SystemLanguageCodePoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[System_Language_Codes] 
                WHERE LanguageID =@LanguageID";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SystemLanguageCodePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("LanguageID", poco.LanguageID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SystemLanguageCodePoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[System_Language_Codes]  
                SET [Name]=@Name, [Native_Name]=@Native_Name 
                WHERE LanguageID=@LanguageID";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SystemLanguageCodePoco poco in items)
                    {
                        SystemLanguageCodePoco oPoco = new SystemLanguageCodePoco();
                        cmd.Parameters.AddWithValue("LanguageID", poco.LanguageID);
                        cmd.Parameters.AddWithValue("Name", poco.Name);
                        cmd.Parameters.AddWithValue("Native_Name", poco.NativeName);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SystemLanguageCodePoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
