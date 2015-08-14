using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public class User
{
    public string ID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Country { get; set; }
}


public class UserDataAccessLayer
{
	 // Select Method for ObjectDataSource control
    public static List<User> GetAllUsers()
    {
        List<User> listUsers = new List<User>();

        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Select * from UserData", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                User User = new User();
                User.ID = rdr["ID"].ToString();
                User.UserName = rdr["UserName"].ToString();
                User.Email = rdr["Email"].ToString();
                User.Password = rdr["Password"].ToString();
                User.Country = rdr["Country"].ToString();

                listUsers.Add(User);
            }
        }

        return listUsers;
    }

    // Delete Method for ObjectDataSource control
    public static void DeleteUser(string ID)
    {
        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand
                ("Delete from UserData where ID = @ID", con);
            SqlParameter param = new SqlParameter("@ID", id);
            cmd.Parameters.Add(param);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // Update Method for ObjectDataSource control
    public static int UpdateUser(string ID, string UserName, string Email, string Password,string Country)
    {
        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            string updateQuery = "Update UserData SET UserName = @UserName,  " +
                "Email = @Email, Password = @Password, Country = @Country WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            SqlParameter paramOriginalID = new 
                SqlParameter("@ID", ID);
            cmd.Parameters.Add(paramOriginalID);
            SqlParameter paramUserName = new SqlParameter("@UserName", UserName);
            cmd.Parameters.Add(paramUserName);
            SqlParameter paramEmail = new SqlParameter("@Email", Email);
            cmd.Parameters.Add(paramEmail);
            SqlParameter paramPassword = new SqlParameter("@Password", Password);
            cmd.Parameters.Add(paramPassword);
            SqlParameter paramCountry = new SqlParameter("@Country", Country);
            cmd.Parameters.Add(paramCountry);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }

    // Insert Method for ObjectDataSource control
    public static int InsertUser(string UserName, string Email, string Password,string Country)
    {
        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            Guid newGUID = Guid.NewGuid();
            string updateQuery = "Insert into UserData (ID, UserName, Email, Password, Country)" + 
                " values (@ID, @UserName, @Email, @Password, @Country)";
            SqlCommand cmd = new SqlCommand(updateQuery, con);
            SqlParameter paramID = new SqlParameter("@ID", newGUID.ToString());
            cmd.Parameters.Add(paramID);
            SqlParameter paramUsername = new SqlParameter("@UserName", UserName);
            cmd.Parameters.Add(paramUsername);
            SqlParameter paramEmail = new SqlParameter("@Email", Email);
            cmd.Parameters.Add(paramEmail);
            SqlParameter paramPassword = new SqlParameter("@Password", Password);
            cmd.Parameters.Add(paramPassword);
            SqlParameter paramCountry = new SqlParameter("@Country", Country);
            cmd.Parameters.Add(paramCountry);
            con.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
