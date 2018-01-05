using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class CompanyJobRepository: BaseConnection,IDataRepository<CompanyJobPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 3000;
        public void Add(params CompanyJobPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Company_Jobs] 
               ([Id]
               ,[Company]
               ,[Profile_Created]
               ,[Is_Inactive]
               ,[Is_Company_Hidden])
                VALUES
               (@Id
               ,@Company
               ,@Profile_Created
               ,@Is_Inactive
               ,@Is_Company_Hidden)";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Company", poco.Company);
                        cmd.Parameters.AddWithValue("Profile_Created", poco.ProfileCreated);
                        cmd.Parameters.AddWithValue("Is_Inactive", poco.IsInactive);
                        cmd.Parameters.AddWithValue("Is_Company_Hidden", poco.IsCompanyHidden);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Company]
              ,[Profile_Created]
              ,[Is_Inactive]
              ,[Is_Company_Hidden]
              ,[Time_Stamp] 
              FROM [dbo].[Company_Jobs]";

            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    CompanyJobPoco[] arrPoco = new CompanyJobPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        CompanyJobPoco poco = new CompanyJobPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Company  = (Guid)reader["Company"];
                        poco.ProfileCreated = (DateTime)reader["Profile_Created"];
                        poco.IsInactive = (bool)reader["Is_Inactive"];
                        poco.IsCompanyHidden = (bool)reader["Is_Company_Hidden"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("CompanyJobPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<CompanyJobPoco> GetList(Func<CompanyJobPoco, bool> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Func<CompanyJobPoco, bool> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            try
            {
                CompanyJobPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("CompanyJobPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Company_Jobs] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params CompanyJobPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Company_Jobs]
                SET [Company]=@Company
               ,[Profile_Created]=@Profile_Created
               ,[Is_Inactive]=@Is_Inactive
               ,[Is_Company_Hidden]=@Is_Company_Hidden 
                WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyJobPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Company", poco.Company);
                        cmd.Parameters.AddWithValue("Profile_Created", poco.ProfileCreated);
                        cmd.Parameters.AddWithValue("Is_Inactive", poco.IsInactive);
                        cmd.Parameters.AddWithValue("Is_Company_Hidden", poco.IsCompanyHidden);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyJobPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
