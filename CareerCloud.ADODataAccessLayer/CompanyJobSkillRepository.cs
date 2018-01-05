using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class CompanyJobSkillRepository: BaseConnection,IDataRepository<CompanyJobSkillPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 5100;
        public void Add(params CompanyJobSkillPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Company_Job_Skills] 
               ([Id]
               ,[Job]
               ,[Skill]
               ,[Skill_Level]
               ,[Importance])
                VALUES
               (@Id
               ,@Job
               ,@Skill
               ,@Skill_Level
               ,@Importance)";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobSkillPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Job", poco.Job);
                        cmd.Parameters.AddWithValue("Skill", poco.Skill);
                        cmd.Parameters.AddWithValue("Skill_Level", poco.SkillLevel);
                        cmd.Parameters.AddWithValue("Importance", poco.Importance);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobSkillPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Job]
              ,[Skill]
              ,[Skill_Level]
              ,[Importance]
              ,[Time_Stamp] 
              FROM [dbo].[Company_Job_Skills]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    CompanyJobSkillPoco[] arrPoco = new CompanyJobSkillPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        CompanyJobSkillPoco poco = new CompanyJobSkillPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Job = (Guid)reader["Job"];
                        poco.Skill= (String)reader["Skill"];
                        poco.SkillLevel= (String)reader["Skill_Level"];
                        poco.Importance = (int)reader["Importance"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("CompanyJobSkillPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<CompanyJobSkillPoco> GetList(Func<CompanyJobSkillPoco, bool> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobSkillPoco GetSingle(Func<CompanyJobSkillPoco, bool> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            try
            {
                CompanyJobSkillPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("CompanyJobSkillPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params CompanyJobSkillPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Company_Job_Skills] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobSkillPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobSkillPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params CompanyJobSkillPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Company_Job_Skills] 
                SET [Job]=@Job
               ,[Skill]=@Skill
               ,[Skill_Level]=@Skill_Level
               ,[Importance]=@Importance 
               WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobSkillPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Job", poco.Job);
                        cmd.Parameters.AddWithValue("Skill", poco.Skill);
                        cmd.Parameters.AddWithValue("Skill_Level", poco.SkillLevel);
                        cmd.Parameters.AddWithValue("Importance", poco.Importance);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobSkillPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
