using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class SystemCountryCodeRepository: BaseConnection,IDataRepository<SystemCountryCodePoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 3000;
        public void Add(params SystemCountryCodePoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[System_Country_Codes]
               ([Code]
               ,[Name])
                VALUES
               (@Code
               ,@Name)";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SystemCountryCodePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Code", poco.Code);
                        cmd.Parameters.AddWithValue("Name", poco.Name);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SystemCountryCodePoco.Add-->Insertion error : " + e.ToString());
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

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Code], [Name] 
                FROM [dbo].[System_Country_Codes]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    SystemCountryCodePoco[] arrPoco = new SystemCountryCodePoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        SystemCountryCodePoco poco = new SystemCountryCodePoco();
                        poco.Code = (String)reader["Code"];
                        poco.Name= (String)reader["Name"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("SystemCountryCodePoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            try
            {
                SystemCountryCodePoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("SystemCountryCodePoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[System_Country_Codes] 
                WHERE Code =@Code";
            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SystemCountryCodePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Code", poco.Code);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SystemCountryCodePoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[System_Country_Codes] 
                SET [Name]=@Name 
                WHERE Code=@Code";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SystemCountryCodePoco poco in items)
                    {
                        SystemCountryCodePoco oPoco = new SystemCountryCodePoco();
                        cmd.Parameters.AddWithValue("Code", poco.Code);
                        cmd.Parameters.AddWithValue("Name", poco.Name);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SystemCountryCodePoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
