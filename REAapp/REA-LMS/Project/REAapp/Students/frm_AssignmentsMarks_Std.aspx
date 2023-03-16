<%@ Page Title="" Language="C#" MasterPageFile="~/Students/Students.master" AutoEventWireup="true"
    CodeFile="frm_AssignmentsMarks_Std.aspx.cs" Inherits="Students_frm_AssignmentsMarks_Std" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Students" runat="Server">
    <head>
    </head>
    <body>
        <div class="module">
            <div class="module-head">
                <h3>
                    Assignments & Marks > Assignment Marks</h3>
            </div>
            <div class="module-body">
                <div class="module-option clearfix">
                    <div class="input-append pull-left">
                        <asp:TextBox  runat="server" placeholder="Enter Roll No" ID="txt_Search"></asp:TextBox>
                        <asp:LinkButton ID="lnkbtn_Search" runat="server" class="btn" Text='<i class="icon-search"></i>' OnClick="lnkBtn_Search_Click"></asp:LinkButton>
                    </div>
                </div>
                <asp:GridView ID="gv_Assignments" runat="server" CssClass="table table-striped table-bordered table-condensed"
                    AutoGenerateColumns="False" ShowFooter="True" EmptyDataText="No record(s) found."
                    DataKeyNames="a_id" AllowPaging="True" 
                    onpageindexchanging="gv_Assignments_PageIndexChanging">
                    <Columns>
                        
                        <asp:BoundField DataField="a_id" HeaderText="ID" />
                        <asp:BoundField DataField="a_name" HeaderText="NAME" />
                        <asp:BoundField DataField="a_assigned_by" HeaderText="Assigned By" />
                        <asp:BoundField DataField="a_assigned_date" HeaderText="Assigned Date" />
                        <asp:BoundField DataField="a_submit_date" HeaderText="Sumit Date" />
                        <asp:TemplateField HeaderText="Actions" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <div class="dropdown">
                                    <a class="dropdown-toggle btn" data-toggle="dropdown" href="#"><i class="icon-wrench">
                                    </i></a>
                                    <ul class="dropdown-menu pull-right open" role="menu" aria-labelledby="dLabel">
                                        <li>
                                            <asp:LinkButton ID="lnkBtn_Download" OnClick="lnkBtn_Download_Click" ToolTip="Edit" runat="server" Text='<i class="icon-download"> Download</i>'></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="lnkBtn_ViewDetails" OnClick="lnkBtn_ViewDetails_Click" ToolTip="Edit" runat="server" Text='<i class="icon-book"> View Details</i>'></asp:LinkButton></li>
                                    </ul>
                                </div>
                            </ItemTemplate>
                            <ItemStyle Width="50px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </body>
</asp:Content>
