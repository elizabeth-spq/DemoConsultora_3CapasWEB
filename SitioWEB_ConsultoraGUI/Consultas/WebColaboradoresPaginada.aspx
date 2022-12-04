<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="WebColaboradoresPaginada.aspx.cs" Inherits="SitioWEB_ConsultoraGUI.Consultas.WebColaboradoresPaginada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
    <p class="tituloForm">
        Listado paginado de Colaboradores</p>
   
        <table  >
            <tr>
                <td class="labelContenido">Seleccione Area:</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="cboArea" runat="server" Width="300px" CssClass="DropDownList">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="labelContenido">Seleccione categoria:</td>
                <td class="auto-style11">
                    <asp:DropDownList ID="cboCategoria" runat="server" Width="300px" CssClass="DropDownList">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="labelContenido">Seleccione estado:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="cboEstado" runat="server" Width="300px" CssClass="DropDownList">
                        <asp:ListItem Selected="True" Value="X">--Todos--</asp:ListItem>
                        <asp:ListItem>Activo</asp:ListItem>
                        <asp:ListItem>Inactivo</asp:ListItem>
                       
                    </asp:DropDownList>
                </td>
                <td class="auto-style1" >
                    <asp:Button ID="btnFiltrar" runat="server" CssClass="boton2" Text="Filtrar" Width="100px" OnClick="btnFiltrar_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="3">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="labelErrores"></asp:Label>
                </td>
            </tr>
            </table>
            
                    <asp:GridView ID="grvColaboradores" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="1287px" CssClass="GriedView" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Cod_Col" HeaderText="Codigo" />
                            <asp:BoundField DataField="Colaborador" HeaderText="Colaborador" />
                            <asp:BoundField DataField="Nom_Area" HeaderText="Area" />
                            <asp:BoundField DataField="Nom_Cat" HeaderText="Categoria" >
                            </asp:BoundField>
                            <asp:BoundField DataField="Ema_Col" HeaderText="Email" />
                            <asp:BoundField DataField="Antiguedad" HeaderText="Antiguedad (Años)" >
                            </asp:BoundField>
                            <asp:BoundField DataField="Sue_Col" HeaderText="Suledo(S/.)" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado_Colaborador" HeaderText="Estado" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
            <table>
            <tr>
                <td class="auto-style2">
                    <asp:DropDownList ID="cboPaginas" runat="server" Width="60px" AutoPostBack="True" OnSelectedIndexChanged="cboPaginas_SelectedIndexChanged" CssClass="DropDownList">
                    </asp:DropDownList>
                </td>
                <td class="auto-style3">&nbsp;</td>
             </tr>
        </table>
            </ContentTemplate>
   </asp:UpdatePanel>
       <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0"  AssociatedUpdatePanelID ="UpdatePanel1">
           <ProgressTemplate>
              <div class="overlay">
                  <div class="overlayContent ">
                  <h2>Cargando</h2>  
                  <img src="../Images/loading.gif" alt ="Loading" border="0" />              
              </div>
              </div>
          </ProgressTemplate> 
    </asp:UpdateProgress>
</asp:Content>
