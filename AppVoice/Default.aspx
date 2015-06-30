<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppVoice.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron text-center">
        <h1>ברוכים הבאים ל- appVoice</h1>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>

    <div class="col-md-offset-4 col-md-4">
        <div class="panel panel-default">
            <div class="panel-heading text-center"><b>משתמש קיים</b></div>
            <div class="panel-body">
                <div class="col-md-offset-1 col-md-10">

                    <!-- Id liscence area -->
                    <div class="input-group form-group" style="direction: ltr;">
                        <asp:TextBox ID="IdTextBox" class="form-control" runat="server" placeholder="מספר רשיון..." style="direction: rtl;"></asp:TextBox>
                        <span class="input-group-addon glyphicon glyphicon-user" style="top: 0;"></span>
                    </div>
                    <!-- Id Error Panel -->
                    <asp:Panel ID="IdPanelError" Visible="false" runat="server">
                        <div class="alert alert-warning" role="alert" id="IdLabelWarning">
                            <asp:Label CssClass="errorMessage" ID="IdLabelError" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>

                    <!-- Password area -->
                    <div class="input-group form-group"  style="direction: ltr;">
                        <asp:TextBox ID="PwdTextBox" class="form-control" TextMode="password" runat="server" placeholder="סיסמה..."  style="direction: rtl;"></asp:TextBox>
                        <span class="input-group-addon glyphicon glyphicon-asterisk"  style="top: 0;"></span>
                    </div>
                    <!-- Password Error Panel -->
                    <asp:Panel runat="server" ID="PwdPanelError" Visible="false">
                         <div class="alert alert-warning" role="alert" id="PwdLabelWarning">
                            <asp:Label CssClass="errorMessage" ID="PwdLabelError" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>

                    <div class="text-center">
                        <!-- Login Button -->
                        <asp:Button ID="LoginBtn" class="btn-lg button-color" Style="text-align: center" runat="server" OnClick="ButtonLogin_Click" Text="התחבר למערכת" />
                        <!-- New User Button -->
                        <asp:Button ID="NewUserButton" class="btn btn-link" runat="server" OnClick="NewUser_Click" Text="משתמש חדש?" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
