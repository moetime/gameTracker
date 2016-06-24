<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="GameTracker.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Game List</h1>

                        <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="GamesGridView" AutoGenerateColumns="false" DataKeyNames="GameID"
                    OnRowDeleting="GamesGridView_RowDeleting" AllowSorting="true"
                    OnSorting="GamesGridView_Sorting" OnRowDataBound="GamesGridView_RowDataBound" 
                    PagerStyle-CssClass="pagination-ys">
                    <Columns>
                        <asp:BoundField DataField="GameID" HeaderText="Game ID" Visible="true" SortExpression="GameID" />
                        <asp:BoundField DataField="Description" HeaderText="Description" Visible="true" SortExpression="Description" />
                        <asp:BoundField DataField="Spectators" HeaderText="Spectators" Visible="true" SortExpression="Spectators" />
                        <asp:BoundField DataField="DatePlayed" DataFormatString="{0:MMM dd, yyyy}"  HeaderText ="Date Played" Visible="true" SortExpression="DatePlayed" />
                       
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    
    
</asp:Content>
