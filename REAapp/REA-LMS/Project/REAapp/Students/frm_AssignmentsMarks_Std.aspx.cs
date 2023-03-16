using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;
using System.Data;
public partial class Students_frm_AssignmentsMarks_Std : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null)
        {
            Response.Redirect("frm_Login_All.aspx");
            return;
        }

    }

    protected void cb_Header_CheckedChanged(object sender, EventArgs e)
    {
        try
        {



            foreach (GridViewRow xRow in gv_Assignments.Rows)
            {

                CheckBox cb_Header = (CheckBox)gv_Assignments.HeaderRow.FindControl("cb_Header");

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
            int ID = Convert.ToInt32(gv_Assignments.DataKeys[clickedRow.RowIndex].Value);

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
            Search();
        }
        catch (Exception)
        {

            throw;
        }



    }

    protected void lnkBtn_ViewDetails_Click(object sender, EventArgs e)
    {

        using (READBEntities cntx = new READBEntities())
        {
            foreach (GridViewRow xRow in gv_Assignments.Rows)
            {
                //GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_Assignments.DataKeys[clickedRow.RowIndex].Value);
                Response.Redirect("frm_AssignmentDetails_Std.aspx?a_id=" + ID);

            }
        }

    }
    protected void lnkBtn_Download_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_Assignments.DataKeys[clickedRow.RowIndex].Value);
                var obj = (from q in cntx.tblAssignments where q.a_id == ID select q).FirstOrDefault();
                string filename = obj.a_file_name;
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
                string aaa = Server.MapPath("../Assignments/" + filename);
                Response.TransmitFile(Server.MapPath("../Assignments/" + filename));
                Response.End();

            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    void Search()
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long User_ID = Convert.ToInt64(GlobalClass.User_ID);
                var obj_Search = new object();
                DataTable Dt = GlobalClass.CreateDataTable("a_id,a_name,a_assigned_by,a_assigned_date,a_submit_date");

                obj_Search = (from q in cntx.tblAssignments
                              join a in cntx.tblAssignmentDetails
                              on q.a_id equals a.a_id
                              where a.student_roll_no.Contains(txt_Search.Text) && a.user_id == User_ID
                              select q).ToList();

                List<tblAssignments> obj_List = obj_Search as List<tblAssignments>;

                for (int i = 0; i <= obj_List.Count - 1; i++)
                {
                    DataRow xRow;
                    xRow = Dt.NewRow();
                    xRow[0] = obj_List[i].a_id;
                    xRow[1] = obj_List[i].a_name;
                    xRow[2] = obj_List[i].a_assigned_by;
                    xRow[3] = Convert.ToDateTime(obj_List[i].a_assigned_date).ToString("dd-MM-yyyy");
                    xRow[4] = Convert.ToDateTime(obj_List[i].a_submit_date).ToString("dd-MM-yyyy");
                    Dt.Rows.Add(xRow);
                }
                gv_Assignments.DataSource = Dt;
                gv_Assignments.DataBind();
                foreach (DataControlField xCol in gv_Assignments.Columns) { if (xCol.HeaderText == "ID") { xCol.Visible = false; } }
                {
                    
                }
            }


        }

        catch (Exception ex)
        {

        }
    }

    private void Fill_Grid()
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long User_ID = Convert.ToInt64(GlobalClass.User_ID);
                DataTable Dt = GlobalClass.CreateDataTable("a_id,a_name,a_assigned_by,a_assigned_date,a_submit_date");
                var obj_User = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                var obj_Assignments = (from q in cntx.tblAssignments
                                       where q.course_name == obj_User.course_name && q.course_semester == obj_User.course_semester && q.course_year == obj_User.course_year && q.batch_no == obj_User.batch_no
                                       select q).ToList();

                if (obj_Assignments.Count > 0)
                {
                    for (int i = 0; i <= obj_Assignments.Count - 1; i++)
                    {
                        DataRow xRow;
                        xRow = Dt.NewRow();
                        xRow[0] = obj_Assignments[i].a_id;
                        xRow[1] = obj_Assignments[i].a_name;
                        xRow[2] = obj_Assignments[i].a_assigned_date;
                        xRow[3] = obj_Assignments[i].a_submit_date;
                        Dt.Rows.Add(xRow);
                    }
                    gv_Assignments.DataSource = Dt;
                    gv_Assignments.DataBind();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }


    }
    protected void gv_Assignments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Assignments.PageIndex = e.NewPageIndex;
        Search();
    }
}