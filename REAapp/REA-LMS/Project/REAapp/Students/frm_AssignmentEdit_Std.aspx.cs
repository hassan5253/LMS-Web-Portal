using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;
public partial class Students_frm_AssignmentEdit_Std : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null)
        {
            Response.Redirect("frm_Login_All.aspx");
            return;
        }
        if (Request.QueryString["ad_id"] != null)
        {
            hf_ADID.Value = Request.QueryString["ad_id"];
            hf_AID.Value = Request.QueryString["a_id"];
            ShowData();
        }
        HideAlerts();
    }
    void HideAlerts()
    { divmsg.Visible = false; }


    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long AD_ID = Convert.ToInt64(hf_ADID.Value);
                var obj = (from q in cntx.tblAssignmentDetails where q.ad_id == AD_ID select q).FirstOrDefault();
                string fileName = System.IO.Path.GetFileNameWithoutExtension(fu_AssFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(fu_AssFile.PostedFile.FileName).ToString().ToLower();
                string AssName = DateTime.Now.ToString("ddMMyyHHmmss") + fileName + ext;
                fu_AssFile.PostedFile.SaveAs(Server.MapPath("../AssignmentDetails/" + AssName));
                obj.a_file_name = AssName;
                cntx.SaveChanges();
                ShowMessage("Record Updated Successfully", GlobalClass.AlertTypes.SuccessType);
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    public void ShowData()
    {

        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long Ad_ID = Convert.ToInt64(hf_ADID.Value);
                var obj = (from q in cntx.tblAssignmentDetails
                           join a in cntx.tblAssignments on q.a_id equals a.a_id
                           where q.ad_id == Ad_ID
                           select new { q.student_roll_no, q.a_file_name, a.a_name, a.course_name, a.course_semester, a.course_year, a.batch_no, q.ad_marks, q.user_id }).FirstOrDefault();
                long User_ID = Convert.ToInt64(obj.user_id);

                var obj_User = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                lbl_Batch.Text = obj.batch_no;
                lbl_Course.Text = obj.course_name;
                lbl_Semester.Text = obj.course_semester;
                lbl_Year.Text = obj.course_year;
                //fu_AssFile.PostedFile.FileName = obj.a_file_name;

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
        Response.Redirect("frm_AssignmentDetails_Std.aspx?a_id=" + hf_AID.Value);
    }
}