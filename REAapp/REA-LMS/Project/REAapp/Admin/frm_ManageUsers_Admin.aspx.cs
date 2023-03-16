using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using READBModel;
public partial class Admin_frm_ManageUsers_Admin : System.Web.UI.Page
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
            Fill_Grid();
        }
        HideAlerts();
    }
    protected void cb_Header_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

        CheckBox cb_Header = (CheckBox)gv_Users.HeaderRow.FindControl("cb_Header");
        foreach (GridViewRow xRow in gv_Users.Rows)
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
            int ID = Convert.ToInt32(gv_Users.DataKeys[clickedRow.RowIndex].Value);
            Response.Redirect("frm_ManageUsersEdit_Admin.aspx?User_id=" + ID);
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
                var obj_Search=new object();
                DataTable Dt = GlobalClass.CreateDataTable("user_id,name,user_type,user_name,user_password");
                if (dd_Search.SelectedItem.Text == "Name")
                {
                    obj_Search = (from q in cntx.tblUsers where q.name.Contains(txt_Search.Text) select q).ToList();
                }
                if (dd_Search.SelectedItem.Text == "Roll No")
                {
                    obj_Search = (from q in cntx.tblUsers where q.student_roll_no.Contains(txt_Search.Text) select q).ToList();
                }
                if (dd_Search.SelectedItem.Text == "User Type")
                {
                    obj_Search = (from q in cntx.tblUsers where q.user_type.Contains(txt_Search.Text) select q).ToList();
                }



                List<tblUsers> obj_List=obj_Search as List<tblUsers>;

                    for (int i = 0; i <= obj_List.Count - 1; i++)
                    {
                        DataRow xRow;
                        xRow = Dt.NewRow();
                        xRow[0] = obj_List[i].user_id;
                        xRow[1] = obj_List[i].name;
                        xRow[2] = obj_List[i].user_type;
                        xRow[3] = obj_List[i].user_name;
                        xRow[4] = obj_List[i].user_password;
                        Dt.Rows.Add(xRow);
                    }
                    gv_Users.DataSource = Dt;
                    gv_Users.DataBind();
            
            }


        }

        catch (Exception ex)
        {

        }
    }
    protected void lnkBtn_Delete_Click(object sender, EventArgs e)
    {
        try
        {

            using (READBEntities cntx = new READBEntities())
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                int ID = Convert.ToInt32(gv_Users.DataKeys[clickedRow.RowIndex].Value);
                var obj = (from q in cntx.tblUsers where q.user_id == ID select q).FirstOrDefault();
                cntx.DeleteObject(obj);
                cntx.SaveChanges();
                Fill_Grid();
                ShowMessage("Record Deleted Successfully", GlobalClass.AlertTypes.SuccessType);





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
            foreach (GridViewRow xRow in gv_Users.Rows)
            {
                
                CheckBox cb = (CheckBox)xRow.FindControl("cb_Middle");
                if (cb.Checked && cb != null)
                {
                    int ID = Convert.ToInt32(gv_Users.DataKeys[xRow.RowIndex].Value);
                    var obj = (from q in cntx.tblUsers where q.user_id == ID select q).FirstOrDefault();
                    cntx.DeleteObject(obj);
                    cntx.SaveChanges();
                    
                }
            }

            Fill_Grid();
            ShowMessage("Record(s) Deleted Successfully", GlobalClass.AlertTypes.SuccessType);
        }

    }
    private void Fill_Grid()
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                DataTable Dt = GlobalClass.CreateDataTable("user_id,name,user_type,user_name,user_password,user_status");
                var obj_Users = (from q in cntx.tblUsers select q).ToList();
                if (obj_Users.Count > 0)
                {
                    for (int i = 0; i <= obj_Users.Count - 1; i++)
                    {
                        DataRow xRow;
                        xRow = Dt.NewRow();
                        xRow[0] = obj_Users[i].user_id;
                        xRow[1] = obj_Users[i].name;
                        xRow[2] = obj_Users[i].user_type;
                        xRow[3] = obj_Users[i].user_name;
                        xRow[4] = obj_Users[i].user_password;
                        Dt.Rows.Add(xRow);
                    }
                    gv_Users.DataSource = Dt;
                    gv_Users.DataBind();
                    foreach (DataControlField xCol in gv_Users.Columns)
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
        try
        {

        
        Response.Redirect("frm_ManageUsersCreate_admin.aspx");
        }
        catch (Exception)
        {

            throw;
        }
    }
    void HideAlerts()
    { divmsg.Visible = false; }

    protected void gv_Users_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

        
        gv_Users.PageIndex = e.NewPageIndex;
        Fill_Grid();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
