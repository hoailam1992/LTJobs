using MasterService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MSCaptcha;
public partial class depositupload : System.Web.UI.Page
{
    long userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMessage.Visible = false; 
        }
        if (!long.TryParse(Session["UserId"]!=null? Session["UserId"].ToString():"a", out userId))
        {
            Response.Redirect("login.aspx");
        }

    }
    private bool validateCaptcha(UserActionEventArgs e)
    {
        var captchaControl = e.ContentView.FindControl("CaptchaControl") as CaptchaControl;
        var captchaInput = e.ContentView.FindControl("CaptchaInput") as TextBox;

        captchaControl.ValidateCaptcha(captchaInput.Text);
        return captchaControl.UserValidated;
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        HttpPostedFile postedFile = FileUpload1.PostedFile;
        string filename = Path.GetFileName(postedFile.FileName);
        string fileExtension = Path.GetExtension(filename);
        int fileSize = postedFile.ContentLength;
        if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
        {
            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
            using (MasterServiceClient tempClient = new MasterServiceClient())
            {
                Photo photoEntity = new Photo();
                photoEntity.Image = bytes;
                photoEntity.PhotoDescription = inputDescription.Value;
                photoEntity.PhotoLink = "";
                photoEntity.UserId = userId;
                photoEntity.UploadedDate = DateTime.Now;
                photoEntity.CreatedDate = DateTime.Now;
                var Result =  tempClient.SavePhoto(photoEntity);
                if (Result.IsSuccess && Result.Result != null)
                {
                    lblMessage.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Upload Successful";
                    uploadedimage.Src="data: image / png; base64," +Convert.ToBase64String(Result.Result.Image);
                }
            }
        } else {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";           
        }
    }
}
