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
    public class ApplicantResumeRepository: BaseConnection,IDataRepository<ApplicantResumePoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params ApplicantResumePoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Applicant_Resumes]
               ([Id]
               ,[Applicant]
               ,[Resume])
               VALUES
               (@Id>
               ,@Applicant
               ,@Resume)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantResumePoco poco in items)
                    {
                            ApplicantResumePoco oPoco = new ApplicantResumePoco();
                            cmd.Parameters.AddWithValue("Id", poco.Id);
                            cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                            cmd.Parameters.AddWithValue("Resume", poco.Resume);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            }
                    }
                catch (Exception e)
                {
                    throw new Exception("ApplicantResumePoco.Add-->Insertion error : " + e.ToString());
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

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
                ,[Applicant]
                ,[Resume]
                FROM [dbo].[Applicant_Resumes]";

            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    ApplicantResumePoco[] arrPoco = new ApplicantResumePoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        ApplicantResumePoco poco = new ApplicantResumePoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Applicant = (Guid)reader["Applicant"];
                        poco.Resume = (String)reader["Resume"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("ApplicantResumePoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<ApplicantResumePoco> GetList(Func<ApplicantResumePoco, bool> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Func<ApplicantResumePoco, bool> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            try
            {
                ApplicantResumePoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("ApplicantResumePoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Applicant_Resumes]
                WHERE Id =@Id)";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantResumePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantResumePoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params ApplicantResumePoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Applicant_Resumes]
                SET [Applicant]=@Applicant,
                    [Resume]=@Resume
                    Where Id=@Id)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantResumePoco poco in items)
                    {
                        ApplicantResumePoco oPoco = new ApplicantResumePoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Applicant", poco.Applicant);
                        cmd.Parameters.AddWithValue("Resume", poco.Resume);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantResumePoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
