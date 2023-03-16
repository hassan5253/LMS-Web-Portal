using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;

public partial class Students_frm_AssignmentMarks_Std : System.Web.UI.Page
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
                           select new { q.student_roll_no, a.a_name, a.course_name, a.course_semester, a.course_year, a.batch_no, q.ad_marks, q.user_id }).FirstOrDefault();
                long User_ID = Convert.ToInt64(obj.user_id);

                var obj_User = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                lbl_Batch.Text = obj.batch_no;
                lbl_Course.Text = obj.course_name;
                lbl_Semester.Text = obj.course_semester;
                lbl_Year.Text = obj.course_year;
                txt_StdRollNo.Text = obj.student_roll_no;
                txt_StdName.Text = obj_User.name;
                txt_AssName.Text = obj.a_name;
                txt_AssMarks.Text = obj.ad_marks.ToString();
            }


        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_AssignmentDetails_Std.aspx?a_id="+hf_AID.Value);
    }
}