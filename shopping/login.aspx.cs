using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    MasterService.MasterServiceClient tempClient = new MasterService.MasterServiceClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnLogIn.Click += BtnLogIn_Click;
    }

    private void BtnLogIn_Click(object sender, EventArgs e)
    {
        var result = tempClient.LoginUser(inputUserName.Value, inputPass.Value);
        if (result.IsSuccess && result.Result != null)
        {
            WebRequest temp = WebRequest.Create("http://localhost:7368/RestfulService.svc/DoWork");
            var response = temp.GetResponse();
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            inputUserName.Value = responseFromServer;
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
        }
    }
}