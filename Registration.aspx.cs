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
                SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                Conn.Open();
                string CheckUser = "select count(*) from UserData where UserName = '" + TextBox_Username.Text + "'";
                SqlCommand Com = new SqlCommand(CheckUser, Conn);
                int Result = Convert.ToInt32(Com.ExecuteScalar().ToString());
                if (Result > 0)
                {
                    Response.Write("User already exists boss!");
                    i = 1;
                }
                Conn.Close();
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
                Guid NewGUID = Guid.NewGuid();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString);
                conn.Open();
                string InsertQuery = "insert into UserData (ID,UserName,Email,Password,Country) values (@id,@Uname,@email,@password,@country)";
                SqlCommand Com = new SqlCommand(InsertQuery, conn);
                Com.Parameters.AddWithValue("@id", NewGUID.ToString());
                Com.Parameters.AddWithValue("@Uname", TextBox_Username.Text);
                Com.Parameters.AddWithValue("@email", TextBox_Email.Text);
                Com.Parameters.AddWithValue("@password", TextBox_Password.Text);
                Com.Parameters.AddWithValue("@country", DropDownListCountry.SelectedItem.ToString());
                Com.ExecuteNonQuery();
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