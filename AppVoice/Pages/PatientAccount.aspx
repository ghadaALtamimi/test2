<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PatientAccount.aspx.cs" Inherits="AppVoice.AddedPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <h2>
            <asp:Label runat="server" ID="Label1" Text="מטופל התווסף בהצלחה! "></asp:Label></h2>
        <h2><span class="glyphicon glyphicon-user"></span>&nbsp איזור אישי -
            <asp:Label runat="server" ID="AccountName"></asp:Label></h2>
        <div class="panel panel-default">
            <div class="panel-body form-group">
                <div class="col-md-8 col-md-offset-4 " style="font-size: large">
                    <ul class="list-unstyled form-group">


                        <!-- First Name -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-user"></span>&nbsp שם פרטי:                
                            <div class="col-md-4 col-md-offset-5">
                                <asp:Label ID="FirstNameLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="FirstNameTextBox" class="form-control" runat="server" Visible="false"></asp:TextBox>
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
                            <div class="col-md-4 col-md-offset-5 ">
                                <asp:Label ID="LastNameLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="LastNameTexBox" class="form-control" runat="server" Visible="false"></asp:TextBox>
                                <!-- LastName Error Panel -->
                                <asp:Panel ID="LastNamePanelError" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert" id="LastNameLabelWarning">
                                        <asp:Label CssClass="errorMessage" ID="LastNameLabelError" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>

                            </div>
                        </li>

                        <!-- ID -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-info-sign"></span>&nbsp מספר תעודת זהות:   
                             <div class="col-md-4 col-md-offset-5">
                                 <asp:Label ID="PatientIdLabel" runat="server"></asp:Label>

                             </div>

                        </li>

                        <!-- Email -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-envelope"></span>&nbsp מייל:                
                            <div class="col-md-4 col-md-offset-5 ">
                                <asp:Label ID="MailLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="MailTextBox" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                <!-- Email Error Panel -->
                                <asp:Panel ID="MailPanelError" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert" id="MailLabelWarning">
                                        <asp:Label CssClass="errorMessage" ID="MailLabelError" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                        </li>

                        <!-- Phone Number -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-phone-alt"></span>&nbsp מספר טלפון:                
                            <div class="col-md-4 col-md-offset-5 ">
                                <asp:Label ID="PhoneNumberLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="PhoneNumberTextBox" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                <!-- Phone number Error Panel -->
                                <asp:Panel ID="Panel1" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert">
                                        <asp:Label CssClass="errorMessage" ID="PhoneLabelError" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                        </li>

                        <!-- Address -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-map-marker"></span>&nbsp כתובת:                
                            <div class="col-md-4 col-md-offset-5 ">
                                <asp:Label ID="AddressLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="AddressTextBox" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                <!-- Address Error Panel -->
                                <asp:Panel ID="Panel2" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert">
                                        <asp:Label CssClass="errorMessage" ID="AddressErrorlabel" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                        </li>

                        <!-- HMO -->
                        <li class="row top-buffer">
                            <span class="glyphicon glyphicon-heart-empty"></span>&nbsp קופת חולים:                
                            <div class="col-md-4 col-md-offset-5 ">
                                <asp:Label ID="HmoLabel" runat="server"></asp:Label>
                                <asp:TextBox ID="HmoTextBox" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                <!-- HMO Error Panel -->
                                <asp:Panel ID="Panel3" Visible="false" runat="server">
                                    <div class="alert alert-warning" role="alert">
                                        <asp:Label CssClass="errorMessage" ID="HmoErrorLabel" runat="server">חובה למלא שדה זה!</asp:Label>
                                    </div>
                                </asp:Panel>
                            </div>
                            <br />
                            <!-- Update Success Panel -->
                            <asp:Panel ID="UpdatePanelSuccess" Visible="false" runat="server">
                                <div class="alert alert-warning" role="alert" id="UpdateLabelSuccess">
                                    <asp:Label CssClass="successMessage" ID="DetailsUpdateSuccess" runat="server">פרטים עודכנו בהצלחה!</asp:Label>
                                </div>
                            </asp:Panel>
                            <!-- Update Failure Panel -->
                            <asp:Panel ID="UpdatePanelFailure" Visible="false" runat="server">
                                <div class="alert alert-warning" role="alert" id="UpdateLabelFailure">
                                    <asp:Label CssClass="errorMessage" ID="DetailsUpdateFailure" runat="server">שיגאה בעת עדכון הפרטים!</asp:Label>
                                </div>
                            </asp:Panel>
                        </li>
                        <li>
                            <div class="col-md-8 col-md-offset-4">
                                <asp:Button type="button" class="btn btn-warning top-buffer" ID="EditButton" OnClick="OnEdit_Click" runat="server" Text="עדכן פרטים"></asp:Button>
                                <asp:Button type="button" class="btn btn-success top-buffer" ID="SaveDetailsButton" OnClick="OnSaveDetails_Click" runat="server" Text="שמור שינויים"></asp:Button>
                                <asp:Button type="button" class="btn btn-default top-buffer" ID="CancelButton" OnClick="OnCancel_Click" runat="server" Text="ביטול"></asp:Button>
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
