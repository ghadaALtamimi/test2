<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="AppVoice.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 780px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h2><span class="glyphicon glyphicon-th-list"></span>&nbsp&nbsp הודעות </h2>
         <asp:Button class="btn btn-warning" ID="Button1" runat="server" OnClick="OnNewMessageButton_Click" Text="כתוב הודעה חדשה" />
         
          <asp:Table ID="Table" runat="server" class="table text-center">
                   <asp:TableRow Font-Bold="true">
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell><span class="glyphicon glyphicon-user"></span>&nbsp שם מטופל</asp:TableCell>
                    <asp:TableCell><span class="glyphicon glyphicon-envelope"></span>&nbsp הודעה</asp:TableCell>
                    <asp:TableCell><span class="glyphicon glyphicon-calendar"></span>&nbsp תאריך</asp:TableCell>
                    <asp:TableCell><span class="glyphicon glyphicon-star"></span>&nbsp פעולות</asp:TableCell>

                </asp:TableRow>
                   
                </asp:Table>

</div>
</asp:Content>
