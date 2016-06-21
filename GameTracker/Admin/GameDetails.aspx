<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="GameTracker.Game_Details" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Game Details</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="NameTextBox">Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="NameTextBox" placeholder="Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="DescriptionTextBox">Description</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DescriptionTextBox" placeholder="Description" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="SpectatorsTextBox">Spectators</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="SpectatorsTextBox" placeholder="Spectators" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="DatePlayedTextBox">Date Played</label>
                    <asp:TextBox runat="server" TextMode="Date" CssClass="form-control" ID="DatePlayedTextBox" placeholder="Enrollment Date Format: mm/dd/yyyy" required="true"></asp:TextBox>
                    <asp:RangeValidator ID="DateRangeValidator" runat="server" ErrorMessage="Invalid Date! Format: mm/dd/yyyy"
                        ControlToValidate="DatePlayedTextBox" MinimumValue="01/01/2000" MaximumValue="01/01/2999"
                        Type="Date" Display="Dynamic" BackColor="Red" ForeColor="White" Font-Size="Large"></asp:RangeValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <!-- Player 1 -->
            <div class="col-md-offset-3 col-md-3">
                <h1>Player A</h1>
                <br />
                <div class="form-group">
                    <label class="control-label" for="BPlayerDropDownList">Player</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="APlayerDropDownList" placeholder="Name" required="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label" for="AWinsTextBox">Wins</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="AWinsTextBox" placeholder="Wins" required="true"></asp:TextBox>
                </div>
            </div>
            <!-- Player 2 -->
             <div class="col-md-3">
                <h1>Player B</h1>
                <br />
                <div class="form-group">
                    <label class="control-label" for="BPlayerDropDownList">Player</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="BPlayerDropDownList" placeholder="Name" required="true"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="control-label" for="BWinsTextBox">Wins</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="BWinsTextBox" placeholder="Wins" required="true"></asp:TextBox>
                </div>
            </div>
        </div>
         <div class="row">             
             
            <div class="col-md-offset-3 col-md-6 text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
         </div>
    </div>


</asp:Content>
