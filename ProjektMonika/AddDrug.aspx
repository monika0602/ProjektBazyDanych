<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDrug.aspx.cs" Inherits="ProjektMonika.AddDrug" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="Add">
         <h1 class="text-center">Dodaj lek</h1>
                    <div class="form-group">
                        <label for="drug_name">Podaj nazwe:</label>
                        <input type="text" class="form-control" id="drug_name" name="drug_name" placeholder="Nazwa...">
                    </div>
          <div class="form-group">
                        <label for="drug_price">Podaj cenę:</label>
                        <input type="text" class="form-control" id="drug_price" name="drug_price" placeholder="Cena...">
                    </div>

         <div class="form-group">
                        <label for="prescription">Czy lek jest na receptę?</label>
                        <div><label for="prescription">Tak</label>
                        <input type="checkbox" id="prescription" name="prescription"></div>
                            

                    </div>
                    
            <asp:Button runat="server" CommandName="Dodaj" Text="Dodaj lek" OnClick="Add_Click"/>
        </div>
            <div id="Delete">
                <h1 class="text-center">Usuń lek</h1>
                    <div class="form-group">
                        <label for="del">Wybierz lek</label>
                            <div runat="server" class="form-group" id="drugs"></div>
                    </div>
                <asp:Button runat="server" CommandName="Usun" Text="Usuń lek" OnClick="Delete_Click"/>
            </div>
    <div id="GoToList">
        <asp:Button ID="GetDrugs" runat="server" Text="Przejdź do listy" OnClick="GetDrugs_Click" />
    </div>
</asp:Content>


