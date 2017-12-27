using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class ApplicantEducationRepository: BaseConnection,IDataRepository<ApplicantEducationPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params ApplicantEducationPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Applicant_Educations]
               ([Id]
               ,[Applicant]
               ,[Major]
               ,[Cetificate_Diploma]
               ,[Start_Date]
               ,[Completion_Date]
               ,[Completion_Percent])
                VALUES
               (@Id,
                @Applicant, 
                @Major,
                @Cetificate_Diploma,
                @Start_Date,
                @Completion_Date,
                @Completion_Percent)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantEducationPoco poco in items)
                    {
                        ApplicantEducationPoco oPoco = new ApplicantEducationPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("Major", poco.Major);
                        cmd.Parameters.AddWithValue("Cetificate_Diploma", poco.CertificateDiploma);
                        cmd.Parameters.AddWithValue("Start_Date", poco.StartDate);
                        cmd.Parameters.AddWithValue("Completion_Date", poco.CompletionDate);
                        cmd.Parameters.AddWithValue("Completion_Percent", poco.CompletionPercent);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantEducationPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Applicant]
              ,[Major]
              ,[Cetificate_Diploma]
              ,[Start_Date]
              ,[Completion_Date]
              ,[Completion_Percent]
              ,[Time_Stamp]
              FROM[dbo].[Applicant_Educations]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    ApplicantEducationPoco[] arrPoco = new ApplicantEducationPoco[_maxRecordNo];
                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        ApplicantEducationPoco poco = new ApplicantEducationPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Applicant = (Guid)reader["Applicant"];
                        poco.Major = (String)reader["Major"];
                        poco.CertificateDiploma = (String)reader["Cetificate_Diploma"];
                        poco.StartDate = (DateTime)reader["Start_Date"];
                        poco.CompletionDate = (DateTime)reader["Completion_Date"];
                        poco.CompletionPercent = (Byte?)reader["Completion_Percent"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("ApplicantEducationPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<ApplicantEducationPoco> GetList(Func<ApplicantEducationPoco, bool> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Func<ApplicantEducationPoco, bool> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            try
            {
                ApplicantEducationPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("ApplicantEducationPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Applicant_Educations]
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantEducationPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantEducationPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Applicant_Educations]
                SET [Applicant]=@Applicant,
                    [Major]=@Major,
                    [Cetificate_Diploma]=@Cetificate_Diploma,
                    [Start_Date]=@Start_Date,
                    [Completion_Date]=@Completion_Date,
                    [Completion_Percent]=@Completion_Percent
                    Where Id=@Id";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantEducationPoco poco in items)
                    {
                        ApplicantEducationPoco oPoco = new ApplicantEducationPoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("Major", poco.Major);
                        cmd.Parameters.AddWithValue("Cetificate_Diploma", poco.CertificateDiploma);
                        cmd.Parameters.AddWithValue("Start_Date", poco.StartDate);
                        cmd.Parameters.AddWithValue("Completion_Date", poco.CompletionDate);
                        cmd.Parameters.AddWithValue("Completion_Percent", poco.CompletionPercent);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantEducationPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
