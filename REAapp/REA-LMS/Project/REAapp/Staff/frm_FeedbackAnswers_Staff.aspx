<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true"
    CodeFile="frm_FeedbackAnswers_Staff.aspx.cs" Inherits="Staff_frm_FeedbackAnswers_Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Staff" runat="Server">
    <div class="module">
        <div class="module-head">
            <h3>
                Feedback & Queries > Answer</h3>
        </div>
        <div class="module-body">
            <div class="module-option clearfix">
                <div class="pull-right">
                    <asp:Button ID="btn_Back" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btn_Back_Click" />
                </div>
            </div>
            <div class="stream-composer media">
                <a href="#" class="media-avatar medium pull-left">
                    <img src="../images/users/Faculty.png">
                </a>
                <div class="media-body">
                    <div id="divmsg" runat="server">
                        <button type="button" class="close" data-dismiss="alert">
                            &times;</button>
                        <strong>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label></strong>
                    </div>
                    <div class="row-fluid">
                        <asp:TextBox ID="txt_Answer" TextMode="MultiLine" runat="server" class="span12" Rows="4"></asp:TextBox>
                    </div>
                    <div class="clearfix">
                        <asp:Button ID="btn_Save" runat="server" CssClass="btn btn-success pull-right" Text="Answer"
                            OnClick="btn_Save_Click" />
                    </div>
                </div>
            </div>
            <!--/.stream-list-->
        </div>
        <!--/.module-body-->
    </div>
    <!--/.module-->
</asp:Content>
