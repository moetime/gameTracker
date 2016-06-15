﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="GameTracker.Navbar" %>
<nav class="navbar navbar-inverse" role="navigation">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="Default.aspx"><i class="fa fa-fort-awesome fa-md"></i> The Gamblers Den</a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <li id="home" runat="server"><a href="Default.aspx"><i class="fa fa-home fa-lg"></i> Home</a></li>
                <li id="students" runat="server"><a href="Students.aspx"><i class="fa fa-graduation-cap fa-lg"></i> Students</a></li>
                <li id="player" runat="server"><a href="Players.aspx"><i class="fa fa-users fa-lg"></i> Players</a></li>
                <li id="users" runat="server"><a href="PlayerDetails.aspx"><i class="fa fa-user fa-lg"></i> New Players</a></li>
                <li id="gamedetails" runat="server"><a href="GameDetails.aspx"><i class="fa fa-info-circle"></i> Game Details</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>