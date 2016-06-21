<%@ Page Title="Players" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Players.aspx.cs" Inherits="GameTracker.Players" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Player List</h1>
                <a href="PlayerDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i>Add Player</a>

                        <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="PlayersGridView" AutoGenerateColumns="false" DataKeyNames="PlayerID"
                    OnRowDeleting="PlayersGridView_RowDeleting" AllowSorting="true"
                    OnSorting="PlayersGridView_Sorting" OnRowDataBound="PlayersGridView_RowDataBound" 
                    PagerStyle-CssClass="pagination-ys">
                    <Columns>
                        <asp:BoundField DataField="PlayerID" HeaderText="Player ID" Visible="true" SortExpression="PlayerID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" Visible="true" SortExpression="Name" />
                        <asp:BoundField DataField="Age" HeaderText="Age" Visible="true" SortExpression="Age" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" Visible="true" SortExpression="Gender" />
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/PlayerDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="PlayerID" DataNavigateUrlFormatString="PlayerDetails.aspx?PlayerID={0}" />
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    
</asp:Content>
