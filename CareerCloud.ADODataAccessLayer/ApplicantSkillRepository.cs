using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class ApplicantSkillRepository: BaseConnection,IDataRepository<ApplicantSkillPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 3000;
        public void Add(params ApplicantSkillPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Applicant_Skills]
               ([Id]
               ,[Applicant]
               ,[Skill]
               ,[Skill_Level]
               ,[Start_Month]
               ,[Start_Year]
               ,[End_Month]
               ,[End_Year])
                VALUES
               (@Id
               ,@Applicant
               ,@Skill
               ,@Skill_Level
               ,@Start_Month
               ,@Start_Year
               ,@End_Month
               ,@End_Year)";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantSkillPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("Skill", poco.Skill);
                        cmd.Parameters.AddWithValue("Skill_Level", poco.SkillLevel);
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
                    throw new Exception("ApplicantSkillPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Applicant]
              ,[Skill]
              ,[Skill_Level]
              ,[Start_Month]
              ,[Start_Year]
              ,[End_Month]
              ,[End_Year]
              ,[Time_Stamp] 
               FROM [dbo].[Applicant_Skills]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    ApplicantSkillPoco[] arrPoco = new ApplicantSkillPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        ApplicantSkillPoco poco = new ApplicantSkillPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Applicant = (Guid)reader["Applicant"];
                        poco.Skill = (String)reader["Skill"];
                        poco.SkillLevel = (String)reader["Skill_Level"];
                        poco.StartMonth = (Byte)reader["Start_Month"];
                        poco.StartYear = (int)reader["Start_Year"];
                        poco.EndMonth = (Byte)reader["End_Month"];
                        poco.EndYear = (int)reader["End_Year"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("ApplicantSkillPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            try
            {
                ApplicantSkillPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("ApplicantSkillPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Applicant_Skills] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantSkillPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantSkillPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Applicant_Skills]
                SET [Applicant]=@Applicant
               ,[Skill]=@Skill
               ,[Skill_Level]=@Skill_Level
               ,[Start_Month]=@Start_Month
               ,[Start_Year]=@Start_Year
               ,[End_Month]=@End_Month
               ,[End_Year]=@End_Year 
               WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantSkillPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("Skill", poco.Skill);
                        cmd.Parameters.AddWithValue("Skill_Level", poco.SkillLevel);
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
                    throw new Exception("ApplicantSkillPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
