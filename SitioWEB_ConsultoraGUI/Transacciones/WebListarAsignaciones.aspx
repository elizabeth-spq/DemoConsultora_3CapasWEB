<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="WebListarAsignaciones.aspx.cs" Inherits="SitioWEB_ConsultoraGUI.Transacciones.WebListarAsignaciones" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <p class="tituloForm">Listado de Asignaciones</p>
    <p class="tituloForm">
                <asp:HyperLink ID="HyperLinkTran2" runat="server" NavigateUrl="~/Transacciones/Transacciones.aspx">Retornar</asp:HyperLink>
                        </p>
            <asp:GridView ID="grvASIG" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="975px" AllowPaging="True" OnPageIndexChanging="grvASIG_PageIndexChanging" OnRowCommand="grvASIG_RowCommand" PageSize="20">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Cod_Asig" HeaderText="Codigo" />
                <asp:BoundField DataField="Fec_Asig" DataFormatString="{0:d}" HeaderText="Fec. Asig" />
                <asp:BoundField DataField="Nombre_Proyecto" HeaderText="Proyecto" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:BoundField DataField="Tar_Asig" HeaderText="Tarifa" />
                <asp:ButtonField ButtonType="Button" CommandName="Descargar" Text="Descargar proforma" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Left" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    <%--Este es el popup que contiene los mensajes de error--%>            
    <%--el link button o cualquiero otro control para el manejo del modal (TargetControlID)--%>
              <asp:LinkButton ID="lnkMensaje" runat="server" ></asp:LinkButton>
    <%--El  panel con el contenido del mensaje (PopupControlID)--%>
               <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal;" Width="500"> 
                    <table border="0" width="500px" > 
                        <tr style="margin: 0px; padding: 0px; background-color:darkred ; 
                        color: #FFFFFF;"> 
                            <td align="center" class="auto-style7" > 
                                <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" /> 
                            </td> 
                            <td width="12%" class="center"> 
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;" 
                                    ImageAlign="Right" /> 
                            </td> 
                        </tr> 
                         <tr>
                             <td class="center" colspan="2">
                                  &nbsp;</td>
                         </tr>
                         <tr>
                             <td class="center" colspan="2">
                                 <asp:Label ID="lblMensajePopup" runat="server" CssClass="labelTitulo" />
                             </td>
                        </tr>
                         <tr>
                             <td class="auto-style7">&nbsp;</td>
                        </tr>
                         <tr>
                             <td class="center" colspan="2">
                                  <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton-new" /> 
                             </td>
                         </tr>
                        <tr>
                            <td class="center" colspan="2">&nbsp;</td>
                        </tr>
                    </table> 
                 </asp:Panel> 
            <ajaxToolkit:ModalPopupExtender ID="PopMensaje" runat="server" TargetControlID="lnkMensaje" 
                    PopupControlID="pnlMensaje" BackgroundCssClass="FondoAplicacion" OkControlID="btnAceptar" 
                     />
   
   


</asp:Content>
