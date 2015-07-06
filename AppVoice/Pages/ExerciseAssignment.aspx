<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ExerciseAssignment.aspx.cs" Inherits="AppVoice.ExerciseAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><span class="glyphicon glyphicon-th-list"></span>&nbsp&nbsp שיבוץ תרגילים </h2>

        <!-- Patient Panel -->
        <asp:Panel runat="server" ID="PanelFromPatient">
            <h3>
                <asp:Label runat="server" ID="PatientNameLabel"></asp:Label></h3>
            <!-- <asp:checkboxlist style="align-items:inherit" runat="server" ID="CheckBoxList"></asp:checkboxlist> -->
            <table class="table text-center">
                <tr class="text-center">
                    <th class="text-center"><span class="glyphicon glyphicon-ok-circle"></span></th>
                    <th class="text-center"><span class="glyphicon glyphicon-user"></span>&nbsp שם תרגיל</th>
                    <th class="text-center"><span class="glyphicon glyphicon-envelope"></span>&nbsp סוג תרגיל</th>
                    <th class="text-center"><span class="glyphicon glyphicon-star"></span>&nbsp פעולות</th>
                </tr>

                <%foreach (AppVoice.Exercise e in allExercises)
                  {
                      string folderName = bl_therapist.getFolderNameByFolderId(e.FolderId, therapistId);
                      string exerciseName = e.Title;
                %>

                <tr>

                    <td>
                        <asp:CheckBox runat="server" /></td>

                    <td><%= exerciseName%></td>
                    <td><%= folderName%></td>

                    <td>
                        <a href="/Pages/Exercise.aspx?id=<%=e.Id %>&exercise=<%=e.Title %>">
                            <p class="btn btn-info">הצג</p>
                        </a>
                        <a href="/Pages/AssignedExercises.aspx?patientId=<%= patientId%>&exerciseId=<%=e.Id %>">
                            <p class="btn btn-warning">שבץ תרגיל</p>

                        </a>

                    </td>

                </tr>
                <%} %>
            </table>
        </asp:Panel>


        <!-- Exercise Panel -->
        <asp:Panel runat="server" ID="PanelFromExercise">
            <asp:CheckBoxList ID="CheckBoxList1" CssClass="top-buffer list-group" runat="server">


            </asp:CheckBoxList>           
        </asp:Panel>

        <asp:Button runat="server" class="btn btn-primary" OnClick="OnAddAllExercises_Click" Text="שבץ תרגילים מסומנים" />
    </div>

</asp:Content>
