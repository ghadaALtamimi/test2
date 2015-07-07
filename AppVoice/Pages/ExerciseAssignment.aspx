<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ExerciseAssignment.aspx.cs" Inherits="AppVoice.ExerciseAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><span class="glyphicon glyphicon-th-list"></span>&nbsp&nbsp שיבוץ תרגילים </h2>

        <div>
        <!-- Patient Panel -->
        <asp:Panel runat="server" ID="PanelFromPatient">
            <h3>
                <asp:Label runat="server" ID="PatientNameLabel"></asp:Label></h3>
            <!-- <asp:checkboxlist style="align-items:inherit" runat="server" ID="CheckBoxList"></asp:checkboxlist> -->

            <div class="col-md-10">
                <asp:Table ID="table" runat="server" class="table text-center">
                   <asp:TableRow Font-Bold="true">
                    <asp:TableCell><span class="glyphicon glyphicon-ok-circle"></span></asp:TableCell>
                    <asp:TableCell><span class="glyphicon glyphicon-user"></span>&nbsp שם תרגיל</asp:TableCell>
                    <asp:TableCell><span class="glyphicon glyphicon-envelope"></span>&nbsp סוג תרגיל</asp:TableCell>
                    <asp:TableCell><span class="glyphicon glyphicon-star"></span>&nbsp פעולות</asp:TableCell>

                </asp:TableRow>
                   
                </asp:Table>
            </div>
       <!--     <div class="col-md-2"> 
                 <table class="table" style="margin-bottom:0px; padding:8px;height: 39px;">
              
                    <tr >
                        <th class="text-center"><span class="glyphicon glyphicon-ok-circle"></span></th> 
                    </tr>
                    <tr class="text-center">
                        
                            <asp:CheckBoxList CssClass="table" runat="server" ID="CheckBoxList2">
                            </asp:CheckBoxList>
                    </tr>
                </table>
            </div> -->
        </asp:Panel>
        </div>

        <!-- Exercise Panel -->

        <asp:Panel runat="server" ID="PanelFromExercise">
            <h3>
                <asp:Label runat="server" ID="ExerciseNameLabel"></asp:Label></h3>
            <asp:CheckBoxList ID="CheckBoxList1" CssClass="top-buffer list-group" runat="server">
            </asp:CheckBoxList>
        </asp:Panel>

        <asp:Button runat="server" class="btn btn-primary" OnClick="OnAddAllExercises_Click" Text="שבץ תרגיל למטופלים המסומנים" />
        <asp:Label runat="server" CssClass="errorMessage" ID="LabelError">קרתה שגיאה. נסה שנית</asp:Label>
    </div>


</asp:Content>
