<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignedExercises.aspx.cs" Inherits="AppVoice.AssignedExercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><span class="glyphicon glyphicon-th-list"></span>&nbsp&nbsp תרגילים משובצים </h2>

        <table class="table text-center">
            <tr class="text-center">
                <th class="text-center"><span class="glyphicon glyphicon-pencil"></span>&nbsp שם תרגיל</th>
                <th class="text-center"><span class="glyphicon glyphicon-folder-open"></span>&nbsp סוג תרגיל</th>
                <th class="text-center"><span class="glyphicon glyphicon-user"></span>&nbsp שם מטופל </th>
            </tr>

            <%
                if (allAssignedExercises.Count > 0)
                {
                    foreach (AppVoice.AssignedExercise e in allAssignedExercises)
                    {
                        AppVoice.Exercise exercise = bl_therapist.getExerciseDetails(e.ExerciseId);
                        AppVoice.Patient patient = bl_patient.getPatientDetails(e.PatientId);
                        string folderName = bl_therapist.getFolderNameByFolderId(e.FolderId, therapistId);
            %>
            <tr>
                <td><%= exercise.Title %></td>
                <td><%= folderName%></td>
                <td><%= patient.FirstName%> <%=patient.LastName %></td>


            </tr>
            <%}
                } %>
        </table>


    </div>
</asp:Content>
