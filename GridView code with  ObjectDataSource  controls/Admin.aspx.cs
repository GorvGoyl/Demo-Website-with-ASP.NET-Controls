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

       // ObjectDataSource1.InsertParameters["ID"].DefaultValue = newGUID.ToString();
      


        ObjectDataSource1.InsertParameters["UserName"].DefaultValue =
        ((TextBox)GridView1.FooterRow.FindControl("txtUsername")).Text;

        ObjectDataSource1.InsertParameters["Email"].DefaultValue =
             ((TextBox)GridView1.FooterRow.FindControl("txtEmail")).Text;

        ObjectDataSource1.InsertParameters["Password"].DefaultValue =
            ((TextBox)GridView1.FooterRow.FindControl("txtPassword")).Text;

        ObjectDataSource1.InsertParameters["Country"].DefaultValue =
            ((TextBox)GridView1.FooterRow.FindControl("txtCountry")).Text;

        ObjectDataSource1.Insert();
    }
}