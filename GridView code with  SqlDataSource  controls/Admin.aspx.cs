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

    }
    protected void lbInsert_Click(object sender, EventArgs e)
    {
        Guid newGUID = Guid.NewGuid();

        SqlDataSource1.InsertParameters["ID"].DefaultValue =
       newGUID.ToString();


        SqlDataSource1.InsertParameters["UserName"].DefaultValue =
        ((TextBox)GridView1.FooterRow.FindControl("txtUsername")).Text;

        SqlDataSource1.InsertParameters["Email"].DefaultValue =
             ((TextBox)GridView1.FooterRow.FindControl("txtEmail")).Text;

        SqlDataSource1.InsertParameters["Password"].DefaultValue =
            ((TextBox)GridView1.FooterRow.FindControl("txtPassword")).Text;

        SqlDataSource1.InsertParameters["Country"].DefaultValue =
            ((TextBox)GridView1.FooterRow.FindControl("txtCountry")).Text;

        SqlDataSource1.Insert();
    }
}