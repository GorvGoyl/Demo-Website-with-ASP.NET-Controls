using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Hosting;
using System.Configuration;
using System.Data.SqlClient;
public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridViewData();
        }
        lblMessage.Text = "";

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

            HttpPostedFile FileContent = Request.Files["myEditFile"];
            string FileName = "";
            UserDataAccessLayer.DeleteFile(e.CommandArgument.ToString());
            if (FileContent.ContentLength != 0)
            {
                string fileExtension = System.IO.Path.GetExtension(FileContent.FileName);

                if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf")
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only files with .doc or.docx or .pdf extension are allowed";
                    return;
                }
                //  Get the FileContent size
                if (FileContent.ContentLength > 2097152)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "File size cannot be greater than 2 MB";
                    return;
                }

                FileName = Path.GetFileName(FileContent.FileName);

                FileContent.SaveAs(Server.MapPath(Path.Combine("~/Uploads/", FileName)));
            }

            string Id = (e.CommandArgument.ToString());
            string Username = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox1")).Text;
            string Email = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox2")).Text;
            string Password = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox3")).Text;
            string Country = ((TextBox)GridView1.Rows[rowIndex].FindControl("TextBox4")).Text;
            UserDataAccessLayer.UpdateUser(Id, Username, Email, Password, Country, FileName);

            GridView1.EditIndex = -1;
            BindGridViewData();
        }
        else if (e.CommandName == "InsertRow")
        {
            // string fileName;
            //if (FileUpload1.HasFile)
            //{
            //    fileName = FileUpload1.FileName;
            //    // Get the FileContent size
            //}
            //else {
            //    fileName = null;
            //}

            //var fileName1 = ((FileUpload)GridView1.FindControl("FileUpload1")).FileName;
            //var fileName =((FileUpload) GridView1.FooterRow.FindControl("txtFileUpload")).PostedFile.FileName;
            HttpPostedFile FileContent = Request.Files["myFile"];
            string FileName = "";

            if (FileContent.ContentLength != 0)
            {
                string fileExtension = System.IO.Path.GetExtension(FileContent.FileName);

                if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf")
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only files with .doc or.docx or .pdf extension are allowed";
                    return;
                }
                //  Get the FileContent size
                if (FileContent.ContentLength > 2097152)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "File size cannot be greater than 2 MB";
                    return;
                }

                FileName = Path.GetFileName(FileContent.FileName);
                FileContent.SaveAs(Server.MapPath(Path.Combine("~/Uploads/", FileName)));
               // File.Copy(Server.MapPath(Path.Combine("~/Uploads/", FileName)));
            }

            string Username = ((TextBox)GridView1.FooterRow.FindControl("txtUsername")).Text;
            string Email = ((TextBox)GridView1.FooterRow.FindControl("txtEmail")).Text;
            string Password = ((TextBox)GridView1.FooterRow.FindControl("txtPassword")).Text;
            string Country = ((TextBox)GridView1.FooterRow.FindControl("txtCountry")).Text;

            UserDataAccessLayer.InsertUser(Username, Email, Password, Country, FileName);

            BindGridViewData();


        }
        else if (e.CommandName == "Download")
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/Uploads/") + e.CommandArgument);
            Response.End();
        }
    }
}



//<asp:LinkButton ID="lbDelete" <!--OnClientClick="return confirm('Are you sure you want to delete this row');"-->
//                                  CommandArgument='<%# Eval("Id") %>' CommandName="DeleteRow" ForeColor="#8C4510"