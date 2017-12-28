using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer 
{
    public class SecurityLoginRepository: BaseConnection,IDataRepository<SecurityLoginPoco>
    {
        private string _cmdSQL;
        private const int _maxRecordNo = 500;
        public void Add(params SecurityLoginPoco[] items)
        {
            _cmdSQL = @"INSERT INTO [dbo].[Security_Logins] 
               ([Id]
               ,[Login]
               ,[Password]
               ,[Created_Date]
               ,[Password_Update_Dated]
               ,[Agreement_Accepted_Date]
               ,[Is_Locked]
               ,[Is_Inactive]
               ,[Email_Address]
               ,[Phone_Number]
               ,[Full_Name]
               ,[Force_Change_Password]
               ,[Prefferred_Language])
                VALUES
               (@Id
               ,@Login
               ,@Password
               ,@Created_Date
               ,@Password_Update_Dated
               ,@Agreement_Accepted_Date
               ,@Is_Locked
               ,@Is_Inactive
               ,@Email_Address
               ,@Phone_Number
               ,@Full_Name
               ,@Force_Change_Password
               ,@Prefferred_Language)";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Login", poco.Login);
                        cmd.Parameters.AddWithValue("Password", poco.Password);
                        //cmd.Parameters.AddWithValue("Salt", poco.Salt);
                        cmd.Parameters.AddWithValue("Created_Date", poco.Created);
                        cmd.Parameters.AddWithValue("Password_Update_Dated", poco.PasswordUpdate);
                        cmd.Parameters.AddWithValue("Agreement_Accepted_Date", poco.AgreementAccepted);
                        cmd.Parameters.AddWithValue("Is_Locked", poco.IsLocked);
                        cmd.Parameters.AddWithValue("Is_Inactive", poco.IsInactive);
                        cmd.Parameters.AddWithValue("Email_Address", poco.EmailAddress);
                        cmd.Parameters.AddWithValue("Phone_Number", poco.PhoneNumber);
                        cmd.Parameters.AddWithValue("Full_Name", poco.FullName);
                        cmd.Parameters.AddWithValue("Force_Change_Password", poco.ForceChangePassword);
                        cmd.Parameters.AddWithValue("Prefferred_Language", poco.PrefferredLanguage);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginPoco.Add-->Insertion error : " + e.ToString());
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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            _cmdSQL = @"SELECT [Id]
              ,[Login]
              ,[Password]
              ,[Salt]
              ,TRY_CONVERT(datetime2, [Created_Date]) AS Created_Date
              ,TRY_CONVERT(datetime2, [Password_Update_Dated]) AS Password_Update_Dated
              ,TRY_CONVERT(datetime2, [Agreement_Accepted_Date]) AS Agreement_Accepted_Date
              ,[Is_Locked]
              ,[Is_Inactive]
              ,[Email_Address]
              ,[Phone_Number]
              ,[Full_Name]
              ,[Force_Change_Password]
              ,[Prefferred_Language]
              ,[Time_Stamp] 
              FROM [dbo].[Security_Logins]";
            using (SqlConnection con = new SqlConnection(DBConnectionString)) 
            {
                try
                {
                    SecurityLoginPoco[] arrPoco = new SecurityLoginPoco[_maxRecordNo];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = _cmdSQL;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int recordIndex = 0;
                    while (reader.Read())
                    {
                        SecurityLoginPoco poco = new SecurityLoginPoco();
                        poco.Id = (Guid)reader["Id"];
                        poco.Login = (String)reader["Login"];
                        poco.Password = (String)reader["Password"];
                        if (!reader.IsDBNull(3)) poco.Salt = (String)reader["Salt"];
                        if (!reader.IsDBNull(4)) poco.Created = (DateTime)reader["Created_Date"];
                        if (!reader.IsDBNull(5)) poco.PasswordUpdate=(DateTime?)reader["Password_Update_Dated"];
                        if (!reader.IsDBNull(6)) poco.AgreementAccepted = (DateTime?)reader["Agreement_Accepted_Date"];
                        poco.IsLocked = (bool)reader["Is_Locked"];
                        poco.IsInactive= (bool)reader["Is_Inactive"];
                        if (!reader.IsDBNull(9)) poco.EmailAddress = (String)reader["Email_Address"];
                        if (!reader.IsDBNull(10)) poco.PhoneNumber = (String)reader["Phone_Number"];
                        if (!reader.IsDBNull(11)) poco.FullName = (String)reader["Full_Name"];
                        if (!reader.IsDBNull(12)) poco.ForceChangePassword = (bool)reader["Force_Change_Password"];
                        if (!reader.IsDBNull(13)) poco.PrefferredLanguage = (String)reader["Prefferred_Language"];
                        poco.TimeStamp = (Byte[])reader["Time_Stamp"];
                        arrPoco[recordIndex++] = poco;
                    }
                    return arrPoco.Where(a => a != null).ToList();
                }
                catch(Exception e)
                {
                    throw new Exception("SecurityLoginPoco.GetAll-->Record batch reading error: " + e.ToString());
                }
                finally
                {
                    if ( con != null) con.Close();
                }
            }
        }

        public IList<SecurityLoginPoco> GetList(Func<SecurityLoginPoco, bool> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Func<SecurityLoginPoco, bool> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            try
            {
                SecurityLoginPoco[] arrPoco = GetAll().ToArray();
                return arrPoco.Where(where).ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception("SecurityLoginPoco.GetSingle-->Single reading error: " + e.ToString());
            }
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            _cmdSQL = @"DELETE FROM [dbo].[Security_Logins] 
                WHERE Id =@Id";
            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginPoco.Remove-->Batch deletion error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }

        }

        public void Update(params SecurityLoginPoco[] items)
        {
            _cmdSQL = @"UPDATE [dbo].[Security_Logins] 
                SET [Login]=@Login
               ,[Password]=@Password
               ,[Salt]=@Salt
               ,[Created_Date]=@Created_Date
               ,[Password_Update_Dated]=@Password_Update_Dated
               ,[Agreement_Accepted_Date]=@Agreement_Accepted_Date
               ,[Is_Locked]=@Is_Locked
               ,[Is_Inactive]=@Is_Inactive
               ,[Email_Address]=@Email_Address
               ,[Phone_Number]=@Phone_Number
               ,[Full_Name]=@Full_Name
               ,[Force_Change_Password]=@Force_Change_Password
               ,[Prefferred_Language]=@Prefferred_Language 
               WHERE Id=@Id";

            using (SqlConnection con = new SqlConnection(base.DBConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = _cmdSQL;
                cmd.Connection = con;
                try
                {
                    foreach (SecurityLoginPoco poco in items)
                    {
                        cmd.Parameters.AddWithValue("Id", poco.Id);
                        cmd.Parameters.AddWithValue("Login", poco.Login);
                        cmd.Parameters.AddWithValue("Password", poco.Password);
                        cmd.Parameters.AddWithValue("Salt", poco.Salt);
                        cmd.Parameters.AddWithValue("Created_Date", poco.Created);
                        cmd.Parameters.AddWithValue("Password_Update_Dated", poco.PasswordUpdate);
                        cmd.Parameters.AddWithValue("Agreement_Accepted_Date", poco.AgreementAccepted);
                        cmd.Parameters.AddWithValue("Is_Locked", poco.IsLocked);
                        cmd.Parameters.AddWithValue("Is_Inactive", poco.IsInactive);
                        cmd.Parameters.AddWithValue("Email_Address", poco.EmailAddress);
                        cmd.Parameters.AddWithValue("Phone_Number", poco.PhoneNumber);
                        cmd.Parameters.AddWithValue("Full_Name", poco.FullName);
                        cmd.Parameters.AddWithValue("Force_Change_Password", poco.ForceChangePassword);
                        cmd.Parameters.AddWithValue("Prefferred_Language", poco.PrefferredLanguage);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("SecurityLoginPoco.Update-->Batch Update error : " + e.ToString());
                }
                finally
                {
                    if (con != null) con.Close();
                }
            }
        }
    }
}
