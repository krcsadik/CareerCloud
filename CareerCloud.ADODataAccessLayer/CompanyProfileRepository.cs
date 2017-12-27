using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class CompanyProfileRepository: BaseConnection,IDataRepository<CompanyProfilePoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params CompanyProfilePoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Company_Profiles]
               ([Id]
               ,[Registration_Date]
               ,[Company_Website]
               ,[Contact_Phone]
               ,[Contact_Name]
               ,[Company_Logo])
                VALUES
               (@Id
               ,@Registration_Date
               ,@Company_Website
               ,@Contact_Phone
               ,@Contact_Name
               ,@Company_Logo)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyProfilePoco poco in items)
                    {
                        CompanyProfilePoco oPoco = new CompanyProfilePoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Registration_Date", poco.RegistrationDate);
                        cmd.Parameters.AddWithValue("Company_Website", poco.CompanyWebsite);
                        cmd.Parameters.AddWithValue("Contact_Phone", poco.ContactPhone);
                        cmd.Parameters.AddWithValue("Contact_Name", poco.ContactName);
                        cmd.Parameters.AddWithValue("Company_Logo", poco.CompanyLogo);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyProfilePoco.Add-->Insertion error : " + e.ToString());
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

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Registration_Date]
              ,[Company_Website]
              ,[Contact_Phone]
              ,[Contact_Name]
              ,[Company_Logo]
              ,[Time_Stamp] 
              FROM [dbo].[Company_Profiles]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    CompanyProfilePoco[] arrPoco = new CompanyProfilePoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        CompanyProfilePoco poco = new CompanyProfilePoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.RegistrationDate = (DateTime)reader["Registration_Date"];
                        poco.CompanyWebsite = (String)reader["Company_Website"];
                        poco.ContactPhone = (String)reader["Contact_Phone"];
                        poco.ContactName = (String)reader["Contact_Name"];
                        poco.CompanyLogo= (Byte[])reader["Company_Logo"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("CompanyProfilePoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<CompanyProfilePoco> GetList(Func<CompanyProfilePoco, bool> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Func<CompanyProfilePoco, bool> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            try
            {
                CompanyProfilePoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("CompanyProfilePoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Company_Profiles] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyProfilePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyProfilePoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params CompanyProfilePoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Company_Profiles] 
                SET [Registration_Date]=@Registration_Date
               ,[Company_Website]=@Company_Website
               ,[Contact_Phone]=@Contact_Phone
               ,[Contact_Name]=@Contact_Name
               ,[Company_Logo]=@Company_Logo 
               WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyProfilePoco poco in items)
                    {
                        CompanyProfilePoco oPoco = new CompanyProfilePoco();
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Registration_Date", poco.RegistrationDate);
                        cmd.Parameters.AddWithValue("Company_Website", poco.CompanyWebsite);
                        cmd.Parameters.AddWithValue("Contact_Phone", poco.ContactPhone);
                        cmd.Parameters.AddWithValue("Contact_Name", poco.ContactName);
                        cmd.Parameters.AddWithValue("Company_Logo", poco.CompanyLogo);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyProfilePoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
