<%@ Page Title="" Language="C#" MasterPageFile="~/Students/Students.master" AutoEventWireup="true"
    CodeFile="frm_AssignmentDetails_Std.aspx.cs" Inherits="Students_frm_AssignmentDetails_Std" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Students" runat="Server">
    <div class="module">
        <div class="module-head">
            <h3>
                Assignment & Marks > Assignment Details</h3>
        </div>
        <div class="module-body">
            <div class="module-option clearfix">
                <div class="pull-right">
                    <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btn_Back_Click" />
                </div>
            </div>
            <br />
       <div id="divmsg" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <strong>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
            </div>
            
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
                                <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-large btn-success" Text="Save"
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

         
            <%--<form class="form-horizontal row-fluid">--%>
            <%--</form>--%>
            <br />
            <asp:GridView ID="gv_AssDetails" runat="server" CssClass="table table-striped table-bordered table-condensed"
                AutoGenerateColumns="False" ShowFooter="True" EmptyDataText="No record(s) found."
                DataKeyNames="ad_id" AllowPaging="True" OnPageIndexChanging="gv_AssDetails_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="cb_Header" runat="server" OnCheckedChanged="cb_Header_CheckedChanged" AutoPostBack="true" />
                        </HeaderTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkBtn_DeleteAll" OnClick="lnkBtn_DeleteAll_Click" runat="server"
                                CssClass="btn btn-small btn-danger item_purge" Text="<i class='btn-icon-only icon-remove-sign'></i>"
                                ToolTip="Delete"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_Middle" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ad_id" HeaderText="ID" />
                    <asp:BoundField DataField="name" HeaderText="Student Name" />
                    <asp:BoundField DataField="student_roll_no" HeaderText="Student RollNo" />
                    <asp:BoundField DataField="ad_uploaded_date" HeaderText="Uploaded On" />
                    <asp:BoundField DataField="ad_marks" HeaderText="Marks" />
                    <asp:TemplateField HeaderText="Actions" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <div class="dropdown">
                                <a class="dropdown-toggle btn" data-toggle="dropdown" href="#"><i class="icon-wrench">
                                </i></a>
                                <ul class="dropdown-menu pull-right open" role="menu" aria-labelledby="dLabel">
                                    <li>
                                        <asp:LinkButton ID="lnkBtn_View" OnClick="lnkBtn_View_Click" ToolTip="Edit" runat="server"
                                            Text='<i class="icon-search"> View</i>'></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnkBtn_Edit" ToolTip="Edit" runat="server" OnClick="lnkBtn_Edit_Click"
                                            Text='<i class="icon-edit"> Edit</i>'></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnkBtn_ViewMarks" ToolTip="Edit" OnClick="lnkBtn_ViewMarks_Click"
                                            runat="server" Text='<i class="icon-paste"> View Marks</i>'></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnkBtn_Delete" OnClick="lnkBtn_Delete_Click" ToolTip="Edit" runat="server"
                                            Text='<i class="icon-trash"> Delete</i>'></asp:LinkButton></li>
                                </ul>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="50px"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:HiddenField ID="hf_AID" runat="server" />
</asp:Content>
