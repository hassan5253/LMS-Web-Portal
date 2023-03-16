using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;
public partial class Staff_Staff : System.Web.UI.MasterPage
{

    long User_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null)
        {
            User_ID = Convert.ToInt64(Session["user_id"]);
            //ShowData();
        }
        else 
        {
            Response.Redirect("../frm_Login_All.aspx");
        }
        //img_User.ImageUrl = "Images/user.png";
    }


    public void ShowData()
    {
        try
        {
            using (READBEntities cntx = new READBEntities()) 
            {
                //img_User.ImageUrl = "images/user.png";
                var obj = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                if (obj.user_type == "Admin") 
                {
                    img_User.ImageUrl = "../images/Users/Admin.png";
                }
                if (obj.user_type == "Staff") 
                {
                    img_User.ImageUrl = "../Images/Users/Staff.png";
                }
                if (obj.user_type == "Student")
                { img_User.ImageUrl = "../Images/Users/Students.png"; }

            }
        }
        catch (Exception)
        {

            throw;
        }

    }
}
