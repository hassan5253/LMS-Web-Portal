using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using READBModel;
public partial class Staff_frm_Feedback_Staff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null)
        {
            Response.Redirect("frm_Login_All.aspx");
            return;
        }

        if (!IsPostBack)
        {
            BindItems();
        }
        HideAlerts();
    }
    protected void lnkBtn_Answer_Click(object sender, EventArgs e)
    {
        try
        {

            using (READBEntities cntx = new READBEntities())
            {
                RepeaterItem clickedRow = ((LinkButton)sender).NamingContainer as RepeaterItem;
                Label txtExample = (Label)clickedRow.FindControl("lbl_Q_PID");
                int ID = Convert.ToInt32(txtExample.Text);
                Response.Redirect("frm_FeedbackAnswers_Staff.aspx?q_pid=" + ID);
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    void HideAlerts()
    { divmsg.Visible = false; }

    public void BindItems()
    {
        try
        {


            using (READBEntities cntx = new READBEntities())
            {

                var obj = new object();
                obj = (from q in cntx.tblQueries
                       join a in cntx.tblUsers on q.user_id equals a.user_id
                       where q.q_parent_id == 0
                       orderby q.q_id descending
                       select new { q.q_id, q.q_parent_id, q.q_date, q.user_id, q.q_description, a.name, a.user_type }).ToList();
                rpt_Parent.DataSource = obj;
                rpt_Parent.DataBind();
                foreach (RepeaterItem i in rpt_Parent.Items)
                {

                    Label txtExample = (Label)i.FindControl("lbl_Q_PID");
                    //litResults.Text += txtExample.Text + "<br />";
                    //Response.Write(txtExample.Text);
                    int ID = Convert.ToInt32(txtExample.Text);
                    //int id = obj[i]
                    var objchild = (from q in cntx.tblQueries
                                    join a in cntx.tblUsers on q.user_id equals a.user_id

                                    where q.q_parent_id == ID
                                    orderby q.q_id descending
                                    select new { q.q_id, q.q_parent_id, q.q_date, q.user_id, q.q_description, a.name, a.user_type }).ToList();
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


    //protected void btn_Post_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        using (READBEntities cntx = new READBEntities())
    //        {
    //            tblQueries obj = new tblQueries();
    //            obj.q_date = DateTime.Now;
    //            obj.q_description = txt_Post.Text;
    //            obj.q_parent_id = 0;
    //            obj.user_id =Convert.ToInt64(GlobalClass.User_ID);
    //            cntx.AddTotblQueries(obj);
    //            cntx.SaveChanges();
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
