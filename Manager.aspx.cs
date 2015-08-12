using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void SqlDataSourceRegistration_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void LinkButton_Click(object sender, EventArgs e)
    {
        //SqlDataSource1.InsertParameters[""].DefaultValue =
        //    ((TextBox)GridView1.FooterRow.FindControl("TextBoxUsername")).Text;

        //SqlDataSource1.InsertParameters[""].DefaultValue =
        //    ((TextBox)GridView1.FooterRow.FindControl("TextBoxEmail")).Text;
        //SqlDataSource1.InsertParameters[""].DefaultValue =
        //    ((TextBox)GridView1.FooterRow.FindControl("TextBoxPassword")).Text;
        //SqlDataSource1.InsertParameters[""].DefaultValue =
        //    ((DropDownList)GridView1.FooterRow.FindControl("")).SelectedValue;
    }
}