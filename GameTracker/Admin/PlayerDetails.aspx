<%@ Page Title="Player Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlayerDetails.aspx.cs" Inherits="GameTracker.PlayerDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Player Details</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="NameTextBox">Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="NameTextBox" placeholder="Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="AgeTextBox">Age</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="AgeTextBox" placeholder="Age" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="GenderTextBox">Gender</label>
                    <asp:TextBox runat="server"  CssClass="form-control" ID="GenderTextBox" placeholder="Gender" required="true"></asp:TextBox>
                   
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
