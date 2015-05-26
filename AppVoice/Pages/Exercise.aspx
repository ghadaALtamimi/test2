<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exercise.aspx.cs" Inherits="AppVoice.Exercise1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><span class="glyphicon glyphicon-file"></span>&nbsp&nbsp<asp:Label runat="server" ID="ExerciseNameLabel"></asp:Label></h2>
        <h4><span class="glyphicon glyphicon-folder-open"></span>&nbsp&nbsp<asp:Label runat="server" ID="FolderNameLabel"></asp:Label></h4>


        <div class="col-md-8 col-md-offset-4 " style="font-size: large">

            <!-- Exercise Description -->
            <span class="glyphicon glyphicon-info-sign"></span>&nbsp תיאור התרגיל:   &nbsp&nbsp
            <asp:Label ID="ExerciseDescriptionLabel" runat="server"></asp:Label>

            <asp:LinkButton class="btn btn-warning" ID="AddDescriptionButton" OnClick="OnAddExerciseDescription_Click" runat="server"><span class="glyphicon glyphicon-plus"></span>&nbsp הוסף תיאור תרגיל</asp:LinkButton>
            <asp:LinkButton class="btn btn-warning" ID="EditDescriptionButton" OnClick="OnEditExerciseDescription_Click" runat="server"><span class="glyphicon glyphicon-wrench"></span>&nbsp עדכן תיאור תיקייה</asp:LinkButton>
            <asp:LinkButton class="btn btn-success" ID="SaveDescriptionButton" OnClick="OnSaveExerciseDescription_Click" Visible="false" runat="server"><span class="glyphicon glyphicon-wrench"></span>&nbsp שמור שינויים</asp:LinkButton>
            <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="DescriptionTextBox"></asp:TextBox>
            <asp:Label runat="server" ID="DescriptionLabel"></asp:Label>
        </div>
        <h3><span class="glyphicon glyphicon-list-alt top-buffer"></span>&nbsp רשימת משימות&nbsp &nbsp
          <asp:LinkButton class="btn btn-warning" OnClick="OnAddTask_Click" runat="server"><span class="glyphicon glyphicon-plus"></span>&nbsp הוסף משימה</asp:LinkButton></h3>

        <table class="table text-right">
            <tr>
                <th class="text-right"><span class="glyphicon glyphicon-user"></span>&nbsp כותרת משימה</th>
            </tr>

            <%foreach (AppVoice.Task t in allTasks)
              {
            %>
            <tr>
                <td><%= t.Title %></td>
            </tr>
            <%} %>
        </table>

        <asp:Panel runat="server" ID="AddTaskPanel" Visible=" false">
            <div class="col-md-6 col-md-offset-6">
                <ul class="list-unstyled form-group">
                    <li class="row">

                        <span class="glyphicon glyphicon-info-sign"></span>&nbsp כותרת המשימה                
                                <asp:TextBox class="form-control" ID="TaskTitleTextBox" runat="server"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="TaskTitleLabelError" CssClass="errorMessage" Visible="false" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                        </div>
                    </li>

                    <li class="row">
                        <span class="glyphicon glyphicon-user"></span>&nbsp תיאור המשימה                
                                <asp:TextBox class="form-control" TextMode="MultiLine" ID="TaskDescriptionTextBox" runat="server"></asp:TextBox>
                    </li>

                    <li class="row top-buffer">
                        <span class="glyphicon glyphicon-user"></span>&nbsp הוספת קובץ
                        <asp:FileUpload ID="FileUploadUrl" CssClass="top-buffer" runat="server" Height="25px" />
                       
                    </li>

                    <li class="row top-buffer">
                        <span class="glyphicon glyphicon-envelope"></span>&nbsp הערות
                            <asp:TextBox Class="form-control" ID="CommentTextBox" TextMode="MultiLine" runat="server"></asp:TextBox>
                        
                    </li>

                </ul>
            </div>
            <div class="text-center">
                <asp:Button class="btn btn-success" ID="RegButton" runat="server" OnClick="OnSaveButton_Click" Text="הוסף משימה" />

                <asp:Button class="btn btn-default" runat="server" OnClick="OnCancelButton_Click" Text="ביטול" />
            </div>
        </asp:Panel>
        <asp:Button type="button" class="btn btn-danger top-buffer" ID="DeleteButton" runat="server" Text="מחק תרגיל"></asp:Button>
    </div>


</asp:Content>
