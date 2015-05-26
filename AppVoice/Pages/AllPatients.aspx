<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AllPatients.aspx.cs" Inherits="AppVoice.Pages.AllPatients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><span class="glyphicon glyphicon-user"></span>&nbsp רשימת מטופלים</h2>

        <table class="table text-center">
            <tr class="text-center">
                <th class="text-center"><span class="glyphicon glyphicon-info-sign"></span>&nbsp ת"ז</th>
                <th class="text-center"><span class="glyphicon glyphicon-user"></span>&nbsp שם מטופל</th>
                <th class="text-center"><span class="glyphicon glyphicon-envelope"></span>&nbsp מייל</th>
                <th class="text-center"><span class="glyphicon glyphicon-map-marker"></span>&nbsp כתובת</th>
                <th class="text-center"><span class="glyphicon glyphicon-phone-alt"></span>&nbsp טלפון</th>
                <th class="text-center"><span class="glyphicon glyphicon-heart-empty"></span>&nbsp קופת חולים</th>
                <th class="text-center"><span class="glyphicon glyphicon-asterisk"></span>&nbsp סיסמה</th>
                <th class="text-center"><span class="glyphicon glyphicon-star"></span>&nbsp פעולות</th>
            </tr>

            <%foreach (AppVoice.Patient p in allPatients)
              {
                   
            %>
            <tr>
                <td><%= p.PatientId %></td>
                <td><%= p.FirstName + " " + p.LastName %></td>
                <td><%= p.Mail %></td>
                <td><%= p.Address %></td>
                <td><%= p.PhoneNumber %></td>
                <td><%= p.Hmo %></td>
                <td><%= p.Password %></td>
                <td>
                    <a href="/Pages/PatientAccount.aspx?patient=<%=p.PatientId %>">
                        <p class="btn btn-info">הצג</p>
                    </a>
                    <a href="/Pages/ExerciseAssignment.aspx?patientId=<%=p.PatientId %>">
                        <p class="btn btn-warning">שבץ תרגילים</p>
                    </a>
                   
                </td>

            </tr>
            <%} %>
        </table>
    </div>
</asp:Content>
