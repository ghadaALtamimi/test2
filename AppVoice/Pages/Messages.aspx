<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="AppVoice.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 916px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <h2><span class="glyphicon glyphicon-th-list"></span>&nbsp&nbsp הודעות </h2>
         <asp:Button class="btn btn-warning" ID="Button1" runat="server" OnClick="OnNewMessageButton_Click" Text="כתוב הודעה חדשה" />
         <table class="table text-center top-buffer">
            <tr class="text-center">
                <th class="text-center"><span class="glyphicon glyphicon-user"></span>&nbsp שם מטופל</th>
                <th class="auto-style1"><span class="glyphicon glyphicon-envelope"></span>&nbsp הודעה</th>
                <th class="text-center"><span class="glyphicon glyphicon-asterisk"></span>&nbsp פעולות</th>
                <!--<th class="text-center"><span class="glyphicon glyphicon-phone-alt"></span>&nbsp לינק וידאו</th>-->
               <!-- <th class="text-center"><span class="glyphicon glyphicon-heart-empty"></span>&nbsp תאריך הגשה</th> -->

                
            </tr>
            <%foreach(AppVoice.Message m in messages)
              {
                  AppVoice.Patient patient = bl_patient.getPatientDetails(m.MessageFrom);
                  
                  
                   %>
            <tr>
                
                <td class="text-center"><%= patient.FirstName%> <%= patient.LastName%></td>
                <td class="auto-style1"><%= m.MessageText%></td>
                <td class="text-center">
                    <asp:Button class="btn btn-success" ID="RegButton" runat="server" Text="הגב" />
                </td>
                
            </tr>
            <%} %>
        </table>

</div>
</asp:Content>
