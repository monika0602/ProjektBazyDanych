<%@ Page Title="Złóż nowe zamówienie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="ProjektMonika.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Poniżej możesz złożyć zamówienie</h3>
    <div class="form-group">
                        <label for="customer">Wybierz klienta</label>
                            <div runat="server" class="form-group" id="customers"></div>
    </div>

    <div class="form-group">
                        <label for="farm">Wybierz aptekę</label>
                            <div runat="server" class="form-group" id="farms"></div>
     </div>

    <div class="form-group">
                        <label for="drug">Wybierz lek</label>
                            <div runat="server" class="form-group" id="drugs"></div>
    </div>

    <div class="form-group">
                        <label for="amount">Ilość leku</label>
                        
                       <div> <input type="number" id="amount" name="amount" min="1" max="10"></div></div>
                            


    <asp:Button runat="server" CommandName="Dodaj" Text="Dodaj zamówienie" OnClick="Add_Click"/>
</asp:Content>
