<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AllExercises.aspx.cs" Inherits="AppVoice.Exercises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <asp:Panel runat="server" ID="TitlePanel">
            <h2><span class="glyphicon glyphicon-folder-open"></span>
                &nbsp&nbsp
                <asp:Label runat="server" ID="FolderNameLabel"></asp:Label>
                &nbsp&nbsp
            <asp:LinkButton class="btn btn-warning" ID="AddDescriptionButton" OnClick="OnAddFolderDescription_Click" runat="server"><span class="glyphicon glyphicon-plus"></span>&nbsp הוסף תיאור תיקייה</asp:LinkButton>
                <asp:LinkButton class="btn btn-warning" ID="EditDescriptionButton" OnClick="OnEditFolderDescription_Click" runat="server"><span class="glyphicon glyphicon-wrench"></span>&nbsp עדכן תיאור תיקייה</asp:LinkButton>
                <asp:LinkButton class="btn btn-success" ID="SaveDescriptionButton" OnClick="OnSaveFolderDescription_Click" Visible="false" runat="server"><span class="glyphicon glyphicon-wrench"></span>&nbsp שמור שינויים</asp:LinkButton>
            </h2>
            <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="DescriptionTextBox"></asp:TextBox>
            <asp:Label runat="server" ID="DescriptionLabel"></asp:Label>
        </asp:Panel>

        <h3><span class="glyphicon glyphicon-list-alt"></span>&nbsp רשימת תרגילים&nbsp &nbsp
          <asp:LinkButton class="btn btn-warning" OnClick="OnAddExercise_Click" runat="server"><span class="glyphicon glyphicon-plus"></span>&nbsp הוסף תרגיל</asp:LinkButton></h3>

        <table class="table text-center">
            <tr class="text-center">
                <th class="text-center"></th>
                <th class="text-center"><span class="glyphicon glyphicon-user"></span>&nbsp שם תרגיל</th>
                <th class="text-center"><span class="glyphicon glyphicon-envelope"></span>&nbsp סוג תרגיל</th>
            </tr>

            <%foreach (AppVoice.Exercise e in allExercises)
              {
                  string folderName1 = bl_therapist.getFolderNameByFolderId(e.FolderId, therapistId);
            %>
            <tr>
                <%if (e.IsVideo)
                  {%>
                <td><span class="glyphicon glyphicon-facetime-video"></span></td>
                <% }
                  else
                  {%>
                <td></td>
                <%} %>
                <td><%= e.Title %></td>
                <td><%= folderName1%></td>
                <td>
                    <a href="/Pages/Exercise.aspx?id=<%=e.Id %>&exercise=<%=e.Title %>">
                        <p class="btn btn-info">הצג</p>
                    </a>
                    <a href="/Pages/ExerciseAssignment.aspx?exerciseId=<%=e.Id %>">
                        <p class="btn btn-warning">שבץ תרגיל</p>
                    </a>

                </td>

            </tr>
            <%} %>
        </table>
    </div>

    <!-- pop up login -->
    <div class="modal fade deleteOldModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">האם אתה בטוח?</h4>
                </div>
                <div class="modal-body text-center">
                    <div class="form-group">
                        האם ברצונך למחוק תרגיל זה? 
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>

                        <asp:Button ID="YesButtonPopup" class="btn btn-danger" runat="server" Text="מחק תרגיל זה" />
                    </div>

                </div>



            </div>
        </div>
    </div>
</asp:Content>
