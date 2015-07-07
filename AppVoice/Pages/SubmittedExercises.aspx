<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SubmittedExercises.aspx.cs" Inherits="AppVoice.Pages.SubmittedExercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><span class="glyphicon glyphicon-list-alt"></span>&nbsp תרגילים שהוגשו</h2>

        <table class="table text-center">
            <tr class="text-center">
                <th class="text-center"><span class="glyphicon glyphicon-info-sign"></span>&nbsp ת"ז</th>
                <th class="text-center"><span class="glyphicon glyphicon-user"></span>&nbsp שם מטופל</th>
                <th class="text-center"><span class="glyphicon glyphicon-folder-open"></span>&nbsp סוג תרגיל</th>
                <th class="text-center"><span class="glyphicon glyphicon-pencil"></span>&nbsp שם תרגיל</th>
                <th class="text-center"><span class="glyphicon glyphicon-paperclip"></span></th>
                <th class="text-center"><span class="glyphicon glyphicon-check"></span></th>
                <th class="text-center"><span class="glyphicon glyphicon-facetime-video"></span></th>


                <!--<th class="text-center"><span class="glyphicon glyphicon-phone-alt"></span>&nbsp לינק וידאו</th>-->
                <!-- <th class="text-center"><span class="glyphicon glyphicon-heart-empty"></span>&nbsp תאריך הגשה</th> -->


            </tr>
            <%foreach (AppVoice.SubmittedExercise s in submittedExercises)
              {
                  AppVoice.Patient patient = bl_patient.getPatientDetails(s.PatientId);
                  AppVoice.Exercise exercise = bl_therapist.getExerciseDetails(s.ExerciseId);
                  System.Diagnostics.Debug.WriteLine(exercise.ToString());
                  AppVoice.Folder folder = bl_therapist.getFolderDetails(exercise.FolderId);
            %>
            <tr>
                <td class="text-center"><%= s.PatientId%></td>
                <td class="text-center"><%= patient.FirstName%> <%= patient.LastName%></td>
                <td class="text-center"><%= folder.Name%></td>
                <td class="text-center"><%= exercise.Title%></td>
                <%if (!(exercise.FilePath.Equals("")) && s.IsOpenedFile == 1)
                  { %>
                <td class="text-center"><span class="glyphicon glyphicon-ok"></span></td>
                <%}
                  else if (exercise.FilePath.Equals(""))
                  {%>
                <td class="text-center"></td>
                <%}
                  else
                  {%>
                <td class="text-center"><span class="glyphicon glyphicon-option-horizontal"></span></td>
                <%}
                  if (s.IsDone == 1)
                  { %>
                <td class="text-center"><span class="glyphicon glyphicon-ok"></span></td>
                <%}
                  else
                  {%>
                <td class="text-center"><span class="glyphicon glyphicon-option-horizontal"></span></td>
                <%} %>
                <%if(!exercise.IsVideo)
                  { %>
                <td class="text-center"></td>
                <%} %>
                <%else if (!s.VideoPath.Equals(""))
                  { %>
                <td>
                    <a href="https://www.dropbox.com/home/Applications/AppVoice?preview=<%=s.VideoPath %>"><%=s.VideoPath %> </a></td>
                <%}else
                  { %>
                 <td class="text-center"><span class="glyphicon glyphicon-option-horizontal"></span></td>
                <%} %>
                <td><a style="color:grey;" class='btn' onclick="return confirm('האם אתה רוצה למחוק תרגיל זה?');" href="/Pages/SubmittedExercises.aspx?deletedId=<%=s.Id %>&patientId=<%=s.PatientId %>&exerciseId=<%=s.ExerciseId %>"><span class="glyphicon glyphicon-remove"></span></a></td>
            </tr>
            <%} %>
        </table>

    </div>
</asp:Content>
