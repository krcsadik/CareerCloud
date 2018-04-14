using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class CompanyLocationRepository: BaseConnection,IDataRepository<CompanyLocationPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 3000;
        public void Add(params CompanyLocationPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Company_Locations]
               ([Id]
               ,[Company]
               ,[Country_Code]
               ,[State_Province_Code]
               ,[Street_Address]
               ,[City_Town]
               ,[Zip_Postal_Code])
                VALUES
               (@Id
               ,@Company
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
                    foreach (CompanyLocationPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Company", poco.Company);
                        cmd.Parameters.AddWithValue("Country_Code", poco.CountryCode);
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
                    throw new Exception("CompanyLocationPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
                ,[Company]
                ,[Country_Code]
                ,[State_Province_Code]
                ,[Street_Address]
                ,[City_Town]
                ,[Zip_Postal_Code]
                ,[Time_Stamp] 
                FROM [dbo].[Company_Locations]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    CompanyLocationPoco[] arrPoco = new CompanyLocationPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        CompanyLocationPoco poco = new CompanyLocationPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Company = (Guid)reader["Company"];
                        poco.CountryCode = (String)reader["Country_Code"];
                        if (!reader.IsDBNull(3)) poco.Province = (String)reader["State_Province_Code"];
                        if (!reader.IsDBNull(4)) poco.Street = (String)reader["Street_Address"];
                        if (!reader.IsDBNull(5)) poco.City = (String)reader["City_Town"];
                        if (!reader.IsDBNull(6)) poco.PostalCode = (String)reader["Zip_Postal_Code"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("CompanyLocationPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            try
            {
                CompanyLocationPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("CompanyLocationPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Company_Locations] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (CompanyLocationPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("CompanyLocationPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params CompanyLocationPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Company_Locations] 
                SET [Company]=@Company
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
                    foreach (CompanyLocationPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Company", poco.Company);
                        cmd.Parameters.AddWithValue("Country_Code", poco.CountryCode);
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
                    throw new Exception("CompanyLocationPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
