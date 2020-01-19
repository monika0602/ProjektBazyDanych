<%@ Page Title="Dodaj dane do bazy danych" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="ProjektMonika.AddContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Poniżej lista możliwych elementów do dodania</h3>
    <asp:Button ID="AddFarm" runat="server" Text="Dodaj/Usuń aptekę" OnClick="AddFarm_Click" />
    <asp:Button ID="AddDrug" runat="server" Text="Dodaj/Usuń lek" OnClick="AddDrug_Click"/>
    <asp:Button ID="AddCustomer" runat="server" Text="Dodaj/Usuń klienta" OnClick="AddCustomer_Click" />
</asp:Content>
