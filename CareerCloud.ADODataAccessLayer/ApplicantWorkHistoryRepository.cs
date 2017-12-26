using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class ApplicantWorkHistoryRepository: BaseConnection,IDataRepository<ApplicantWorkHistoryPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Applicant_Work_History]
               ([Id]
               ,[Applicant]
               ,[Company_Name]
               ,[Country_Code]
               ,[Location]
               ,[Job_Title]
               ,[Job_Description]
               ,[Start_Month]
               ,[Start_Year]
               ,[End_Month]
               ,[End_Year])
                VALUES
               (@Id
               ,@Applicant
               ,@Company_Name
               ,@Country_Code
               ,@Location
               ,@Job_Title
               ,@Job_Description
               ,@Start_Month
               ,@Start_Year
               ,@End_Month
               ,@End_Year)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantWorkHistoryPoco poco in items)
                    {
                        ApplicantWorkHistoryPoco oPoco = new ApplicantWorkHistoryPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("Company_Name", poco.CompanyName);
                        cmd.Parameters.AddWithValue("Country_Code", poco.CountryCode);
                        cmd.Parameters.AddWithValue("Location", poco.Location);
                        cmd.Parameters.AddWithValue("Job_Title", poco.JobTitle);
                        cmd.Parameters.AddWithValue("Job_Description", poco.JobDescription);
                        cmd.Parameters.AddWithValue("Start_Month", poco.StartMonth);
                        cmd.Parameters.AddWithValue("Start_Year", poco.StartYear);
                        cmd.Parameters.AddWithValue("End_Month", poco.EndMonth);
                        cmd.Parameters.AddWithValue("End_Year", poco.EndYear);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantWorkHistoryPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Applicant]
              ,[Company_Name]
              ,[Country_Code]
              ,[Location]
              ,[Job_Title]
              ,[Job_Description]
              ,[Start_Month]
              ,[Start_Year]
              ,[End_Month]
              ,[End_Year]
              ,[Time_Stamp]
              FROM [dbo].[Applicant_Work_History]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    ApplicantWorkHistoryPoco[] arrPoco = new ApplicantWorkHistoryPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Applicant = (Guid)reader["Applicant"];
                        poco.CompanyName = (String)reader["Company_Name"];
                        poco.CountryCode = (String)reader["Country_Code"];
                        poco.Location = (String)reader["Location"];
                        poco.JobTitle = (String)reader["Job_Title"];
                        poco.JobDescription = (String)reader["Job_Description"];
                        poco.StartMonth= (short)reader["Start_Month"];
                        poco.StartYear= (int)reader["Start_Year"];
                        poco.EndMonth = (short)reader["End_Month"];
                        poco.EndYear = (int)reader["End_Year"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("ApplicantWorkHistoryPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Func<ApplicantWorkHistoryPoco, bool> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Func<ApplicantWorkHistoryPoco, bool> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            try
            {
                ApplicantWorkHistoryPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("ApplicantWorkHistoryPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Applicant_Work_History]
                WHERE Id =@Id)";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantWorkHistoryPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantWorkHistoryPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[[Applicant_Work_History]]
                SET [Applicant]=@Applicant
               ,[Company_Name]=@Company_Name
               ,[Country_Code]=@Country_Code
               ,[Location]=@Location
               ,[Job_Title]=@Job_Title
               ,[Job_Description]=@Job_Description
               ,[Start_Month]=@Start_Month
               ,[Start_Year]=@Start_Year
               ,[End_Month]=@End_Month
               ,[End_Year]=@End_Year
               WHERE Id=@Id)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantWorkHistoryPoco poco in items)
                    {
                        ApplicantWorkHistoryPoco oPoco = new ApplicantWorkHistoryPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("Company_Name", poco.CompanyName);
                        cmd.Parameters.AddWithValue("Country_Code", poco.CountryCode);
                        cmd.Parameters.AddWithValue("Location", poco.Location);
                        cmd.Parameters.AddWithValue("Job_Title", poco.JobTitle);
                        cmd.Parameters.AddWithValue("Job_Description", poco.JobDescription);
                        cmd.Parameters.AddWithValue("Start_Month", poco.StartMonth);
                        cmd.Parameters.AddWithValue("Start_Year", poco.StartYear);
                        cmd.Parameters.AddWithValue("End_Month", poco.EndMonth);
                        cmd.Parameters.AddWithValue("End_Year", poco.EndYear);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantWorkHistoryPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
