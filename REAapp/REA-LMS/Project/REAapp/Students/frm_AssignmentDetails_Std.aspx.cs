using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;
using System.Data;
public partial class Students_frm_AssignmentDetails_Std : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null)
        {
            Response.Redirect("frm_Login_All.aspx");
            return;
        }
        if (Request.QueryString["a_id"] != null)
        {
            hf_AID.Value = Request.QueryString["a_id"];
            ShowData();
            if (!IsPostBack) { 
            Fill_Grid();
            }
        }

        
        HideAlerts();
    }
    protected void cb_Header_CheckedChanged(object sender, EventArgs e)
    {
        try
        {


            CheckBox cb_Header = (CheckBox)gv_AssDetails.HeaderRow.FindControl("cb_Header");
            foreach (GridViewRow xRow in gv_AssDetails.Rows)
            {
                CheckBox cb_Middle = (CheckBox)xRow.FindControl("cb_Middle");
                if (cb_Header.Checked && cb_Header != null)
                {
                    cb_Middle.Checked = true;
                }
                else
                {
                    cb_Middle.Checked = false;
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


    protected void lnkBtn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(gv_AssDetails.DataKeys[clickedRow.RowIndex].Value);
            Response.Redirect("frm_AssignmentEdit_Std.aspx?ad_id=" + ID + "&a_id=" + hf_AID.Value);


        }

        catch (Exception ex)
        {

        }
    }
    //protected void lnkBtn_Search_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        using (READBEntities cntx = new READBEntities())
    //        {
    //            DataTable Dt = GlobalClass.CreateDataTable("user_id,name,user_type,user_status");
    //            //if (dd_Search.SelectedItem.Text == "Name")
    //            //{

    //            //}



    //            //var obj_Users = (from q in cntx.tblUsers where q.name.Contains(txt_Search.Text) select q).ToList();

    //            //if (obj_Users.Count > 0)
    //            //{
    //            //    for (int i = 0; i <= obj_Users.Count - 1; i++)
    //            //    {
    //            //        DataRow xRow;
    //            //        xRow = Dt.NewRow();
    //            //        xRow[0] = obj_Users[i].user_id;
    //            //        xRow[1] = obj_Users[i].user_type;
    //            //        xRow[2] = obj_Users[i].name;
    //            //        xRow[3] = obj_Users[i].user_status;
    //            //        Dt.Rows.Add(xRow);
    //            //    }
    //            //    gv_AssDetails.DataSource = Dt;
    //            //    gv_AssDetails.DataBind();

    //            //}
    //        }


    //    }

    //    catch (Exception ex)
    //    {

    //    }
    //}
    protected void lnkBtn_Delete_Click(object sender, EventArgs e)
    {
        try
        {

            using (READBEntities cntx = new READBEntities())
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_AssDetails.DataKeys[clickedRow.RowIndex].Value);
                var obj = (from q in cntx.tblAssignmentDetails where q.ad_id == ID select q).FirstOrDefault();
                cntx.DeleteObject(obj);
                cntx.SaveChanges();
                ShowMessage("Record Deleted Successfully",GlobalClass.AlertTypes.SuccessType);
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void lnkBtn_ViewMarks_Click(object sender, EventArgs e)
    {
        try
        {

            using (READBEntities cntx = new READBEntities())
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_AssDetails.DataKeys[clickedRow.RowIndex].Value);
                Response.Redirect("frm_AssignmentMarks_Std.aspx?ad_id=" + ID + "&a_id=" + hf_AID.Value);
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void lnkBtn_View_Click(object sender, EventArgs e)
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
                Response.TransmitFile(Server.MapPath("../AssignmentDetails/" + filename));
                Response.End();




            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void lnkBtn_DeleteAll_Click(object sender, EventArgs e)
    {

        using (READBEntities cntx = new READBEntities())
        {
            foreach (GridViewRow xRow in gv_AssDetails.Rows)
            {

                CheckBox cb = (CheckBox)xRow.FindControl("cb_Middle");
                if (cb.Checked && cb != null)
                {
                    long ID = Convert.ToInt64(gv_AssDetails.DataKeys[xRow.RowIndex].Value);
                    var obj = (from q in cntx.tblAssignmentDetails where q.ad_id == ID select q).FirstOrDefault();
                    cntx.DeleteObject(obj);
                    cntx.SaveChanges();
                    
                }
            }
            Fill_Grid();
            ShowMessage("Record(s) Deleted Successfully", GlobalClass.AlertTypes.SuccessType);
        }


    }


    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long A_ID = Convert.ToInt64(hf_AID.Value);
                long User_ID = Convert.ToInt64(GlobalClass.User_ID);
                tblAssignmentDetails obj = new tblAssignmentDetails();
                obj.a_id = A_ID;
                string fileName = System.IO.Path.GetFileNameWithoutExtension(fu_AssFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(fu_AssFile.PostedFile.FileName).ToString().ToLower();
                string AssName = DateTime.Now.ToString("ddMMyyHHmmss") + fileName + ext;
                fu_AssFile.PostedFile.SaveAs(Server.MapPath("../AssignmentDetails/" + AssName));
                obj.a_file_name = AssName;
                obj.user_id = User_ID;
                var obj_User = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                obj.student_roll_no = obj_User.student_roll_no;
                obj.ad_uploaded_date = DateTime.Now;
                cntx.AddTotblAssignmentDetails(obj);
                cntx.SaveChanges();
                Fill_Grid();
                ShowMessage("Record Saved Successfully", GlobalClass.AlertTypes.SuccessType);

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
                long User_ID = Convert.ToInt64(GlobalClass.User_ID);

                var obj = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                DataTable Dt = GlobalClass.CreateDataTable("ad_id,name,student_roll_no,ad_uploaded_date,ad_marks");
                var obj_Assignments = (from q in cntx.tblAssignmentDetails where q.a_id == A_ID && q.user_id == User_ID orderby q.ad_id descending select q).ToList();

                if (obj_Assignments.Count > 0)
                {
                    for (int i = 0; i <= obj_Assignments.Count - 1; i++)
                    {
                        DataRow xRow;
                        xRow = Dt.NewRow();
                        xRow[0] = obj_Assignments[i].ad_id;
                        xRow[1] = obj.name;
                        xRow[2] = obj_Assignments[i].student_roll_no;
                        xRow[3] = Convert.ToDateTime(obj_Assignments[i].ad_uploaded_date).ToString("dd-MM-yyyy"); ;
                        xRow[4] = obj_Assignments[i].ad_marks;
                        Dt.Rows.Add(xRow);
                    }
                    gv_AssDetails.DataSource = Dt;
                    gv_AssDetails.DataBind();

                    foreach (DataControlField xCol in gv_AssDetails.Columns)
                    {
                        if (xCol.HeaderText == "ID")
                        {
                            xCol.Visible = false;
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
        Response.Redirect("frm_Assignments_Std.aspx");
    }
    protected void gv_AssDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_AssDetails.PageIndex = e.NewPageIndex;
        Fill_Grid();
    }
}