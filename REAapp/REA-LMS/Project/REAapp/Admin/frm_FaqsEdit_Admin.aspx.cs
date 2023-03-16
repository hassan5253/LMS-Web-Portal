using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using READBModel;
public partial class Admin_frm_FaqsEdit_Admin : System.Web.UI.Page
{
    int F_PID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null)
        {
            Response.Redirect("frm_Login_All.aspx");
            return;
        }
        if (Request.QueryString["f_pid"] != null)
        {
            F_PID =Convert.ToInt32(Request.QueryString["f_pid"]);

        }
        HideAlerts();
    }


    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                tblFaqs obj = new tblFaqs();
                obj.f_description = txt_Answer.Text;
                obj.f_parent_id = F_PID;
                cntx.AddTotblFaqs(obj);
                cntx.SaveChanges();
                ShowMessage("Record Saved Successfully", GlobalClass.AlertTypes.SuccessType);
            }

        }
        catch (Exception)
        {

            throw;
        }


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
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        try
        {

        

        Response.Redirect("frm_Faqs_Admin.aspx");
        }
        catch (Exception)
        {

            throw;
        }

    }
    void HideAlerts()
    { divmsg.Visible = false; }

}
