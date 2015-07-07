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
                <%if(exercise.ImagePath.Equals(""))
                  { %>
                <td></td>
                <%} 
                  else
                  {%>
                <td><span class="glyphicon glyphicon-picture"></span></td>
                <%}%>
                 <%if(exercise.FilePath.Equals(""))
                  { %>
                <td></td>
                <%} 
                  else
                  {%>
                <td><span class="glyphicon glyphicon-paperclip"></span></td>
                <%}%>
                 <%if(!exercise.IsVideo)
                  { %>
                <td></td>
                <%} 
                  else
                  {%>
                <td><span class="glyphicon glyphicon-facetime-video"></span></td>
                <%}%>
                 <%if(bl_therapist.isSubmittedExerciseExists(e.PatientId+"", e.ExerciseId+""))
                  { %>
                <td><a  id="popoverData" data-content="לא ניתן למחוק תרגיל זה מכיוון שהוא נמצא בתרגילים שהוגשו. " data-direction="rtl" rel="popover" href="#" class="btn" data-placement="bottom" data-original-title="לא ניתן למחוק" data-trigger="hover"><span style="color:grey;" class="glyphicon glyphicon-remove"></span></a></td>
                <%} 
                  else
                  {%>
                <td><a style="color:black;" class='btn' onclick="return confirm('האם אתה רוצה למחוק תרגיל זה?');" href="/Pages/AssignedExercises.aspx?deletedId=<%=e.Id %>"><span class="glyphicon glyphicon-remove"></span></a></td>
                <%}%>
                
            </tr>
            <%}
                } %>
            <script src="/Scripts/deleteScripts.js"></script>
        </table>


    </div>
            

</asp:Content>
