<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="frm_ManageUsersEdit_Admin.aspx.cs" Inherits="Admin_frm_ManageUsersCreate_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Admin" runat="Server">
    <div class="module">
        <div class="module-head">
            <h3>
                Manage Users > Edit User</h3>
        </div>
        <div class="module-body">
            <%--<form class="form-horizontal row-fluid">--%>
            <asp:ScriptManager ID="scriptmanager1" runat="server" EnableScriptGlobalization="true"
                EnableScriptLocalization="true">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>
                    <div class="module-option clearfix">
                        <div class="pull-right">
                            <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-primary" Text="Back" 
                                onclick="btn_Back_Click" />
                        </div>
                    </div>
                    <div id="divmsg" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            &times;</button>
                        <strong>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                    </div>
                    <br />
                <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Name</label>
                        <div class="controls">
                            <asp:TextBox ID="txt_Name" runat="server" CssClass="span6" MaxLength="19"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic"
                                ValidationExpression="[a-zA-Z]+" ControlToValidate="txt_Name" runat="server"
                                ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            User Type</label>
                        <div class="controls">
                            <asp:DropDownList ID="dd_UserType" runat="server" OnSelectedIndexChanged="dd_UserType_SelectedIndexChanged"
                                AutoPostBack="true" CssClass="span6">
                                <asp:ListItem>-- Select --</asp:ListItem>
                                <asp:ListItem>Staff</asp:ListItem>
                                <asp:ListItem>Student</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Course Enrolled</label>
                        <div class="controls">
                            <asp:DropDownList ID="dd_Course" CssClass="span6" runat="server" Enabled="False" >
                                <asp:ListItem>-- Select --</asp:ListItem>
                                <asp:ListItem>B.TECH</asp:ListItem>
                                <asp:ListItem>B.Pharmacy</asp:ListItem>
                                <asp:ListItem>M.B.A</asp:ListItem>
                                <asp:ListItem>M.C.A</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Semester</label>
                        <div class="controls">
                            <asp:DropDownList ID="dd_Semester" runat="server" Enabled="False" CssClass="span6">
                                <asp:ListItem>-- Select --</asp:ListItem>
                                <asp:ListItem>Semester-1</asp:ListItem>
                                <asp:ListItem>Semester-2</asp:ListItem>
                                <asp:ListItem>Semester-3</asp:ListItem>
                                <asp:ListItem>Semester-4</asp:ListItem>
                                <asp:ListItem>Semester-5</asp:ListItem>
                                <asp:ListItem>Semester-6</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Year</label>
                        <div class="controls">
                            <asp:DropDownList ID="dd_Year" runat="server" AutoPostBack="true" CssClass="span6" Enabled="False"
                                OnSelectedIndexChanged="dd_Year_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Batch No</label>
                        <div class="controls">
                            <asp:TextBox ID="txt_BatchYear" MaxLength="4" runat="server" Width="30" AutoPostBack="true"
                                 ReadOnly="True"></asp:TextBox>
                            Month
                            <asp:DropDownList ID="dd_BatchMonth" runat="server" AutoPostBack="true" Width="60" Enabled="False">
                            </asp:DropDownList>
                            Section
                            <asp:TextBox ID="txt_BatchSection" runat="server" Width="10" MaxLength="1" OnTextChanged="txt_BatchSection_TextChanged"
                                AutoPostBack="true" ReadOnly="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic"
                                ValidationExpression="[a-zA-Z]+" ControlToValidate="txt_BatchSection" runat="server"
                                ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txt_BatchNo" runat="server" Width="80" MaxLength="7" AutoPostBack="true"
                                ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            User Name</label>
                        <div class="controls">
                            <asp:TextBox ID="txt_UserName" runat="server"  Width="100" AutoPostBack="true"
                                OnTextChanged="txt_UserName_TextChanged"></asp:TextBox>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic"
                                ValidationExpression="[a-zA-Z]+"  ControlToValidate="txt_UserName" runat="server"
                                ErrorMessage="*" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txt_UserBatchNo" runat="server" MaxLength="7" Width="55" ReadOnly="true"></asp:TextBox>
                            <asp:TextBox ID="txt_UserLogin" ReadOnly ="true" runat="server" MaxLength="15" Width="120"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Password</label>
                        <div class="controls">
                            <asp:TextBox ID="txt_UserPassword" MaxLength="15" runat="server" 
                                CssClass="span6" TextMode="Password">*</asp:TextBox>
                        </div>
                    </div>    <div class="control-group">
                        <div class="controls">
                            <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-large btn-success" Text="Update"
                                OnClick="btn_Save_Click" />
                        </div>
                    </div>
                    <%--                    </form>--%>
                    </div> </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:HiddenField ID="hf_UserID" runat="server"></asp:HiddenField>
</asp:Content>
