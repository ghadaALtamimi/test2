﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SubmittedExercises.aspx.cs" Inherits="AppVoice.Pages.SubmittedExercises" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><span class="glyphicon glyphicon-user"></span>&nbsp תרגילים שהוגשו</h2>

        <table class="table text-center">
            <tr class="text-center">
                <th class="text-center"><span class="glyphicon glyphicon-info-sign"></span>&nbsp ת"ז</th>
                <th class="text-center"><span class="glyphicon glyphicon-user"></span>&nbsp שם מטופל</th>
                <th class="text-center"><span class="glyphicon glyphicon-envelope"></span>&nbsp סוג תרגיל</th>
                <th class="text-center"><span class="glyphicon glyphicon-map-marker"></span>&nbsp שם תרגיל</th>
                <!--<th class="text-center"><span class="glyphicon glyphicon-phone-alt"></span>&nbsp לינק וידאו</th>-->
               <!-- <th class="text-center"><span class="glyphicon glyphicon-heart-empty"></span>&nbsp תאריך הגשה</th> -->

                
            </tr>
            <%foreach(AppVoice.SubmittedExercise s in submittedExercises)
              {
                  AppVoice.Patient patient = bl_patient.getPatientDetails(s.PatientId);
                  AppVoice.Exercise exercise = bl_therapist.getExerciseDetails(s.ExerciseId);
                  AppVoice.Folder folder = bl_therapist.getFolderDetails(exercise.FolderId);
                   %>
            <tr>
                <td class="text-center"><%= s.PatientId%></td>
                <td class="text-center"><%= patient.FirstName%> <%= patient.LastName%></td>
                <td class="text-center"><%= folder.Name%></td>
                <td class="text-center"><%= exercise.Title%></td>
                
            </tr>
            <%} %>
        </table>

    </div>
</asp:Content>
