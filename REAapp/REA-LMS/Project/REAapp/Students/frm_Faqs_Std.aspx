<%@ Page Title="" Language="C#" MasterPageFile="~/Students/Students.master" AutoEventWireup="true"
    CodeFile="frm_Faqs_Std.aspx.cs" Inherits="Students_frm_Faqs_Std" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Students" runat="Server">
    <div class="module">
        <div class="module-head">
            <h3>
                FAQs
            </h3>
        </div>
        <div class="module-body">
            
                
                <div class="media-body">
                    <div id="divmsg" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            &times;</button>
                        <strong>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                    </div>
                
            
            <div class="stream-list">
                <div class="media stream new-update">
                    <%--<a href="#"><i class="icon-refresh shaded"></i>11 updates </a>--%>
                </div>
                <div class="media stream">
                    <asp:Repeater ID="rpt_Parent" runat="server">
                        <ItemTemplate>
                            <a href="#" class="media-avatar medium pull-left">
                                <img src="../images/Faqs.png" >
                                
                            </a>
                            <div class="media-body">
                                <asp:Label ID="lbl_F_PID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "f_id") %>'
                                    Visible="false"></asp:Label>
                                <div class="stream-headline">
                                    <h5 class="stream-author">
                                        <%#Eval("f_description")%>
                                        
                                    </h5>
                                    <asp:Repeater ID="rpt_Child" runat="server">
                                        <ItemTemplate>
                                            <div class="stream-text">
                                                <%#Eval("f_description")%>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!--/.stream-headline-->
                                <div class="stream-options">
                                <a href="#" class="btn btn-small">
													<i class="icon-thumbs-up shaded"></i>
													Like
												</a>
                                    
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <!--/.media .stream-->
                <div class="media stream load-more">
<%--                    <a href="#"><i class="icon-refresh shaded"></i>show more... </a>--%>
                </div>
            </div>
            <!--/.stream-list-->
        </div>
        <!--/.module-body-->
    </div>
    <!--/.module-->
</asp:Content>
