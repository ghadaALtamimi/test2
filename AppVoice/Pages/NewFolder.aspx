<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewFolder.aspx.cs" Inherits="AppVoice.NewFolder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="RegPanel" runat="server" DefaultButton="RegButton">

        <div class="container">
            <h2><span class="glyphicon glyphicon-edit"></span>&nbsp הוספת תקייה</h2>

            <div class="col-md-6 col-md-offset-6">
                <ul class="list-unstyled form-group">
                    <li class="row">

                        <span class="glyphicon glyphicon-info-sign"></span>&nbsp ת"ז                
                                <asp:TextBox class="form-control" ID="PatientIdTextBox" runat="server"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="PatientIdLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                            <asp:Label class="errorMessage" ID="PatientIdLabelErrorExist" CssClass="errorMessage" runat="server" Text="המשתמש כבר רשום במערכת!"></asp:Label>
                        </div>
                    </li>

                    <li class="row">

                        <span class="glyphicon glyphicon-user"></span>&nbsp שם פרטי                
                                <asp:TextBox class="form-control" ID="FirstNameTextBox" runat="server"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="FirstNameLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                        </div>
                    </li>

                    <li class="row">
                        <span class="glyphicon glyphicon-user"></span>&nbsp שם משפחה
                            <asp:TextBox Class="form-control" ID="LastNameTextBox" runat="server"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="LastNameLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                        </div>
                    </li>

                    <li class="row">
                        <span class="glyphicon glyphicon-envelope"></span>&nbsp מייל
                            <asp:TextBox Class="form-control" ID="MailTextBox" runat="server"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="MailLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                            <asp:Label class="errorMessage" ID="ExistLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </li>

                    <li class="row">
                        <span class="glyphicon glyphicon-phone-alt"></span>&nbsp מספר טלפון
                            <asp:TextBox Class="form-control" ID="PhoneNumberTextBox" runat="server"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="PhoneNumberLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                        </div>
                    </li>

                    <li class="row">
                        <span class="glyphicon glyphicon-map-marker"></span>&nbsp כתובת
                            <asp:TextBox Class="form-control" ID="AddressTextBox" runat="server"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="AddressLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                        </div>
                    </li>

                    <li class="row">

                        <span class="glyphicon glyphicon-heart-empty"></span>&nbsp קופת חולים                
                                <asp:TextBox class="form-control" ID="HmoTextBox" runat="server"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="HmoLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                        </div>
                    </li>
                    <li class="row">
                        <span class="glyphicon glyphicon-asterisk"></span>&nbsp סיסמה למטופל
                            <asp:TextBox Class="form-control" ID="PasswordTextBox" runat="server" TextMode="password"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="PasswordLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                        </div>
                    </li>

                    <li class="row">
                        <span class="glyphicon glyphicon-asterisk"></span>&nbsp הזן סיסמה שנית
                            <asp:TextBox Class="form-control" ID="RePasswordTextBox" runat="server" TextMode="password"></asp:TextBox>
                        <div class="col-md-4">
                            <br />
                            <asp:Label class="errorMessage" ID="RePasswordLabelError" CssClass="errorMessage" runat="server" Text="יש למלא שדה זה!"></asp:Label>
                        </div>
                    </li>
                </ul>
           </div>
            <div class="text-center">
                <asp:Button class="btn btn-success" ID="RegButton" runat="server" OnClick="OnSaveButton_Click" Text="הוסף מטופל" />
            </div>
        </div>
        
    </asp:Panel>
</asp:Content>
