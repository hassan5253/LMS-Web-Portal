﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;
using System.Data;
public partial class Admin_frm_AssignmentsMarks_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null || GlobalClass.User_ID == string.Empty)
        {
            Response.Redirect("../frm_Login_All.aspx");
            return;
        }
        if (!IsPostBack)
        {
            //Fill_Grid();
        }
        HideAlerts();
    }

    protected void cb_Header_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

        
        CheckBox cb_Header = (CheckBox)gv_Assignments.HeaderRow.FindControl("cb_Header");
        foreach (GridViewRow xRow in gv_Assignments.Rows)
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
    protected void lnkBtn_Edit_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
            int ID = Convert.ToInt32(gv_Assignments.DataKeys[clickedRow.RowIndex].Value);
            Response.Redirect("frm_AssignmentEdit_Admin.aspx?A_ID=" + ID);
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
    protected void lnkBtn_Delete_Click(object sender, EventArgs e)
    {
        try
        {

            using (READBEntities cntx = new READBEntities())
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_Assignments.DataKeys[clickedRow.RowIndex].Value);
                var obj = (from q in cntx.tblAssignments where q.a_id == ID select q).FirstOrDefault();
                cntx.DeleteObject(obj);
                cntx.SaveChanges();
            //    Fill_Grid();
                ShowMessage("Record Deleted Successfully!",GlobalClass.AlertTypes.SuccessType);
                

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
    protected void lnkBtn_ViewDetails_Click(object sender, EventArgs e)
    {
        try
        {

            using (READBEntities cntx = new READBEntities())
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_Assignments.DataKeys[clickedRow.RowIndex].Value);
                Response.Redirect("frm_AssignmentDetails_Admin.aspx?a_id=" + ID);




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
            foreach (GridViewRow xRow in gv_Assignments.Rows)
            {

                CheckBox cb = (CheckBox)xRow.FindControl("cb_Middle");
                if (cb.Checked && cb != null)
                {
                    long ID = Convert.ToInt64(gv_Assignments.DataKeys[xRow.RowIndex].Value);
                    var obj = (from q in cntx.tblAssignments where q.a_id == ID select q).FirstOrDefault();
                    cntx.DeleteObject(obj);
                    cntx.SaveChanges();
                    //Fill_Grid();
                    ShowMessage("Record(s) Deleted Successfully", GlobalClass.AlertTypes.SuccessType);
                }
            }
        }



    }




    void Search()
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                var obj_Search = new object();
                DataTable Dt = GlobalClass.CreateDataTable("a_id,a_name,a_assigned_by,a_assigned_date,a_submit_date");
                long User_ID = Convert.ToInt64(GlobalClass.User_ID);
                obj_Search = (from q in cntx.tblAssignments
                              join a in cntx.tblAssignmentDetails
                              on q.a_id equals a.a_id
                              where a.student_roll_no.Contains(txt_Search.Text) && q.user_id == User_ID
                              orderby q.a_id descending
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
                foreach (DataControlField xCol in gv_Assignments.Columns)
                {
                    if (xCol.HeaderText == "ID") 
                    {
                        xCol.Visible = false;
                    }
                    
                }

            }


        }

        catch (Exception ex)
        {

        }
    }

    void HideAlerts()
    { divmsg.Visible = false; }

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
    protected void btn_CNR_Click(object sender, EventArgs e)
    {
        Response.Redirect("frm_AssignmentCreate_Admin.aspx");
    }
    protected void gv_Assignments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Assignments.PageIndex = e.NewPageIndex;
        Search();
    }
}