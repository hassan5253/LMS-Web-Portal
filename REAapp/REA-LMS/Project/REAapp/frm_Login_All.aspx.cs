using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;

public partial class frm_Login_All : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            Clear();     
        }
        else
        {
            
        }
        

    }
    protected void btn_Login_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                string User_Name=txt_UserName.Text;
                string User_Password=txt_UserPassword.Text;
                var obj = (from q in cntx.tblUsers where q.user_name == User_Name && q.user_password == User_Password select new { q.user_id, q.user_name, q.user_password,q.user_type }).FirstOrDefault();
                if (obj != null)
                {
                    ShowMessage("Login Success", GlobalClass.AlertTypes.SuccessType);
                    Session["User_ID"] = obj.user_id;
                    GlobalClass.User_ID = Session["User_ID"].ToString();
                    
                    if (obj.user_type == "Admin")
                    {
                        Response.Redirect("Admin/frm_Home_Admin.aspx");
                    }
                    if (obj.user_type == "Staff")
                    {
                        Response.Redirect("Staff/frm_Home_Staff.aspx");
                    }
                    if (obj.user_type == "Student")
                    {
                        Response.Redirect("Students/frm_Home_Std.aspx");
                    }

                }
                else 
                {
                    ShowMessage("Login Failed", GlobalClass.AlertTypes.ErrorType);
                }


            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, GlobalClass.AlertTypes.Warning);
        }

    }
    private void Clear() 
    {
        txt_UserName.Text = txt_UserPassword.Text = null;
        divmsg.Visible = false;
    }
    public void ShowMessage(string StringMessage, string AlertType)
    {
        divmsg.Visible = true;
        lblMsg.Text = StringMessage;
        if (AlertType == GlobalClass.AlertTypes.SuccessType)
        {
            divmsg.Attributes.Add("class", GlobalClass.AlertTypes.Success);
        }
        else if (AlertType == GlobalClass.AlertTypes.ErrorType)
        {
            divmsg.Attributes.Add("class", GlobalClass.AlertTypes.Error);
        }
        else if (AlertType == GlobalClass.AlertTypes.WarningType)
        {
            divmsg.Attributes.Add("class", GlobalClass.AlertTypes.Warning);
        }
        else if (AlertType == GlobalClass.AlertTypes.InfoType)
        {
            divmsg.Attributes.Add("class", GlobalClass.AlertTypes.Info);
        }
    }
}