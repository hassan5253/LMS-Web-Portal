﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="frm_AssignmentCreate_Admin.aspx.cs" Inherits="Admin_frm_AssignmentCreate_Admin" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Admin" runat="Server">
    <head>
        <script type="text/javascript">
            function CheckDateEalier(sender, args) {
                if (sender._selectedDate < new Date()) {
                    alert("You cannot select a day before today!");
                    sender._selectedDate = new Date();
                    // set the date back to the today
                    sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                }
            }
        </script>
    </head>
    <div class="module">
        <div class="module-head">
            <h3>
                Assignments & Marks > Create New Assignment</h3>
        </div>
        <div class="module-body">
            <asp:ScriptManager ID="scriptmanager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="module-option clearfix">
                        <div class="pull-right">
                            <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btn_Back_Click" />
                        </div>
                    </div>
                    <div id="divmsg" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            &times;</button>
                        <strong>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                    </div>
                    <br />
                    <%--<form class="form-horizontal row-fluid">--%>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Course Name</label>
                        <div class="controls">
                            <asp:DropDownList ID="dd_Course" runat="server" CssClass="span6">
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
                            <asp:DropDownList ID="dd_Semester" runat="server" CssClass="span6">
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
                            <asp:DropDownList ID="dd_Year" runat="server" AutoPostBack="true" CssClass="span6">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Batch No</label>
                        <div class="controls">
                            <asp:DropDownList ID="dd_BatchNo" runat="server" CssClass="span6">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Assignment Name</label>
                        <div class="controls">
                            <asp:TextBox ID="txt_AssName" runat="server" CssClass="span6" MaxLength="30"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Assingment Description</label>
                        <div class="controls">
                            <asp:TextBox ID="txt_AssDes" runat="server" MaxLength="90" CssClass="span6" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <ajax:CalendarExtender ID="Calenderextender" PopupPosition="TopRight" OnClientDateSelectionChanged="CheckDateEalier"
                        runat="server" TargetControlID="txt_SubDate" Format="dd-MM-yyyy" DaysModeTitleFormat="dd-MM-yyyy">
                    </ajax:CalendarExtender>
                    <div class="control-group">
                        <label class="control-label" for="basicinput">
                            Submit Till</label>
                        <div class="controls">
                            <asp:TextBox ID="txt_SubDate" runat="server" ReadOnly="true" CssClass="span6"></asp:TextBox>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="control-group">
                <label class="control-label" for="basicinput">
                    Upload File</label>
                <div class="controls">
                    <asp:FileUpload runat="server" ID="fu_AssFile" />
                    
                </div>
            </div>
            <div class="control-group">
                <div class="controls">
                    <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-large btn-success" Text="Save"
                        OnClick="btn_Save_Click" />
                </div>
            </div>
            <%--</form>--%>
        </div>
    </div>
</asp:Content>
