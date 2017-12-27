using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class CompanyJobEducationRepository: BaseConnection,IDataRepository<CompanyJobEducationPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params CompanyJobEducationPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Company_Job_Educations] 
               ([Id]
               ,[Job]
               ,[Major]
               ,[Importance])
                VALUES
               (@Id
               ,@Job
               ,@Major
               ,@Importance)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobEducationPoco poco in items)
                    {
                        CompanyJobEducationPoco oPoco = new CompanyJobEducationPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("job", poco.Job);
                        cmd.Parameters.AddWithValue("Major", poco.Major);
                        cmd.Parameters.AddWithValue("Importance", poco.Importance);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobEducationPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Job]
              ,[Major]
              ,[Importance]
              ,[Time_Stamp] 
              FROM [dbo].[Company_Job_Educations]";

            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    CompanyJobEducationPoco[] arrPoco = new CompanyJobEducationPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Job = (Guid)reader["Job"];
                        poco.Major = (String)reader["Major"];
                        poco.Importance = (short)reader["Importance"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("CompanyJobEducationPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<CompanyJobEducationPoco> GetList(Func<CompanyJobEducationPoco, bool> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Func<CompanyJobEducationPoco, bool> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            try
            {
                CompanyJobEducationPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("CompanyJobEducationPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Company_Job_Educations] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobEducationPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobEducationPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Company_Job_Educations] 
                SET [Job]=@Job
               ,[Major]=@Major
               ,[Importance]=@Importance 
                WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobEducationPoco poco in items)
                    {
                        CompanyJobEducationPoco oPoco = new CompanyJobEducationPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("job", poco.Job);
                        cmd.Parameters.AddWithValue("Major", poco.Major);
                        cmd.Parameters.AddWithValue("Importance", poco.Importance);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobEducationPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
