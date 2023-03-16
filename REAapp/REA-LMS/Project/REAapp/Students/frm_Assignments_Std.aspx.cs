using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;
using System.Data;
using System.Globalization;
public partial class Students_frm_Assignments_Std : System.Web.UI.Page
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
            Fill_Grid();
        }
    }

    protected void cb_Header_CheckedChanged(object sender, EventArgs e)
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
            using (READBEntities cntx = new READBEntities())
            {
                long User_ID = Convert.ToInt64(GlobalClass.User_ID);
                var obj_User = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                var obj_Search = new object();
                DataTable Dt = GlobalClass.CreateDataTable("a_id,a_name,a_assigned_by,a_assigned_date,a_submit_date");
                if (dd_Search.SelectedItem.Text == "Assignment Name")
                {
                    obj_Search = (from q in cntx.tblAssignments where q.a_name.Contains(txt_Search.Text) &&   q.course_name == obj_User.course_name && q.course_semester == obj_User.course_semester && q.course_year == obj_User.course_year && q.batch_no == obj_User.batch_no orderby q.a_id descending select q).ToList();
                }
                if (dd_Search.SelectedItem.Text == "Assignment Date")
                {
                    string sd = Request.Form[txt_DateSearch.UniqueID];
                    DateTime sDate = DateTime.ParseExact(sd, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    obj_Search = (from q in cntx.tblAssignments where q.a_assigned_date == sDate && q.course_name == obj_User.course_name && q.course_semester == obj_User.course_semester && q.course_year == obj_User.course_year && q.batch_no == obj_User.batch_no orderby q.a_id descending select q).ToList();
                }
                if (dd_Search.SelectedItem.Text == "Assignment Submit Date")
                {
                    string sd = Request.Form[txt_DateSearch.UniqueID];
                    DateTime sDate = DateTime.ParseExact(sd, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    obj_Search = (from q in cntx.tblAssignments where q.a_submit_date == sDate && q.course_name == obj_User.course_name && q.course_semester == obj_User.course_semester && q.course_year == obj_User.course_year && q.batch_no == obj_User.batch_no orderby q.a_id descending select q).ToList();
                }
                if (dd_Search.SelectedItem.Text == "Course Name")
                {
                    obj_Search = (from q in cntx.tblAssignments where q.course_name.Contains(txt_Search.Text) && q.course_name == obj_User.course_name && q.course_semester == obj_User.course_semester && q.course_year == obj_User.course_year && q.batch_no == obj_User.batch_no orderby q.a_id descending select q).ToList();
                }
                if (dd_Search.SelectedItem.Text == "Batch No")
                {
                    obj_Search = (from q in cntx.tblAssignments where q.batch_no.Contains(txt_Search.Text) && q.course_name == obj_User.course_name && q.course_semester == obj_User.course_semester && q.course_year == obj_User.course_year && q.batch_no == obj_User.batch_no orderby q.a_id descending select q).ToList();
                }



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

            }


        }

        catch (Exception ex)
        {

        }

    }

    
    protected void lnkBtn_ViewDetails_Click(object sender, EventArgs e)
    {
        try
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
                                       orderby q.a_id descending
                                       select q).ToList();

                if (obj_Assignments.Count > 0)
                {
                    for (int i = 0; i <= obj_Assignments.Count - 1; i++)
                    {
                        DataRow xRow;
                        xRow = Dt.NewRow();
                        xRow[0] = obj_Assignments[i].a_id;
                        xRow[1] = obj_Assignments[i].a_name;
                        xRow[2] = obj_Assignments[i].a_assigned_by;
                        xRow[3] = Convert.ToDateTime(obj_Assignments[i].a_assigned_date).ToString("dd-MM-yyyy"); ;
                        xRow[4] = Convert.ToDateTime(obj_Assignments[i].a_submit_date).ToString("dd-MM-yyyy");
                        Dt.Rows.Add(xRow);
                    }
                    gv_Assignments.DataSource = Dt;
                    gv_Assignments.DataBind();
                    foreach (DataControlField xField in gv_Assignments.Columns)
                    {
                        if (xField.HeaderText == "ID")
                        {
                            xField.Visible = false;
                        }
                    }
                }

            }
        }
        catch (Exception)
        {

            throw;
        }


    }
    protected void dd_Search_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dd_Search.Text == "Assignment Date" || dd_Search.Text == "Assignment Submit Date")
        {
            txt_Search.Visible = false;
            txt_DateSearch.Visible = true;
        }
        else
        {
            txt_Search.Visible = true;
            txt_DateSearch.Visible = false;
        }


    }
    protected void gv_Assignments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Assignments.PageIndex = e.NewPageIndex;
        Fill_Grid();
    }
}