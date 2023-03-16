<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="frm_AssignmentMarks_Admin.aspx.cs" Inherits="Admin_frm_AssignmentMarks_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Admin" runat="Server">
<head>
<script type="text/javascript">

    function Decimal(evt) {
        if (!(evt.keyCode == 46 || (evt.keyCode >= 48 && evt.keyCode <= 57)))
            return false;
        var parts = evt.srcElement.value.split('.');
        if (parts.length > 2) return false;

        if (evt.keyCode == 46) return (parts.length == 1);

        if (parts[0].length >= 14) return false;

        if (parts.length == 2 && parts[1].length >= 2) return false;
    }

</script>

</head>

    <div class="module">
        <div class="module-head">
            <h3>
                Assignments & Marks > Enter Marks</h3>
        </div>
        <div class="module-body">
            <div class="module-option clearfix">
                <div class="pull-right">
                    <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-success" 
                            Text="Back" onclick="btn_Back_Click"  />
                </div>
            </div>
            <br />
            <table class="table table-striped table-bordered table-condensed">
                <thead ">
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
            <div id="divmsg" runat="server">
                <button type="button" class="close" data-dismiss="alert">
                    &times;</button>
                <strong>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
            </div>
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
                    <asp:TextBox ID="txt_StdName" ReadOnly="true" runat="server" CssClass="span6"></asp:TextBox>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="basicinput">
                    Assignment Name</label>
                <div class="controls">
                    <asp:TextBox ID="txt_AssName" runat="server" ReadOnly="true" CssClass="span6"></asp:TextBox>
                    
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="basicinput">
                    Enter Marks</label>
                <div class="controls">
                    <asp:TextBox ID="txt_AssMarks" runat="server" CssClass="span6" ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\d+" ControlToValidate="txt_AssMarks" ForeColor="Red" ErrorMessage="*"></asp:RegularExpressionValidator>
                    
                </div>
            </div>
            <div class="control-group">
                <div class="controls">
                    <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-large btn-success" Text="Save"
                        OnClick="btn_Save_Click" />
                </div>
            </div>
<%--            </form>--%>
        </div>
    </div>
    <asp:HiddenField ID="hf_ADID" runat="server" />
        <asp:HiddenField ID="hf_AID" runat="server" />
</asp:Content>
