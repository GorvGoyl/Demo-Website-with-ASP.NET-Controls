using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from UserData where UserName = '" + TextBox_Login_Username.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (temp > 0)
            {
                conn.Open();
                string PasswordCheck = "select password from UserData where Password = '" + TextBox_Login_Password.Text + "'";
                SqlCommand PassCom = new SqlCommand(PasswordCheck, conn);
                string Password = PassCom.ExecuteScalar().ToString().Replace(" ","");
                conn.Close();
                if (Password == TextBox_Login_Password.Text)
                {
                    Session["New"] = TextBox_Login_Username.Text;
                    Response.Write("Welcome to the MATRIX !");
                    Response.Redirect("Users.aspx");
                }
                else
                {
                    Response.Write("Password is not correct");
                }
                
            }
            else
            {
                Response.Write("UserName is not correct");
            }
            
        }
        catch (Exception)
        {

            throw;
        }
    }
}