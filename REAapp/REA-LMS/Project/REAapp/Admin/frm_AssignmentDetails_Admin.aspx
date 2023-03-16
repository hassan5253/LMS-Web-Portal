<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="frm_AssignmentDetails_Admin.aspx.cs" Inherits="Admin_frm_AssignmentDetails_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Admin" runat="Server">
    <div class="module">
        <div class="module-head">
            <h3>
                Assignments & Marks > Assignment Details</h3>
        </div>
        <div class="module-body">
            <div class="module-option clearfix">
                <div class="input-append pull-left">
                    <asp:TextBox class="span6" runat="server" placeholder="Enter Keywords" ID="txt_Search"></asp:TextBox>
                        <asp:DropDownList runat="server" ID="dd_Search">
                            <asp:ListItem>Student Roll No.</asp:ListItem>
                        </asp:DropDownList>
                        <asp:LinkButton ID="lnkbtn_Search" runat="server" class="btn" Text='<i class="icon-search"></i>' OnClick="lnkBtn_Search_Click"></asp:LinkButton>
                </div>
                <div class="pull-right">
                <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-primary" 
                            Text="Back" onclick="btn_Back_Click"  />
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
                            <asp:Label ID="lbl_Year" runat="server" ></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_Semester" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbl_Batch" runat="server" Text="s"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>


            <br />
            <asp:GridView ID="gv_AssDetails" runat="server" CssClass="table table-striped table-bordered table-condensed"
                    AutoGenerateColumns="False" ShowFooter="True" EmptyDataText="No record(s) found."
                    DataKeyNames="ad_id" AllowPaging="True" 
                onpageindexchanging="gv_AssDetails_PageIndexChanging">
                    <Columns>
                        
                        <asp:BoundField DataField="ad_id" HeaderText="ID" />
                        <asp:BoundField DataField="name" HeaderText="Student Name" />
                        <asp:BoundField DataField="student_roll_no" HeaderText="Student Roll No" />
                        <asp:BoundField DataField="ad_uploaded_date" HeaderText="Uploaded On" />
                        <asp:BoundField DataField="ad_marks" HeaderText="Marks" />
                        <asp:TemplateField HeaderText="Actions" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <div class="dropdown">
                                    <a class="dropdown-toggle btn" data-toggle="dropdown" href="#"><i class="icon-wrench">
                                    </i></a>
                                    <ul class="dropdown-menu pull-right open" role="menu" aria-labelledby="dLabel">
                                        <li>
                                            <asp:LinkButton ID="lnkBtn_Download" ToolTip="Edit" OnClick="lnkBtn_Download_Click" runat="server" Text='<i class="icon-download"> Download</i>'></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="lnkBtn_Marks" ToolTip="Edit" runat="server" OnClick="lnkBtn_Marks_Click" Text='<i class="icon-paste"> Marks</i>'></asp:LinkButton></li>
                                        
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
