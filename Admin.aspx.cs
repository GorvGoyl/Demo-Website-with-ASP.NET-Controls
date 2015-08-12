using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridViewData();
        }

    }
    private void BindGridViewData()
    {
        GridView1.DataSource = UserDataAccessLayer.GetAllUsers();
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            GridView1.EditIndex = rowIndex;
            BindGridViewData();
        }
        else if (e.CommandName == "DeleteRow")
        {
            UserDataAccessLayer.DeleteUser((e.CommandArgument.ToString()));
            BindGridViewData();
        }
        else if (e.CommandName == "CancelUpdate")
        {
            GridView1.EditIndex = -1;
            BindGridViewData();
        }
        else if (e.CommandName == "UpdateRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

            string Id = (e.CommandArgument.ToString());
            string Username = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox1")).Text;
            string Email = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox2")).Text;
            string Password = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox3")).Text;
            string Country = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox4")).Text;

            UserDataAccessLayer.UpdateUser(Id, Username, Email, Password,Country);

            GridView1.EditIndex = -1;
            BindGridViewData();
        }
        else if (e.CommandName == "InsertRow")
        {
            string Username = ((TextBox)GridView1.FooterRow.FindControl("txtUsername")).Text;
            string Email = ((TextBox)GridView1.FooterRow.FindControl("txtEmail")).Text;
            string Password = ((TextBox)GridView1.FooterRow.FindControl("txtPassword")).Text;
            string Country = ((TextBox)GridView1.FooterRow.FindControl("txtCountry")).Text;

            UserDataAccessLayer.InsertUser(Username, Email, Password,Country);

            BindGridViewData();
        }
    }
}