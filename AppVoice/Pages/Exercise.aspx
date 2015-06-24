<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exercise.aspx.cs" Inherits="AppVoice.Exercise1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="col-md-6 col-md-offset-6">
            <h2><span class="glyphicon glyphicon-file"></span>&nbsp&nbsp<asp:Label runat="server" ID="ExerciseNameLabel"></asp:Label></h2>
            <asp:TextBox CssClass="form-control" ID="ExerciseNameTextBox" runat="server"></asp:TextBox>
            &nbsp&nbsp
            <asp:Button class="btn btn-warning btn-xs" runat="server" ID="UpdateTitleButton" Text="עדכן כותרת" OnClick="OnUpdateTitleButton_Click" />
            <asp:Button class="btn btn-success btn-xs" runat="server" ID="SaveTitleButton" Text="שמור כותרת" Visible="false" OnClick="OnSaveTitleButton_Click" />
            <asp:Button class="btn btn-default btn-xs" runat="server" ID="CancelTitleButton" Text="ביטול" Visible="false" OnClick="OnCancelTitleButton_Click" />
            <h4><span class="glyphicon glyphicon-folder-open"></span>&nbsp&nbsp<asp:Label runat="server" ID="FolderNameLabel"></asp:Label></h4>
            <asp:Label class="errorMessage top-buffer" ID="TitleExerciseLabelError" CssClass="errorMessage" Visible="false" runat="server" Text="יש למלא שדה זה!"></asp:Label>
            



            <ul class="list-unstyled form-group">
                <li class="row">

                    <h4><span class="glyphicon glyphicon-info-sign"></span>&nbsp תיאור תרגיל    </h4>
                    <asp:Label runat="server" ID="DescriptionLabel" Text="אין הוראות לתרגיל זה"></asp:Label>
                    <asp:TextBox CssClass="form-control" ID="DescriptionTextBox" runat="server"></asp:TextBox>
                    &nbsp&nbsp
                     <asp:Button class="btn btn-warning btn-xs" runat="server" ID="UpdateDescriptionButton" Text="עדכן הוראות התרגיל" OnClick="OnUpdateDescriptionButton_Click" />
                    <asp:Button class="btn btn-success btn-xs" runat="server" ID="SaveDescriptionButton" Text="שמור הוראות לתרגיל" Visible="false" OnClick="OnSaveDescriptionButton_Click" />
                    <asp:Button class="btn btn-default btn-xs" runat="server" ID="CancelDescriptionButton" Text="ביטול" Visible="false" OnClick="OnCancelDescriptionButton_Click" />
                </li>

                <li class="row top-buffer">

                    <h4><span class="glyphicon glyphicon-link"></span>&nbsp לינק תרגיל                </h4>
                    <asp:HyperLink runat="server" ID="LinkHyperLink"></asp:HyperLink>
                    <asp:TextBox CssClass="form-control" ID="LinkTextBox" runat="server"></asp:TextBox>
                    &nbsp&nbsp
                     <asp:Button class="btn btn-warning btn-xs" runat="server" ID="UpdateLinkButton" Text="עדכן לינק" OnClick="OnUpdateLinkButton_Click" />
                    <asp:Button class="btn btn-success btn-xs" runat="server" ID="SaveLinkButton" Text="שמור לינק" Visible="false" OnClick="OnSaveLinkButton_Click" />
                    <asp:Button class="btn btn-default btn-xs" runat="server" ID="CancelLinkButton" Text="ביטול" Visible="false" OnClick="OnCancelLinkButton_Click" />
                </li>

                <li class="row top-buffer">

                    <h4><span class="glyphicon glyphicon-picture"></span>&nbsp תמונה                </h4>
                    <asp:Label runat="server" ID="ImageLabel" Text="אין תמונה לתרגיל זה">
                    <%if (!exercise.ImagePath.Equals(""))
                      { %>
                       <a href="https://www.dropbox.com/home/Applications/AppVoice?preview=<%=exercise.ImagePath %>"><%=exercise.ImagePath %> </a>
                       <%} %>
                    </asp:Label>
                    &nbsp&nbsp
                    <asp:FileUpload ID="ImageUpload" CssClass="top-buffer" runat="server" Height="25px" />
                    <asp:Button class="btn btn-warning btn-xs" runat="server" ID="UpdateImageButton" Text="עדכן תמונה" OnClick="OnUpdateImageButton_Click" />
                    <asp:Button class="btn btn-danger btn-xs" runat="server" ID="DeleteImageButton" Text="מחק תמונה" OnClick="OnDeleteImageButton_Click" />
                    <asp:Button class="btn btn-success btn-xs" runat="server" ID="SaveImageButton" Text="שמור תמונה" Visible="false" OnClick="OnSaveImageButton_Click" />
                    <asp:Button class="btn btn-default btn-xs" runat="server" ID="CancelImageButton" Text="ביטול" Visible="false" OnClick="OnCancelImageButton_Click" />
                </li>

                <li class="row top-buffer">

                    <h4><span class="glyphicon glyphicon-file"></span>&nbsp קובץ                </h4>
                    <asp:Label runat="server" ID="FileLabel" Text="אין קובץ לתרגיל זה"> 
                       <%if (!exercise.FilePath.Equals(""))
                         { %>
                       <a href="https://www.dropbox.com/home/Applications/AppVoice?preview=<%=exercise.FilePath %>"><%=exercise.FilePath %> </a>
                       <%} %>
                    </asp:Label>
                    &nbsp&nbsp
                     <asp:Button class="btn btn-warning btn-xs" runat="server" ID="UpdateFileButton" Text="עדכן קובץ" OnClick="OnUpdateFileButton_Click" />
                    <asp:Button class="btn btn-danger btn-xs" runat="server" ID="DeleteFileButton" Text="מחק קובץ" OnClick="OnDeleteFileButton_Click" />
                    <asp:Button class="btn btn-success btn-xs" runat="server" ID="SaveFileButton" Text="שמור קובץ" Visible="false" OnClick="OnSaveFileButton_Click" />
                    <asp:Button class="btn btn-default btn-xs" runat="server" ID="CancelFileButton" Text="ביטול" Visible="false" OnClick="OnCancelFileButton_Click" />

                    <asp:FileUpload ID="FileUpload" CssClass="top-buffer" runat="server" Height="25px" />
                </li>
                <li class="row top-buffer">
                    <h4><span class="glyphicon glyphicon-facetime-video"></span>&nbsp הקלטת וידאו?                 
                        <asp:CheckBox runat="server" OnCheckedChanged="OnCheckedChange"  ID="VideoCheckBox" />
                    </h4>
                </li>

                <li class="row top-buffer">

                    <asp:Label runat="server" ID="ErrorInUpdateLabel" CssClass="errorMessage" Visible="false" Text="שגיאה בעדכון פרטים. נסה שנית."></asp:Label>
                    <asp:Button class="btn btn-success" runat="server" Text="סיום" ID="SaveUpdatesButton" Visible="false" OnClick="OnSaveUpdatesButton_Click" />
                    <asp:Button class="btn btn-warning" runat="server" Text="עדכן פרטים" ID="UpdateButton" OnClick="OnUpdateButton_Click" />
                    <asp:Button class="btn btn-danger" runat="server" Text="מחק תרגיל" ID="DeleteButton" OnClick="OnDeleteButton_Click" />

                </li>
            </ul>
        </div>
    </div>
</asp:Content>
