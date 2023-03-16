using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using READBModel;
public partial class Admin_frm_AssignmentDetails_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null || GlobalClass.User_ID==string.Empty)
        {
            Response.Redirect("../frm_Login_All.aspx");
            return;
        }
        if(Request.QueryString["a_id"]!=null)
        {
            hf_AID.Value = Request.QueryString["a_id"];
            ShowData();
        }
        if (!IsPostBack) 
        { 
            Fill_Grid(); 
        }
        HideAlerts();
        
    }
    protected void cb_Header_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

        
        foreach (GridViewRow xRow in gv_AssDetails.Rows)
        {

            CheckBox cb_Header = (CheckBox)gv_AssDetails.HeaderRow.FindControl("cb_Header");

            if (cb_Header.Checked && cb_Header != null)
            {
                CheckBox cb_Middle = (CheckBox)xRow.FindControl("cb_Header");
                cb_Middle.Checked = true;
            }

        }
        }
        catch (Exception)
        {

            throw;
        }

    }

    protected void lnkBtn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(gv_AssDetails.DataKeys[clickedRow.RowIndex].Value);

            Response.Redirect("frm_ManageUsersEdit_Admin.aspx?ID=" + ID);


        }

        catch (Exception ex)
        {

        }
    }
    protected void lnkBtn_Search_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long A_ID = Convert.ToInt64(hf_AID.Value);
                long User_ID;
                var obj_Search = new object();
                DataTable Dt = GlobalClass.CreateDataTable("ad_id,name,student_roll_no,ad_uploaded_date,ad_marks");
                if (dd_Search.SelectedItem.Text == "Student Roll No.")
                {
                    obj_Search = (from q in cntx.tblAssignmentDetails where q.a_id ==A_ID && q.student_roll_no.Contains(txt_Search.Text) orderby q.ad_id descending select q).ToList();
                }
                List<tblAssignmentDetails> obj_List = obj_Search as List<tblAssignmentDetails>;

                for (int i = 0; i <= obj_List.Count - 1; i++)
                {
                    DataRow xRow;
                    xRow = Dt.NewRow();
                    xRow[0] = obj_List[i].ad_id;
                    User_ID = Convert.ToInt64(obj_List[i].user_id);
                    var obj = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                    xRow[1] = obj.name;
                    xRow[2] = obj_List[i].student_roll_no;
                    xRow[3] = Convert.ToDateTime(obj_List[i].ad_uploaded_date).ToString("dd-MM-yyyy");
                    xRow[4] = obj_List[i].ad_marks;
                    Dt.Rows.Add(xRow);
                }
                gv_AssDetails.DataSource = Dt;
                gv_AssDetails.DataBind();

            }


        }

        catch (Exception ex)
        {

        }


    }
    
    protected void lnkBtn_Marks_Click(object sender, EventArgs e)
    {
        try
        {

            using (READBEntities cntx = new READBEntities())
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_AssDetails.DataKeys[clickedRow.RowIndex].Value);
                Response.Redirect("frm_AssignmentMarks_Admin.aspx?ad_id=" + ID+"&a_id="+hf_AID.Value);




            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void lnkBtn_Download_Click(object sender, EventArgs e)
    {
        try
        {

            using (READBEntities cntx = new READBEntities())
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_AssDetails.DataKeys[clickedRow.RowIndex].Value);
                var obj = (from q in cntx.tblAssignments where q.a_id == ID select q).FirstOrDefault();
                string filename = obj.a_file_name;
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
                string aaa = Server.MapPath("../AssignmentDetails/" + filename);
                Response.TransmitFile(Server.MapPath("../Assignments/" + filename));
                Response.End();



            }

        }
        catch (Exception)
        {

            throw;
        }
    }

    void HideAlerts()
    {  }

    public void ShowData()
    {

        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long A_ID = Convert.ToInt64(hf_AID.Value);
                var obj = (from a in cntx.tblAssignments
                           where a.a_id == A_ID
                           select new { a.a_name, a.course_name, a.course_semester, a.course_year, a.batch_no }).FirstOrDefault();


                lbl_Batch.Text = obj.batch_no;
                lbl_Course.Text = obj.course_name;
                lbl_Semester.Text = obj.course_semester;
                lbl_Year.Text = obj.course_year;
            }


        }
        catch (Exception)
        {

            throw;
        }

    }
    private void Fill_Grid()
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long A_ID = Convert.ToInt64(hf_AID.Value);
                long User_ID;
                DataTable Dt = GlobalClass.CreateDataTable("ad_id,name,student_roll_no,ad_uploaded_date,ad_marks");
                var obj_Assignments = (from q in cntx.tblAssignmentDetails where q.a_id==A_ID orderby q.ad_id descending select q).ToList();

                if (obj_Assignments.Count > 0)
                {
                    for (int i = 0; i <= obj_Assignments.Count - 1; i++)
                    {
                        DataRow xRow;
                        xRow = Dt.NewRow();
                        xRow[0] = obj_Assignments[i].ad_id;
                        User_ID=Convert.ToInt64(obj_Assignments[i].user_id);
                        var obj=(from q in cntx.tblUsers where q.user_id==User_ID select q).FirstOrDefault();
                        xRow[1] = obj.name;
                        xRow[2] = obj_Assignments[i].student_roll_no;
                        xRow[3] =Convert.ToDateTime(obj_Assignments[i].ad_uploaded_date).ToString("dd-MM-yyyy");
                        xRow[4] = obj_Assignments[i].ad_marks;
                        Dt.Rows.Add(xRow);
                    }
                    gv_AssDetails.DataSource = Dt;
                    gv_AssDetails.DataBind();
                    foreach (DataControlField xCol in gv_AssDetails.Columns)
                    {
                        if (xCol.HeaderText == "ID") { xCol.Visible = false; }
                        
                    }
                }
            }
        }
        catch (Exception)
        {

            throw;
        }


    }
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        try
        {

        
        Response.Redirect("frm_Assignments_Admin.aspx");
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void gv_AssDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

        
        gv_AssDetails.PageIndex = e.NewPageIndex;
        Fill_Grid();
        }
        catch (Exception)
        {

            throw;
        }
    }
}