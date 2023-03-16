using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using READBModel;
public partial class Admin_frm_FeedbackAnswers_Admin : System.Web.UI.Page
{
    long Q_PID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null)
        {
            Response.Redirect("frm_Login_All.aspx");
            return;
        }
        if (Request.QueryString["q_pid"] != null)
        {
            Q_PID =Convert.ToInt64(Request.QueryString["q_pid"]);

        }
        HideAlerts();
    }
    protected void btn_Back_Click(object sender, EventArgs e)
    {

        try
        {

        
        Response.Redirect("frm_Feedback_Admin.aspx");
        }
        catch (Exception)
        {

            throw;
        }

    }


    void HideAlerts()
    { divmsg.Visible = false; }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                tblQueries obj = new tblQueries();
                obj.q_date = DateTime.Now;
                obj.q_description = txt_Answer.Text;
                obj.q_parent_id = Q_PID;
                obj.user_id = Convert.ToInt64(GlobalClass.User_ID);
                cntx.AddTotblQueries(obj);
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
}
