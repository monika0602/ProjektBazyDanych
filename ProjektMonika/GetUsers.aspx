<%@ Page Title="Klienci" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetUsers.aspx.cs" Inherits="ProjektMonika.GetUsers" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
           <h2>Lista klientow</h2>
            <div runat="server" id="customers"></div>
    </div>
</asp:Content>