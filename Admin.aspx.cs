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
        lblMessage.Text = "";
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
            int RowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            GridView1.EditIndex = RowIndex;
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
            int RowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

            HttpPostedFile FileContent = Request.Files["myEditFile"];
            string FileName = "";
            string UniqueFileName = "";
            string Id = (e.CommandArgument.ToString());
            UserDataAccessLayer.DeleteFile(e.CommandArgument.ToString());
            if (FileContent.ContentLength != 0)
            {
                string FileExtension = System.IO.Path.GetExtension(FileContent.FileName);

                if (FileExtension.ToLower() != ".doc" && FileExtension.ToLower() != ".docx" && FileExtension.ToLower() != ".pdf")
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
                FileName = FileName.Replace(FileExtension, "");
                UniqueFileName = UserDataAccessLayer.GetUniqueName(FileName, Id, FileExtension.ToLower());
                try
                {
                    FileContent.SaveAs(Server.MapPath(Path.Combine("~/Uploads/", UniqueFileName)));
                }
                catch (System.IO.DirectoryNotFoundException exception)
                {
                    
                    Response.Write(exception);
                }
            }

            
           
            string Username = ((TextBox)GridView1.Rows[RowIndex].FindControl("TextBox1")).Text;
            string Email = ((TextBox)GridView1.Rows[RowIndex].FindControl("TextBox2")).Text;
            string Password = ((TextBox)GridView1.Rows[RowIndex].FindControl("TextBox3")).Text;
            string Country = ((TextBox)GridView1.Rows[RowIndex].FindControl("TextBox4")).Text;
            UserDataAccessLayer.UpdateUser(Id, Username, Email, Password, Country, UniqueFileName);

            GridView1.EditIndex = -1;
            BindGridViewData();
        }
        else if (e.CommandName == "InsertRow")
        {
            String NewGUID = Guid.NewGuid().ToString();
            NewGUID = NewGUID.Remove(5, NewGUID.Length - 5);
            HttpPostedFile FileContent = Request.Files["myFile"];
            string FileName = "";
            string UniqueFileName = "";
            if (Path.GetFileName(FileContent.FileName) != "" && FileContent.ContentLength == 0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Brown;
                lblMessage.Text = "Empty File uploaded!";
                
            }
            if (Path.GetFileName(FileContent.FileName) != "")
            {
                string FileExtension = System.IO.Path.GetExtension(FileContent.FileName);

                if (FileExtension.ToLower() != ".doc" && FileExtension.ToLower() != ".docx" && FileExtension.ToLower() != ".pdf")
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
                FileName = FileName.Replace(FileExtension,"");
                 UniqueFileName = UserDataAccessLayer.GetUniqueName(FileName, NewGUID, FileExtension.ToLower());
                 try
                 {
                     FileContent.SaveAs(Server.MapPath(Path.Combine("~/Uploads/", UniqueFileName)));
                 }
                 catch (System.IO.DirectoryNotFoundException exception)
                 {

                     Response.Write(exception);
                 }
            }
            
            string Username = ((TextBox)GridView1.FooterRow.FindControl("txtUsername")).Text;
            string Email = ((TextBox)GridView1.FooterRow.FindControl("txtEmail")).Text;
            string Password = ((TextBox)GridView1.FooterRow.FindControl("txtPassword")).Text;
            string Country = ((TextBox)GridView1.FooterRow.FindControl("txtCountry")).Text;

            UserDataAccessLayer.InsertUser(NewGUID.ToString(), Username, Email, Password, Country, UniqueFileName);

            BindGridViewData();


        }
        else if (e.CommandName == "Download")
        {
            Response.Clear();
       
            if (File.Exists(Server.MapPath("~/Uploads/") + e.CommandArgument))
            {               
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument.ToString().Remove(0, 6));
                Response.TransmitFile(Server.MapPath("~/Uploads/") + e.CommandArgument);
                Response.End();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "File Not Found";                
            }           
        }
    }
    //refine the filename before showing on the Files column
    protected string ExtractData(string fileName)
    {
        if (fileName == "")
        { return fileName; }
        int Index = fileName.IndexOf('~');
       if(Index>0)
        fileName = fileName.Remove(0, Index+1);
        return fileName;
    }
}



//<asp:LinkButton ID="lbDelete" <!--OnClientClick="return confirm('Are you sure you want to delete this row');"-->
//                                  CommandArgument='<%# Eval("Id") %>' CommandName="DeleteRow" ForeColor="#8C4510"