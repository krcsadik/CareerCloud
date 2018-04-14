using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class ApplicantProfileRepository: BaseConnection,IDataRepository<ApplicantProfilePoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 3000;
        public void Add(params ApplicantProfilePoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Applicant_Profiles]
                       ([Id]
                       ,[Login]
                       ,[Current_Salary]
                       ,[Current_Rate]
                       ,[Currency]
                       ,[Country_Code]
                       ,[State_Province_Code]
                       ,[Street_Address]
                       ,[City_Town]
                       ,[Zip_Postal_Code])
                        VALUES
                       (@Id
                       ,@Login
                       ,@Current_Salary
                       ,@Current_Rate
                       ,@Currency
                       ,@Country_Code
                       ,@State_Province_Code
                       ,@Street_Address
                       ,@City_Town
                       ,@Zip_Postal_Code)";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantProfilePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Login", poco.Login);
                        cmd.Parameters.AddWithValue("Current_Salary", poco.CurrentSalary);
                        cmd.Parameters.AddWithValue("Current_Rate", poco.CurrentRate);
                        cmd.Parameters.AddWithValue("Currency", poco.Currency);
                        cmd.Parameters.AddWithValue("Country_Code", poco.Country);
                        cmd.Parameters.AddWithValue("State_Province_Code", poco.Province);
                        cmd.Parameters.AddWithValue("Street_Address", poco.Street);
                        cmd.Parameters.AddWithValue("City_Town", poco.City);
                        cmd.Parameters.AddWithValue("Zip_Postal_Code", poco.PostalCode);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantProfilePoco.Add-->Insertion error : " + e.ToString());
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

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Login]
              ,[Current_Salary]
              ,[Current_Rate]
              ,[Currency]
              ,[Country_Code]
              ,[State_Province_Code]
              ,[Street_Address]
              ,[City_Town]
              ,[Zip_Postal_Code]
              ,[Time_Stamp] 
              FROM [dbo].[Applicant_Profiles]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    ApplicantProfilePoco[] arrPoco = new ApplicantProfilePoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        ApplicantProfilePoco poco = new ApplicantProfilePoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Login= (Guid)reader["Login"];
                        poco.CurrentSalary= (Decimal?)reader["Current_Salary"];
                        poco.CurrentRate = (Decimal?)reader["Current_Rate"];
                        poco.Currency = (String)reader["Currency"];
                        poco.Country = (String)reader["Country_Code"];
                        poco.Province = (String)reader["State_Province_Code"];
                        poco.Street = (String)reader["Street_Address"];
                        poco.City= (String)reader["City_Town"];
                        poco.PostalCode = (String)reader["Zip_Postal_Code"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("ApplicantProfilePoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            try
            {
                ApplicantProfilePoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("ApplicantProfilePoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Applicant_Profiles] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantProfilePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantProfilePoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Applicant_Profiles]
                SET [Login]=@Login
                ,[Current_Salary]=@Current_Salary
                ,[Current_Rate]=@Current_Rate
                ,[Currency]=@Currency
                ,[Country_Code]=@Country_Code
                ,[State_Province_Code]=@State_Province_Code
                ,[Street_Address]=@Street_Address
                ,[City_Town]=@City_Town
                ,[Zip_Postal_Code]=@Zip_Postal_Code 
                WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (ApplicantProfilePoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Login", poco.Login);
                        cmd.Parameters.AddWithValue("Current_Salary", poco.CurrentSalary);
                        cmd.Parameters.AddWithValue("Current_Rate", poco.CurrentRate);
                        cmd.Parameters.AddWithValue("Currency", poco.Currency);
                        cmd.Parameters.AddWithValue("Country_Code", poco.Country);
                        cmd.Parameters.AddWithValue("State_Province_Code", poco.Province);
                        cmd.Parameters.AddWithValue("Street_Address", poco.Street);
                        cmd.Parameters.AddWithValue("City_Town", poco.City);
                        cmd.Parameters.AddWithValue("Zip_Postal_Code", poco.PostalCode);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("ApplicantProfilePoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
