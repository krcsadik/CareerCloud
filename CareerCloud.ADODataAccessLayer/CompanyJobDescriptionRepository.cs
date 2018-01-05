using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class CompanyJobDescriptionRepository: BaseConnection,IDataRepository<CompanyJobDescriptionPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 3000;
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Company_Jobs_Descriptions]
               ([Id]
               ,[Job]
               ,[Job_Name]
               ,[Job_Descriptions])
                VALUES
               (@Id
               ,@Job
               ,@Job_Name
               ,@Job_Descriptions)";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobDescriptionPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Job", poco.Job);
                        cmd.Parameters.AddWithValue("Job_Name", poco.JobName);
                        cmd.Parameters.AddWithValue("Job_Descriptions", poco.JobDescriptions);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobDescriptionPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Job]
              ,[Job_Name]
              ,[Job_Descriptions]
              ,[Time_Stamp] 
              FROM [dbo].[Company_Jobs_Descriptions]";

            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    CompanyJobDescriptionPoco[] arrPoco = new CompanyJobDescriptionPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Job = (Guid)reader["Job"];
                        poco.JobName = (String)reader["Job_Name"];
                        poco.JobDescriptions = (String)reader["Job_Descriptions"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("CompanyJobDescriptionPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<CompanyJobDescriptionPoco> GetList(Func<CompanyJobDescriptionPoco, bool> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Func<CompanyJobDescriptionPoco, bool> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            try
            {
                CompanyJobDescriptionPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("CompanyJobDescriptionPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Company_Jobs_Descriptions] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobDescriptionPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobDescriptionPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Company_Jobs_Descriptions]
                SET [Job]=@Job
               ,[Job_Name]=@Job_Name
               ,[Job_Descriptions]=@Job_Descriptions 
                WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobDescriptionPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Job", poco.Job);
                        cmd.Parameters.AddWithValue("Job_Name", poco.JobName);
                        cmd.Parameters.AddWithValue("Job_Descriptions", poco.JobDescriptions);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobDescriptionPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
