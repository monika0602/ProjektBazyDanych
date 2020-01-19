<%@ Page Title="Zamówienia" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetOrders.aspx.cs" Inherits="ProjektMonika.GetOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="text-center">
           <h2>Lista zamówień</h2>
            <div runat="server" id="orders"></div>
    </div>
</asp:Content>
