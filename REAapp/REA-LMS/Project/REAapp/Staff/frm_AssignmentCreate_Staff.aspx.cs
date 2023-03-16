using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using READBModel;
using System.IO;
using System.Globalization;
public partial class Staff_frm_AssignmentCreate_Staff : System.Web.UI.Page
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
            BindDdl();
        }
        HideAlerts();
            
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            using (READBEntities cntx = new READBEntities())
            {
                long User_ID =Convert.ToInt64(GlobalClass.User_ID);
                tblAssignments obj = new tblAssignments();
                obj.a_name = txt_AssName.Text;
                obj.a_description = txt_AssDes.Text;
                string fileName = Path.GetFileNameWithoutExtension(fu_AssFile.PostedFile.FileName);
                string ext = System.IO.Path.GetExtension(fu_AssFile.PostedFile.FileName).ToString().ToLower();
                string AssName =  DateTime.Now.ToString("ddMMyyHHmmss")+fileName + ext;
                fu_AssFile.PostedFile.SaveAs(Server.MapPath("../Assignments/" + AssName));
                obj.a_file_name = AssName;
                obj.course_name = dd_Course.Text;
                obj.course_semester = dd_Semester.Text;
                obj.course_year = dd_Year.Text;
                obj.batch_no = dd_BatchNo.Text;
                var obj_User = (from q in cntx.tblUsers where q.user_id == User_ID select q).FirstOrDefault();
                obj.a_assigned_by = obj_User.name;
                obj.user_id = User_ID;
                obj.a_assigned_date = DateTime.Now;
                string sd = Request.Form[txt_SubDate.UniqueID];
                DateTime date = DateTime.ParseExact(sd, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                obj.a_submit_date = date;
                cntx.AddTotblAssignments(obj);
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
    void Clear()
    {
        txt_AssDes.Text = txt_AssName.Text = txt_SubDate.Text = "";
        dd_Course.Text = dd_Semester.Text = "";
        dd_Year.SelectedIndex = 0;
        dd_BatchNo.SelectedIndex = 0;
        dd_Semester.SelectedIndex = 0;
        dd_Course.SelectedIndex = 0;
        
       
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

        using (READBEntities cntx = new READBEntities())
        {
            var obj = (from q in cntx.tblUsers where q.user_type == "Student" select q.batch_no).Distinct().ToList();
            dd_BatchNo.DataSource = obj;
            dd_BatchNo.DataBind();
            dd_BatchNo.Items.Insert(0, "---Select batch No---");
        }

        }
        catch (Exception)
        {

            throw;
        }


    }
    void HideAlerts() { divmsg.Visible = false; }
    protected void btn_Back_Click(object sender, EventArgs e)
    {
        try
        {

        
     
        Response.Redirect("frm_Assignments_Staff.aspx");
        }
        catch (Exception)
        {

            throw;
        }
    
    }
}