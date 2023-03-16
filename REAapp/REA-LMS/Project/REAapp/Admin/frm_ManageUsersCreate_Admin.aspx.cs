using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;

public partial class Admin_frm_ManageUsersCreate_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (GlobalClass.User_ID == null || GlobalClass.User_ID == string.Empty)
        {
            Response.Redirect("../frm_Login_All.aspx");
            return;
        }
        //Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            BindDdl();
            Clear();

        }

        HideAlerts();      
    }


    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                tblUsers obj = new tblUsers();
                obj.name = txt_Name.Text;
                obj.user_type = dd_UserType.Text;
                obj.user_status = "true";
                if (dd_UserType.Text == "Student")
                {
                    obj.course_name = dd_Course.Text;
                    obj.course_semester = dd_Semester.Text;
                    obj.batch_no = txt_BatchNo.Text;
                    obj.course_year = dd_Year.Text;
                }
                obj.user_name = txt_UserLogin.Text;
                obj.user_password = txt_UserPassword.Text;
                cntx.AddTotblUsers(obj);
                cntx.SaveChanges();
                ShowMessage("Record Saved Successfully", GlobalClass.AlertTypes.SuccessType);
                Clear();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void dd_UserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        
        if (dd_UserType.SelectedIndex != 0)
        {
            if (dd_UserType.SelectedItem.Text == "Student")
            {
                dd_Course.Enabled = true;
                dd_Semester.Enabled = true;
                dd_Year.Enabled = true;
                dd_BatchMonth.Enabled = true;
                txt_BatchSection.ReadOnly=false;
                txt_UserName.MaxLength = 7;
            }
            else
            {
                dd_Course.Enabled = false;
                dd_Semester.Enabled = false;
                dd_Year.Enabled = false;
                dd_BatchMonth.Enabled = false;
                txt_BatchSection.ReadOnly=true;
                txt_UserName.MaxLength = 13;
                dd_Course.SelectedIndex = 0;
                dd_Semester.SelectedIndex = 0;
                dd_Year.SelectedIndex = 0;
                txt_BatchSection.Text = "";
                dd_BatchMonth.SelectedIndex = 0;
                txt_BatchYear.Text = "";
                txt_UserBatchNo.Text= "";
                txt_BatchNo.Text = "";
                txt_UserLogin.Text = "";
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

        
        Response.Redirect("frm_ManageUsers_Admin.aspx");
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void dd_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        
        txt_BatchYear.Text = dd_Year.Text;
        }
        catch (Exception)
        {

            throw;
        }
    }

    

    protected void txt_BatchSection_TextChanged(object sender, EventArgs e)
    {
        try
        {

        
        string BatchMonth="";
        if (dd_BatchMonth.Text.Length < 2)
        {
            BatchMonth = "0" + dd_BatchMonth.Text;
        }
        else 
        {
            BatchMonth =  dd_BatchMonth.Text;
        }
        txt_BatchNo.Text = txt_BatchYear.Text + BatchMonth + txt_BatchSection.Text;
        if (dd_UserType.Text == "Student") 
        {
            txt_UserBatchNo.Text = txt_BatchYear.Text + BatchMonth + txt_BatchSection.Text;
        }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void txt_UserName_TextChanged(object sender, EventArgs e)
    {
        try
        {

        
        if (dd_UserType.Text == "Student")
        {
            txt_UserLogin.Text = txt_UserName.Text + txt_UserBatchNo.Text;
        }
        else { txt_UserLogin.Text = txt_UserName.Text; }
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

    private void Clear()
    {
        try
        {

        
        txt_Name.Text = "";
        txt_UserPassword.Text = "";

        txt_UserName.Text = txt_UserLogin.Text = "";
        dd_Course.Enabled = false;
        dd_Semester.Enabled = false;
        dd_Year.Enabled = false;
        dd_BatchMonth.Enabled = false;
        txt_BatchSection.ReadOnly = true;
        txt_UserName.MaxLength = 13;
        dd_Course.SelectedIndex = 0;
        dd_Semester.SelectedIndex = 0;
        dd_Year.SelectedIndex = 0;
        txt_BatchSection.Text = "";
        dd_BatchMonth.SelectedIndex = 0;
        txt_BatchYear.Text = "";
        txt_UserBatchNo.Text = "";
        txt_BatchNo.Text = "";
        txt_UserLogin.Text = "";
        dd_UserType.SelectedIndex = 0;
        }
        catch (Exception)
        {

            throw;
        }

    }
    void HideAlerts() { divmsg.Visible = false; }
    void BindDdl()
    {
        try
        {

        
        dd_Year.Items.Insert(0, "---Select Year---");
        int index = 1;
        for (int Year = 1980; Year <= DateTime.Now.Year; Year++)
        {
            ListItem li = new ListItem(Year.ToString(), Year.ToString());
            dd_Year.Items.Insert(index, li);
            index++;
        }

        int i = 0;
        for (int m = 1; m <= 12; m++)
        {
            ListItem li = new ListItem(m.ToString(), m.ToString());
            dd_BatchMonth.Items.Insert(i, li);
            i++;
        }

        }
        catch (Exception)
        {

            throw;
        }


    }
}