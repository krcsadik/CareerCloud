using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class CompanyDescriptionRepository: BaseConnection,IDataRepository<CompanyDescriptionPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params CompanyDescriptionPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Company_Descriptions] 
               ([Id]
               ,[Company]
               ,[LanguageID]
               ,[Company_Name]
               ,[Company_Description])
                VALUES
               (@Id
               ,@Company
               ,@LanguageID
               ,@Company_Name
               ,@Company_Description)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyDescriptionPoco poco in items)
                    {
                            CompanyDescriptionPoco oPoco = new CompanyDescriptionPoco();
                            cmd.Parameters.AddWithValue("Id", poco.Id);
                            cmd.Parameters.AddWithValue("Company", poco.Company);
                            cmd.Parameters.AddWithValue("LanguageID", poco.LanguageId);
                            cmd.Parameters.AddWithValue("Company_Name", poco.CompanyName);
                            cmd.Parameters.AddWithValue("Company_Description", poco.CompanyDescription);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            }
                    }
                catch (Exception e)
                {
                    throw new Exception("CompanyDescriptionPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Company]
              ,[LanguageID]
              ,[Company_Name]
              ,[Company_Description]
              ,[Time_Stamp] 
               FROM [dbo].[Company_Descriptions]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    CompanyDescriptionPoco[] arrPoco = new CompanyDescriptionPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.LanguageId = (String)reader["LanguageID"];
                        poco.CompanyName = (String)reader["Company_Name"];
                        poco.CompanyDescription= (String)reader["Company_Description"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("CompanyDescriptionPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<CompanyDescriptionPoco> GetList(Func<CompanyDescriptionPoco, bool> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Func<CompanyDescriptionPoco, bool> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            try
            {
                CompanyDescriptionPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("CompanyDescriptionPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Company_Descriptions] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyDescriptionPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyDescriptionPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Company_Descriptions]
               SET [Company]=@Company
               ,[LanguageID]=@LanguageID
               ,[Company_Name]=@Company_Name
               ,[Company_Description]=@Company_Description 
               WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyDescriptionPoco poco in items)
                    {
                        CompanyDescriptionPoco oPoco = new CompanyDescriptionPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Company", poco.Company);
                        cmd.Parameters.AddWithValue("LanguageID", poco.LanguageId);
                        cmd.Parameters.AddWithValue("Company_Name", poco.CompanyName);
                        cmd.Parameters.AddWithValue("Company_Description", poco.CompanyDescription);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyDescriptionPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
