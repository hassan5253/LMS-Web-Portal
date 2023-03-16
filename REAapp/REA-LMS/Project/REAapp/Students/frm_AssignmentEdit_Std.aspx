<%@ Page Title="" Language="C#" MasterPageFile="~/Students/Students.master" AutoEventWireup="true"
    CodeFile="frm_AssignmentEdit_Std.aspx.cs" Inherits="Students_frm_AssignmentEdit_Std" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Students" runat="Server">
    <div class="module">
        <div class="module-head">
            <h3>
                Assignment & Marks > Edit Assignment</h3>
        </div>
        <div class="module-body">
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
            
            
           <table class="table table-striped table-bordered table-condensed">
                <tr>
                    <td colspan="2">
                        <p style="text-align: center;">
                            <strong>Upload new Assignment</strong> <small></small>
                        </p>
                    </td>
                    <td colspan="2">
                        <div class="control-group">
                            <label class="control-label" for="basicinput">
                                Upload File</label>
                            <div class="controls">
                                <asp:FileUpload runat="server" ID="fu_AssFile" />
                                <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-large btn-success" Text="Update"
                                    OnClick="btn_Save_Click" />
                            </div>
                        </div>
                        <%--<div class="control-group">--%>
                        <%--    <div class="controls">--%>
                        <%--</div>--%>
                        <%--</div>--%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="hf_ADID" runat="server" />
            <asp:HiddenField ID="hf_AID" runat="server" />
</asp:Content>
