<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="MantPlantilla.aspx.cs" Inherits="SitioVentasWEB_GUI.Mantenimientos.MantPlantilla" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" Runat="Server">
    <%--El grid view para el listado de registros, recuerde implementar la primera columna de tipo Button, con el CommanName (recomendado) Editar
                   y con un icono asociado a la accion de editar y formatear las columnas que desea mostrar--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
       
            <%--Aqui va el titulo del formulario--%>
            <div>
                <p class="tituloForm">MANTENIMIENTO DE....</p>
            </div>

               <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo..." OnClick="btnNuevo_Click" CssClass="boton2" />
            <br />

             <%--El grid view para el listado de registros, recuerde implementar la primera columna de tipo Button, con el CommanName (recomendado) Editar
                   y con un icono asociado a la accion de editar y formatear las columnas que desea mostrar--%>
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="976px">
                <AlternatingRowStyle BackColor="White" />
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
            <br />
            <br />
            <br />
           
             <%-- PLANTILLA PARA LA INSERCION DEL REGISTRO --%>             
             <%--Control Target del ModalPopup de Insercion--%>
            <asp:LinkButton ID="lnkPopup1" runat="server"></asp:LinkButton>           
            <%--Panel cuyo contenido se mostrara en el ModalPopup de Insercion--%>
             <asp:Panel ID="PanelMan1" runat="server" CssClass="CajaDialogo" align="center" Style="display:table" Width="700">
              <table style="border: Solid 3px #D55500; height: 308px;"
                cellpadding="0" cellspacing="0" >
                <tr style="background-color: darkred">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Nuevo ...
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 45%" class="labelContenido">
                        &nbsp;</td>
                      <td align="left">
                          &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo1:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDescrip" runat="server" Width="487px" CssClass="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo2:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox1" runat="server" Width="487px" CssClass="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo3:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox2" runat="server" Width="487px" CssClass="TextBox" />
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="labelContenido">Campo N: </td>
                         <td align="left">
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="lblMensaje1" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style1">
                             &nbsp;</td>
                         <td class="auto-style1">
                             <asp:Button ID="btnGrabar" runat="server" Text="Grabar" Width="100px" CssClass="boton" />
                             &nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnCerrar" runat="server"  Text="Cancelar" Width="100px" CssClass="boton" />
                         </td>
                     </tr>
              
            </table>
                        
        </asp:Panel>
              <%--Modalpopup extender PopMan01 para nuevos registros : vease el TargetControl que apunta al linkbutton  lnkPopup1 
                  y el PopupcontrolID que apunta al panel PanelMan1--%> 
             <ajaxToolkit:ModalPopupExtender ID="PopMan01" TargetControlID="lnkPopup1" 
                 PopupControlID="PanelMan1" runat="server" BackgroundCssClass="FondoAplicacion" ></ajaxToolkit:ModalPopupExtender>



          <%-- PLANTILLA PARA LA EDICION DEL REGISTRO (incluye un label para el codigo o PK del registro)--%>           
            <%--Control target del ModalPopup de edicion--%>
            <asp:LinkButton ID="lnkPopup2" runat="server"></asp:LinkButton>

             <%--Panel cuyo contenido de mostrara en el ModalPopup de Edicion--%>
       <asp:Panel ID="PanelMan2" runat="server" CssClass="CajaDialogo" align="center" Style="display:table" Width="700">
            <table style="border: Solid 3px #D55500; height: 308px;"
                cellpadding="0" cellspacing="0" >
                <tr style="background-color: darkred">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Actualizar ...
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 45%" class="labelContenido">
                        &nbsp;</td>
                      <td align="left">
                          &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido" style="width: 45%">
                        <asp:Label ID="lblEtiquetaCod" runat="server" Text="Id. :"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblCod" runat="server" CssClass="labelTitulo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo1:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox3" runat="server" Width="487px" CssClass="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo2:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox4" runat="server" Width="487px" CssClass="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Campo3:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox5" runat="server" Width="487px" CssClass="TextBox" />
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="labelContenido">Campo N: </td>
                         <td align="left">
                             &nbsp;</td>
                     </tr>
                     <tr>
                         <td colspan="2">
                             <asp:Label ID="lblMensaje2" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style1">
                             &nbsp;</td>
                         <td class="auto-style1">
                             <asp:Button ID="Button1" runat="server" Text="Grabar" Width="100px" CssClass="boton" />
                             &nbsp;&nbsp;
                             <asp:Button ID="Button2" runat="server"  Text="Cancelar" Width="100px" CssClass="boton" />
                         </td>
                     </tr>
              
            </table>
        </asp:Panel>
       <%--Modalpopup extender PopMan02 para el edicion de registros: vease el TargetControl que apunta al linkbutton  lnkPopup2 y el PopupcontrolID que apunta al panel PanelMan2--%> 
             <ajaxToolkit:ModalPopupExtender ID="PopMan02" TargetControlID="lnkPopup2" 
                 PopupControlID="PanelMan2" runat="server" BackgroundCssClass="FondoAplicacion"></ajaxToolkit:ModalPopupExtender>

      <%--CONFIGURACION DEL MODALPOPUP DE MENSAJES --%>
                <%--Control target para el ModalPopup de mensajes--%>
              <asp:LinkButton ID="lnkMensaje" runat="server" ></asp:LinkButton>
                 <%-- El panel cuyo contenido se mostrara en el ModalPopup de mensajes--%>
              <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal;" Width="500"> 
                    <table border="0" width="500px" style="margin: 0px; padding: 0px; background-color:darkred ; 
                        color: #FFFFFF;"> 
                        <tr> 
                            <td align="center"> 
                                <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" /> 
                            </td> 
                            <td width="12%" class="auto-style1" > 
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;" 
                                    ImageAlign="Right" /> 
                            </td> 
                        </tr> 
                         
                    </table>
                    <div> 
                        <asp:Label ID="lblMensajePopup" runat="server" ForeColor ="Black" CssClass="labelTitulo" /> 
                    </div>
                     <div>
                         <br />
                     </div>
                    <div> 
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="boton" /> 
                    </div> 
                  <div>
                         <br />
                     </div>
                </asp:Panel> 
          <%--El ModalPopup  PopMensaje que hace referencia al ID del control target  (TargetControlID="lnkMensaje")
                    y al ID al panel (PopupControlID="pnlMensaje")--%>
                               <ajaxToolkit:ModalPopupExtender ID="PopMensaje" 
                                   TargetControlID="lnkMensaje" 
                                   PopupControlID="pnlMensaje" runat="server" BackgroundCssClass="FondoAplicacion"></ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>

    </asp:UpdatePanel>
   <%--El UpdateProgress para el manejo del tiempo de refresco del UpdatePanel1 por la insercion , actualizacion o eliminacion--%>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <%--<ProgressTemplate >
            <div class="overlay"  />
            <div class ="overlayContent" >
            <h2>  Procesando....</h2> 
                <p>
                    &nbsp;</p>
                <img src ="../Images/indicator.gif" alt ="Loading" border="0"/>
                </div> 
        </ProgressTemplate>--%>
    </asp:UpdateProgress>
</asp:Content>
