using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class Registration : System.Web.UI.Page
{
    int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                string checkuser = "select count(*) from UserData where UserName = '" + TextBox_Username.Text + "'";
                SqlCommand com = new SqlCommand(checkuser, conn);
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp > 0)
                {
                    Response.Write("User already exists boss!");
                    i = 1;
                }
                conn.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
    protected void Button_Submit_Click(object sender, EventArgs e)
    {
        if (i == 0)
        {

            try
            {
                Guid newGUID = Guid.NewGuid();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                string insertquery = "insert into UserData (ID,UserName,Email,Password,Country) values (@id,@Uname,@email,@password,@country)";
                SqlCommand com = new SqlCommand(insertquery, conn);
                com.Parameters.AddWithValue("@id", newGUID.ToString());
                com.Parameters.AddWithValue("@Uname", TextBox_Username.Text);
                com.Parameters.AddWithValue("@email", TextBox_Email.Text);
                com.Parameters.AddWithValue("@password", TextBox_Password.Text);
                com.Parameters.AddWithValue("@country", DropDownListCountry.SelectedItem.ToString());
                com.ExecuteNonQuery();
                conn.Close();
                Response.Write("Registration is Successful");
                TextBox_Username.Text = "";
                TextBox_Email.Text = "";

            }


            catch (Exception)
            {

                throw;
            }
        }
       
    }
    protected void LinkButton_Submit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manager.aspx");
    }
    protected void TextBox_RePassword_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}