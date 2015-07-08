<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewMessage.aspx.cs" Inherits="AppVoice.NewMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><span class="glyphicon glyphicon-user"></span>&nbsp הודעה חדשה</h2>

        <div class="col-md-6 col-md-offset-6">
            <ul class="list-unstyled form-group">
                <li class="row top-buffer">

                    <asp:Label runat="server"><span class="glyphicon glyphicon-info-sign"></span>&nbsp הודעה עבור:                 </asp:Label>

                    <asp:DropDownList runat="server" ID="DropDownPatients"></asp:DropDownList>
                    <div class="col-md-4">
                        <asp:Label class="errorMessage top-buffer" ID="TitleExerciseLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                    </div>


                </li>
                <li class="row top-buffer">
                    <asp:TextBox CssClass="form-control" ID="MessageTextBox" TextMode="MultiLine" Height="150px" runat="server"></asp:TextBox>
                    <div class="col-md-4">
                        <asp:Label class="errorMessage top-buffer" ID="Label1" CssClass="errorMessage" runat="server" Text="לא ניתן לשלוח הודעה ריקה!"></asp:Label>
                    </div>
                </li>
                <li class="row top-buffer">
                    <div class="col-md-4">
                        <asp:Label class="errorMessage top-buffer" ID="Label2" CssClass="errorMessage" runat="server" Text="קרתה שגיאה - הודעה לא נשלחה!"></asp:Label>
                    </div>
                    <div class="col-md-4">
                        <asp:Label class="errorMessage top-buffer" ID="Label3" runat="server" Text="הודעה נשלחה בהצלחה!"></asp:Label>
                    </div>
                    <asp:Button class="btn btn-warning" ID="Button1" runat="server" OnClick="OnSendMessageButton_Click" Text="שלח הודעה" />
                </li>
            </ul>
        </div>
</asp:Content>
