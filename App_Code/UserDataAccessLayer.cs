using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Hosting;

public class User
{
    public string ID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Country { get; set; }
    public string Files { get; set; }
}


public class UserDataAccessLayer
{
    // Select Method for ObjectDataSource control
    public static List<User> GetAllUsers()
    {
        List<User> ListUsers = new List<User>();

        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        using (SqlConnection Con = new SqlConnection(CS))
        {
            SqlCommand Cmd = new SqlCommand("Select * from UserData", Con);
            Con.Open();
            SqlDataReader Rdr = Cmd.ExecuteReader();
            while (Rdr.Read())
            {
                User User = new User();
                User.ID = Rdr["ID"].ToString();
                User.UserName = Rdr["UserName"].ToString();
                User.Email = Rdr["Email"].ToString();
                User.Password = Rdr["Password"].ToString();
                User.Country = Rdr["Country"].ToString();
                User.Files = Rdr["Files"].ToString();
                ListUsers.Add(User);
            }
        }

        return ListUsers;
    }

    // Delete Method for ObjectDataSource control
    public static void DeleteUser(string id)
    {
        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        UserDataAccessLayer.DeleteFile(id);
        using (SqlConnection Con = new SqlConnection(CS))
        {
            SqlCommand Cmd = new SqlCommand
                ("Delete from UserData where ID = @ID", Con);
            SqlParameter param2 = new SqlParameter("@ID", id);
            Cmd.Parameters.Add(param2);
            Con.Open();
            Cmd.ExecuteNonQuery();

        }
    }

    //Delete file from database
    public static void DeleteFile(String id)
    {
        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        using (SqlConnection Con = new SqlConnection(CS))
        {

            SqlCommand GetFile = new SqlCommand
                ("Select Files from UserData where ID = @ID", Con);
            SqlParameter Param = new SqlParameter("@ID", id);
            GetFile.Parameters.Add(Param);
            Con.Open();
            String FileName = (string)GetFile.ExecuteScalar();
            if (FileName != "")
            {
                System.IO.File.Delete(HostingEnvironment.MapPath("~/Uploads/" + FileName));
            }
        }

    }
    public static string GetUniqueName(string fileName,string newGUID,string fileExtension)
    {
        string UniqueFileName = newGUID + "~" + fileName + fileExtension;
        return UniqueFileName;
    }
    // Update Method for ObjectDataSource control
    public static int UpdateUser(string ID, string UserName, string Email, string Password, string Country, string Files)
    {
        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        using (SqlConnection Con = new SqlConnection(CS))
        {
            string UpdateQuery = "Update UserData SET UserName = @UserName,  " +
                "Email = @Email, Password = @Password, Country = @Country, Files= @Files  WHERE ID = @ID";
            SqlCommand Cmd = new SqlCommand(UpdateQuery, Con);
            SqlParameter ParamOriginalID = new
                SqlParameter("@ID", ID);
            Cmd.Parameters.Add(ParamOriginalID);
            SqlParameter ParamUserName = new SqlParameter("@UserName", UserName);
            Cmd.Parameters.Add(ParamUserName);
            SqlParameter ParamEmail = new SqlParameter("@Email", Email);
            Cmd.Parameters.Add(ParamEmail);
            SqlParameter ParamPassword = new SqlParameter("@Password", Password);
            Cmd.Parameters.Add(ParamPassword);
            SqlParameter ParamCountry = new SqlParameter("@Country", Country);
            Cmd.Parameters.Add(ParamCountry);
            SqlParameter ParamFiles = new SqlParameter("@Files", Files);
            Cmd.Parameters.Add(ParamFiles);
            Con.Open();

            return Cmd.ExecuteNonQuery();
        }
    }

    // Insert Method for ObjectDataSource control
    public static int InsertUser(string newGUID,string userName, string email, string password, string country, string files)
    {
        string CS = ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString;
        using (SqlConnection Con = new SqlConnection(CS))
        {
            
            string UpdateQuery = "Insert into UserData (ID, UserName, Email, Password, Country,Files)" +
                " values (@ID, @UserName, @Email, @Password, @Country,@Files)";
            SqlCommand Cmd = new SqlCommand(UpdateQuery, Con);
            SqlParameter ParamID = new SqlParameter("@ID", newGUID);
            Cmd.Parameters.Add(ParamID);
            SqlParameter ParamUsername = new SqlParameter("@UserName", userName);
            Cmd.Parameters.Add(ParamUsername);
            SqlParameter ParamEmail = new SqlParameter("@Email", email);
            Cmd.Parameters.Add(ParamEmail);
            SqlParameter ParamPassword = new SqlParameter("@Password", password);
            Cmd.Parameters.Add(ParamPassword);
            SqlParameter ParamCountry = new SqlParameter("@Country", country);
            Cmd.Parameters.Add(ParamCountry);
            SqlParameter ParamFiles = new SqlParameter("@Files", files);
            Cmd.Parameters.Add(ParamFiles);
            Con.Open();
            return Cmd.ExecuteNonQuery();
            
        }
    }
}
