<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true"
    CodeFile="frm_AssignmentsMarks_Staff.aspx.cs" Inherits="Staff_frm_AssignmentsMarks_Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Staff" runat="Server">
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
                        <asp:TextBox runat="server" placeholder="Enter Roll No" ID="txt_Search"></asp:TextBox>
                        <asp:LinkButton ID="lnkbtn_Search" runat="server" class="btn" Text='<i class="icon-search"></i>'
                            OnClick="lnkBtn_Search_Click"></asp:LinkButton>
                    </div>
                    <div class="pull-right">
                        <asp:Button ID="btn_CNR" runat="server" CssClass="btn btn-primary" Text="Create New Record"
                            OnClick="btn_CNR_Click" />
                    </div>
                </div>
                <br />
                <div id="divmsg" runat="server">
                    <button type="button" class="close" data-dismiss="alert">
                        &times;</button>
                    <strong>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                </div>
                <asp:GridView ID="gv_Assignments" runat="server" CssClass="table table-striped table-bordered table-condensed"
                    AutoGenerateColumns="False" ShowFooter="True" EmptyDataText="No record(s) found."
                    DataKeyNames="a_id" AllowPaging="True" 
                    onpageindexchanging="gv_Assignments_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="cb_Header" runat="server" />
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
                                            <asp:LinkButton ID="lnkBtn_View" ToolTip="Edit" OnClick="lnkBtn_View_Click" runat="server"
                                                Text='<i class="icon-search"> View</i>'></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="lnkBtn_Edit" ToolTip="Edit" runat="server" OnClick="lnkBtn_Edit_Click"
                                                Text='<i class="icon-edit"> Edit</i>'></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="lnkBtn_ViewDetails" runat="server" OnClick="lnkBtn_ViewDetails_Click"
                                                Text='<i class="icon-book"> View Details</i>'></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="lnktBtn_Delete" OnClick="lnkBtn_Delete_Click" ToolTip="Delete"
                                                Text='<i class="icon-trash"> Delete</i>' OnClientClick="return ConfirmDelete();"
                                                runat="server"></asp:LinkButton></li>
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
