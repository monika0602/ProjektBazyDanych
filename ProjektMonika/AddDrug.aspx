<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDrug.aspx.cs" Inherits="ProjektMonika.AddDrug" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <span runat="server" id="wrong" class="text-danger font-weight-bold"></span>
                <label>Nazwa</label>
                <input type="text" class="form-control" name="imie" id="imie" required>
                <label>Nazwisko</label>
                <input type="text" class="form-control" name="naz" id="naz" required>
       
              
            <asp:Button runat="server" CommandName="MoveNext" Text="Zarejestruj" OnClick="AddUser"/>
</asp:Content>
