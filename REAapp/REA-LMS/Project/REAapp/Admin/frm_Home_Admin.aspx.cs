using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_frm_Home_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null || GlobalClass.User_ID == string.Empty)
        {
            Response.Redirect("../frm_Login_All.aspx");
            return;
        }
    }
    

}