<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="ProjektMonika.AddCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div id="Add">
         <h1 class="text-center">Dodaj klienta</h1>
                    <div class="form-group">
                        <label for="user_name">Podaj imię:</label>
                        <input type="text" class="form-control" id="user_name" name="user_name" placeholder="Imię...">
                    </div>
          <div class="form-group">
                        <label for="user_surrname">Podaj nazwisko:</label>
                        <input type="text" class="form-control" id="user_surrname" name="user_surrname" placeholder="Nazwisko...">
                    </div>
                    
            <asp:Button runat="server" CommandName="Dodaj" Text="Dodaj klienta" OnClick="Add_Click"/>
        </div>
            <div id="Delete">
                <h1 class="text-center">Usuń klienta</h1>
                    <div class="form-group">
                        <label for="del">Wybierz klienta</label>
                            <div runat="server" class="form-group" id="customers"></div>
                    </div>
                <asp:Button runat="server" CommandName="Usun" Text="Usuń klienta" OnClick="Delete_Click"/>
            </div>
    <div id="GoToList">
        <asp:Button ID="GetUsers" runat="server" Text="Przejdź do listy" OnClick="GetUsers_Click" />
    </div>

</asp:Content>
