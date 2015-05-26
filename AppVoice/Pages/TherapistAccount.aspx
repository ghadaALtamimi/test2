<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TherapistAccount.aspx.cs" Inherits="AppVoice.Pages.TherapistAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <h2><span class="glyphicon glyphicon-user"></span>&nbsp איזור אישי -
            <asp:Label runat="server" ID="AccountName"></asp:Label></h2>
        <div class="panel panel-default">
            <div class="panel-body form-group">
                <div class="col-md-8 col-md-offset-4 " style="font-size: large">
                    <ul class="list-unstyled form-group">
                        <!-- License ID -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-info-sign"></span>&nbsp מספר רשיון:   
                             <div class="col-md-4 col-md-offset-6">
                                 <asp:Label ID="LicenseIdLabel" runat="server"></asp:Label>

                             </div>

                        </li>

                        <!-- First Name -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-user"></span>&nbsp שם פרטי:                
                            <div class="col-md-4 col-md-offset-6">
                                <asp:Label ID="FirstNameLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="FirstNameTextBox" class="form-control" runat="server"></asp:TextBox>
                                <!-- FirstName Error Panel -->
                                <asp:Panel ID="FirstNamePanelError" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert" id="FirstNameLabelWarning">
                                        <asp:Label CssClass="errorMessage" ID="FirstNameLabelError" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                        </li>

                        <!-- Last Name -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-user"></span>&nbsp שם משפחה:                
                            <div class="col-md-4 col-md-offset-6 ">
                                <asp:Label ID="LastNameLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="LastNameTexBox" class="form-control" runat="server"></asp:TextBox>
                                 <!-- LastName Error Panel -->
                                <asp:Panel ID="LastNamePanelError" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert" id="LastNameLabelWarning">
                                        <asp:Label CssClass="errorMessage" ID="LastNameLabelError" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>

                            </div>
                        </li>

                        <!-- Email -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-envelope"></span>&nbsp מייל:                
                            <div class="col-md-4 col-md-offset-6 ">
                                <asp:Label ID="MailLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="MailTextBox" runat="server" class="form-control"></asp:TextBox>
                                 <!-- FirstName Error Panel -->
                                <asp:Panel ID="MailPanelError" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert" id="MailLabelWarning">
                                        <asp:Label CssClass="errorMessage" ID="MailLabelError" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                        </li>

                        <!-- Password -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-asterisk"></span>&nbsp סיסמה:                
                            <div class="col-md-4 col-md-offset-6">
                                <asp:Label ID="PasswordLabel" runat="server">******</asp:Label>
                                <asp:TextBox ID="PasswordTextBox0" TextMode="password" runat="server" class="form-control" placeholder="הזן סיסמה נוכחית"></asp:TextBox>
                                <asp:TextBox ID="PasswordTextBox1" TextMode="password" runat="server" class="form-control top-buffer" placeholder="הזן סיסמה חדשה"></asp:TextBox>
                                <asp:TextBox ID="PasswordTextBox2" TextMode="password" runat="server" class="form-control top-buffer" placeholder="הזן סיסמה שנית"></asp:TextBox>
                                 <!-- Password Error Panel -->
                                <asp:Panel ID="PasswordPanelError" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert" id="PasswordLabelWarning">
                                        <asp:Label CssClass="errorMessage" ID="PasswordLabelError" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>
                                <!-- Update Success Panel -->
                                 <asp:Panel ID="UpdatePanelSuccess" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert" id="UpdateLabelSuccess">
                                        <asp:Label CssClass="successMessage" ID="PasswordUpdateSuccess" runat="server" Visible="false">סיסמה עודכנה בהצלחה!</asp:Label>
                                        <asp:Label CssClass="successMessage" ID="DetailsUpdateSuccess" runat="server" Visible="false">פרטים עודכנו בהצלחה!</asp:Label>
                                    </div>
                                </asp:Panel>
                                <!-- Update Failure Panel -->
                                 <asp:Panel ID="UpdatePanelFailure" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert" id="UpdateLabelFailure">
                                        <asp:Label CssClass="errorMessage" ID="PasswordUpdateFailure" runat="server" Visible ="false">שיגאה בעת עדכון הסיסמה!</asp:Label>
                                        <asp:Label CssClass="errorMessage" ID="DetailsUpdateFailure" runat="server" Visible ="false">שיגאה בעת עדכון הפרטים!</asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>

                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button type="button" class="btn btn-warning top-buffer" ID="EditButton" OnClick="OnEdit_Click" runat="server" Text="עדכן פרטים"></asp:Button>
                                <asp:Button type="button" class="btn btn-success top-buffer" ID="SaveDetailsButton" OnClick="OnSaveDetails_Click" runat="server" Text="שמור שינויים"></asp:Button>
                                <asp:Button type="button" class="btn btn-success top-buffer" ID="SavePasswordButton" OnClick="OnSavePassword_Click" runat="server" Text="שמור סיסמה"></asp:Button>
                                <asp:Button type="button" class="btn btn-info top-buffer" ID="PasswordButton" OnClick="OnPassword_Click" runat="server" Text="שנה סיסמה"></asp:Button>
                                <asp:Button type="button" class="btn btn-default top-buffer" ID="CancelButton" OnClick="OnCancel_Click" runat="server" Text="ביטול"></asp:Button>
                                <!-- <div class="col-md-3"> -->
                                &nbsp
                                <asp:Button type="button" class="btn btn-danger top-buffer" ID="DeleteButton" OnClick="OnDelete_Click" runat="server" Text="מחק משתמש"></asp:Button>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
