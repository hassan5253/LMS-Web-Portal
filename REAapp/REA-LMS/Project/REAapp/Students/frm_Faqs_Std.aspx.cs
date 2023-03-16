using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using READBModel;
public partial class Students_frm_Faqs_Std : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null)
        {
            Response.Redirect("frm_Login_All.aspx");
            return;
        }
        if (!IsPostBack) { 
        BindItems();
        }
        HideAlerts();
    }
    //protected void lnkBtn_Edit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        using (READBEntities cntx = new READBEntities())
    //        {
    //            RepeaterItem clickedRow = ((LinkButton)sender).NamingContainer as RepeaterItem;
    //            Label txtExample = (Label)clickedRow.FindControl("lbl_F_PID");
    //            int ID = Convert.ToInt32(txtExample.Text);
    //            Response.Redirect("frm_FaqsEdit_Staff.aspx?f_pid=" + ID);
    //        }

    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}
    //protected void lnkBtn_Delete_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        using (READBEntities cntx = new READBEntities())
    //        {
    //            RepeaterItem clickedRow = ((LinkButton)sender).NamingContainer as RepeaterItem;
    //            Label txtExample = (Label)clickedRow.FindControl("lbl_Q_PID");
    //            int ID = Convert.ToInt32(txtExample.Text);
    //            Response.Redirect("frm_FeedbackAnswers_Staff.aspx?q_pid=" + ID);
    //        }

    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}
    public void BindItems()
    {
        try
        {

        
        using (READBEntities cntx = new READBEntities())
        {

            var obj = new object();
            obj = (from q in cntx.tblFaqs 
                   where q.f_parent_id == 0
                   select q).ToList(); 
            rpt_Parent.DataSource = obj;
            rpt_Parent.DataBind();
            foreach (RepeaterItem i in rpt_Parent.Items)
            {

                Label txtExample = (Label)i.FindControl("lbl_F_PID");
                //litResults.Text += txtExample.Text + "<br />";
                //Response.Write(txtExample.Text);
                int ID = Convert.ToInt32(txtExample.Text);
                //int id = obj[i]
                var objchild = (from q in cntx.tblFaqs
                                where q.f_parent_id == ID
                                select q).ToList();
                ((Repeater)(i.FindControl("rpt_Child"))).DataSource = objchild;
                ((Repeater)(i.FindControl("rpt_Child"))).DataBind();



            }




        }
        }
        catch (Exception)
        {

            throw;
        }
    }

    void HideAlerts()
    { divmsg.Visible = false; }


    //protected void btn_Post_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        using (READBEntities cntx = new READBEntities())
    //        {
    //            tblFaqs obj = new tblFaqs();
    //            obj.f_parent_id = 0;
    //            obj.F_description = txt_Post.Text;
    //            cntx.AddTotblFaqs(obj);
    //            cntx.SaveChanges();
    //            BindItems();
    //            ShowMessage("Record Saved Successfully",GlobalClass.AlertTypes.SuccessType);
    //        }

    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}
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
