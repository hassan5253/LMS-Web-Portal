<%@ Page Title="" Language="C#" MasterPageFile="~/Students/Students.master" AutoEventWireup="true"
    CodeFile="frm_AssignmentMarks_Std.aspx.cs" Inherits="Students_frm_AssignmentMarks_Std" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Students" runat="Server">
    <div class="module">
        <div class="module-head">
            <h3>
                Assignments & Marks > Assignment Marks</h3>
        </div>
        <div class="module-body">
            <div class="module-option clearfix">
                <div class="pull-right">
                    <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btn_Back_Click" />
                </div>
            </div>
            <br />
            <table class="table table-striped table-bordered table-condensed">
                <thead>
                    <tr>
                        <th>
                            Course Name
                        </th>
                        <th>
                            Year
                        </th>
                        <th>
                            Semester
                        </th>
                        <th>
                            Batch
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_Course" runat="server" Text="s"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_Year" runat="server" Text="s"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_Semester" runat="server" Text="s"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_Batch" runat="server" Text="s"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
        
            <%--            <form class="form-horizontal row-fluid">--%>
            <div class="control-group">
                <label class="control-label" for="basicinput">
                    Student Roll No</label>
                <div class="controls">
                    <asp:TextBox ID="txt_StdRollNo" ReadOnly="true" runat="server" CssClass="span6"></asp:TextBox>
                    
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="basicinput">
                    Student Name</label>
                <div class="controls">
                    <asp:TextBox ID="txt_StdName" runat="server" CssClass="span6" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="basicinput">
                    Assignment Name</label>
                <div class="controls">
                    <asp:TextBox ID="txt_AssName" runat="server" CssClass="span6" ReadOnly="true"></asp:TextBox>
                    
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="basicinput">
                    Your Marks</label>
                <div class="controls">
                    <asp:TextBox ID="txt_AssMarks" runat="server" CssClass="span6" ReadOnly="true"></asp:TextBox>
                    
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hf_ADID" runat="server" />
        <asp:HiddenField ID="hf_AID" runat="server" />
</asp:Content>
