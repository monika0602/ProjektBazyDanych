<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFarm.aspx.cs" Inherits="ProjektMonika.AddFarm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Add">
         <h1 class="text-center">Dodaj aptekę</h1>
                    <div class="form-group">
                        <label for="farm_name">Podaj nazwę:</label>
                        <input type="text" class="form-control" id="farm_name" name="farm_name" placeholder="Nazwa...">
                    </div>
                    <div class="form-group">
                        <label for="street_name">Podaj ulicę:</label>
                        <input type="text" class="form-control" id="street_name" name="street_name" placeholder="Ulica...">
                    </div>
                     <div class="form-group">
                        <label for="city">Podaj miasto:</label>
                        <input type="text" class="form-control" id="city" name="city" placeholder="Miasto...">
                    </div>
                     <div class="form-group">
                        <label for="postcode">Podaj kod pocztowy:</label>
                        <input type="text" class="form-control" id="postcode" name="postcode" placeholder="Kod pocztowy...">
                    </div>
          
                    
            <asp:Button runat="server" CommandName="Dodaj" Text="Dodaj aptekę" OnClick="Add_Click"/>
        </div>

    <div id="Delete">

        <h1 class="text-center">Usuń aptekę</h1>
                    <div class="form-group">
                        <label for="del">Wybierz aptekę</label>
                            <div runat="server" class="form-group" id="farms"></div>
                    </div>
                <asp:Button runat="server" CommandName="Usun" Text="Usuń aptekę" OnClick="Delete_Click"/>

    </div>

    <div id="GoToList">
        <asp:Button ID="GetFarm" runat="server" Text="Przejdź do listy" OnClick="GetFarm_Click" />
    </div>
</asp:Content>
