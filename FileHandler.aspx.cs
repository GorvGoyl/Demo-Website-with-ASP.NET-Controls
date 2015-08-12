using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data; 

public partial class FileHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("File");
        dt.Columns.Add("Size");
        dt.Columns.Add("Type");
        try
        {
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Uploads")))
            {
                FileInfo fi = new FileInfo(strfile);
                dt.Rows.Add(fi.Name, fi.Length.ToString(), GetFileTypeByExtension(fi.Extension));
                //dt.Rows.Add(fi.Name, fi.Length,fi.Extension);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception exception)
        {
            
            Response.Write( exception);
        }
    }
    protected void ButtonUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                // Get the file size
                int fileSize = FileUpload1.PostedFile.ContentLength;
                // If file size is greater than 10 MB
                if (fileSize > 10000000)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "File size cannot be greater than 10 MB";
                }
                else
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a file (Max. size is 10 MB)";
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("File");
            dt.Columns.Add("Size");
            dt.Columns.Add("Type");

            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Uploads")))
            {
                FileInfo fi = new FileInfo(strfile);
                dt.Rows.Add(fi.Name, fi.Length.ToString(), GetFileTypeByExtension(fi.Extension));
                //dt.Rows.Add(fi.Name, fi.Length,fi.Extension);
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception exception)
        {

            Response.Write(exception);
        }
        //    if (FileUpload1.HasFile)
        //    {
        //        // Get the file extension
        //        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

        //        if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToLower() != ".pdf")
        //        {
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //            lblMessage.Text = "Only files with .doc or.docx or .pdf extension are allowed";
        //        }
        //        else
        //        {
                    // Get the file size
                    //int fileSize = FileUpload1.PostedFile.ContentLength;
                    // If file size is greater than 2 MB
                    //if (fileSize > 2097152)
                    //{
                    //    lblMessage.ForeColor = System.Drawing.Color.Red;
                    //    lblMessage.Text = "File size cannot be greater than 2 MB";
                    //}
                    //else
                    //{
        //                // Upload the file
        //                FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
        //                lblMessage.ForeColor = System.Drawing.Color.Green;
        //                lblMessage.Text = "File uploaded successfully";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        lblMessage.ForeColor = System.Drawing.Color.Red;
        //        lblMessage.Text = "Please select a file (Max. size is 2MB)";
        //    } 
        }
    private string GetFileTypeByExtension(string fileExtension)
    {
        switch (fileExtension.ToLower())
        {
            case ".docx":
            case ".doc":
                return "Microsoft Word Document";
            case ".xlsx":
            case ".xls":
                return "Microsoft Excel Document";
            case ".txt":
                return "Text Document";
            case ".jpg":
            case ".png":
                return "Image";
            case ".pdf":
                return "Portable Document Format";
            case ".ppt":
            case ".pptx":
                return "PowerPoint Presentation";
            case ".mp3":
                return "Audio File";
            default:
                return "Unknown";
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "filename="
            + e.CommandArgument);
        Response.TransmitFile(Server.MapPath("~/Uploads/")
            + e.CommandArgument);
        Response.End();
    }
}