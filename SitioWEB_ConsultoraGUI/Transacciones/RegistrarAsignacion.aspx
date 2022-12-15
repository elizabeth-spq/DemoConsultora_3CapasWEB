<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="RegistrarAsignacion.aspx.cs" Inherits="SitioWEB_ConsultoraGUI.Transacciones.RegistrarAsignacion" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 70%;
        }
        .auto-style4 {
            height: 18px;
        }
        .auto-style5 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 30px;
        }
        .auto-style6 {
            width: 150px;
            height: 30px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Principal" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

       <%-- Coloque esta  etiqueta Triggers (de AJAX) dentro del UpdatePanel1 para la ejecucion 
           del evento click del boton btnGrabarOC y el correcto envio de la proforma al grabar la Orden de compra.--%>
        <Triggers>
               <asp:PostBackTrigger ControlID="btnGrabarOC" />              
        </Triggers>

        <ContentTemplate >
    <table>
            
              
                    <caption>
                        <h2 class="tituloForm">Registrar Asignacion </h2>
                        <tr>
                            <td class="labelContenido">Ingrese fecha de Asignación:</td>
                            <td colspan="2" style="width: 100px; height: 21px">
                                <asp:TextBox ID="txtFecAsig" runat="server" CssClass="TextBoxDerecha" Width="150px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFecAsig_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFecAsig" />
                            </td>
                        </tr>
                        <tr>
                            <td class="labelContenido">Seleccione Proyecto:</td>
                            <td class="auto-style15" colspan="2">
                                <asp:DropDownList ID="cboProyecto" runat="server" AutoPostBack="True" CssClass="DropDownList" Width="300px" OnSelectedIndexChanged="cboProyecto_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="auto-style5">Tarifa de la Asignación:</td>
                            <td colspan="2" class="auto-style6">
                                
                                <asp:TextBox ID="txtTarifa" runat="server" Width="150px"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="labelContenido">&nbsp;</td>
                            <td colspan="2" style="width: 100px">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style20">
                                <asp:Button ID="btnAgregar" runat="server" CssClass="boton2" onclick="btnAgregar_Click" Text="Agregar Detalle" Width="150px" />
                            </td>
                            <td class="auto-style21">
                                <asp:Button ID="btnVerGrabar" runat="server" CssClass="boton2" onclick="btnVerGrabar_Click" Text="Grabar" Width="150px" />
                            </td>
                            <td class="auto-style21">
                                <asp:Button ID="btnCancelar" runat="server" CssClass="boton-new" PostBackUrl="~/Transacciones/Transacciones.aspx" Text="Cancelar" Width="150px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20">
                                <asp:HyperLink ID="HyperLinkTran1" runat="server" NavigateUrl="~/Transacciones/Transacciones.aspx">Retornar</asp:HyperLink>
                            </td>
                            <td class="auto-style21">&nbsp;</td>
                            <td class="auto-style21">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;<asp:GridView ID="grDetalles" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" onrowcommand="grDetalles_RowCommand" ShowHeaderWhenEmpty="True" Width="1076px">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/Images/Borrar.png" Text="Eliminar" />
                                    <asp:BoundField DataField="Cod_Col" HeaderText="Codigo Colaborador" />
                                    <asp:BoundField DataField="Colaborador" HeaderText="Colaborador" />
                                    <asp:BoundField DataField="Tip_Asig" HeaderText="Tipo de Asignacion" />
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style13">&nbsp;</td>
                            <td colspan="2" style="width: 700px">&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                    </caption>
               
        </table>
            <%-- Aqui va el popup de Detalle --%>
            <%--el link button o cualquiero otro control para el manejo del modal (TargetControl)--%>
           <asp:LinkButton Text="" ID = "lnkDetalle" runat="server" />
            <%--El  panel con el contenido--%>
              <asp:Panel ID="PanelDetalle" runat="server" CssClass="CajaDialogo" align="center" Style="display:normal" Width="600px">
          
            <table style="border: Solid 3px #D55500;"
                cellpadding="0" cellspacing="0" width="600px" >
                <tr style="background-color: darkred">
                    <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                        align="center">
                        Registrar Detalle
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5">
                        &nbsp;</td>
                      <td align="left" class="auto-style6">
                          &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5"></td>
                    <td align="left" class="auto-style6"></td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">Seleccione Colaborador:</td>
                    <td align="left" class="auto-style18">
                        <asp:DropDownList ID="cboColaboradores" runat="server"  Width="192px" CssClass="DropDownList">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">&nbsp;</td>
                    <td align="left" class="auto-style18">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Tipo de Asignacion:
                    </td>
                    <td align="left" class="auto-style8">
                        <asp:DropDownList ID="cboTipo" runat="server" CssClass="DropDownList"  Width="192px">
                            <asp:ListItem Value="0">--Seleccione--</asp:ListItem>
                            <asp:ListItem Value="1">Semanal</asp:ListItem>
                            <asp:ListItem Value="2">Mensual</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style9">
                        <asp:Label ID="lblMensajeDetalle" runat="server" CssClass="labelErrores" Width="583px"></asp:Label>
                    </td>
                </tr>
               
                     <tr>
                         <td class="auto-style4">
                             </td>
                         <td class="auto-style4">
                             </td>
                </tr>
              
                <tr>
                    <td class="auto-style26">&nbsp;</td>
                    <td class="auto-style26">&nbsp;</td>
                </tr>
              
                <tr>
                    <td class="center">
                        <asp:Button ID="btnGrabarDetalle" runat="server" OnClick="btnGrabarDetalle_Click" Text="Grabar" Width="100px" CssClass="boton2" />
                    </td>
                    <td class="center">
                        <asp:Button ID="btnCancelarDetalle" runat="server" Text="Cancelar" Width="100px" CssClass="boton-new" />
                    </td>
                </tr>
              
                <tr>
                    <td class="auto-style27"></td>
                    <td class="auto-style27"></td>
                </tr>
              
                <tr>
                    <td class="auto-style27">&nbsp;</td>
                    <td class="auto-style27">&nbsp;</td>
                </tr>
              
            </table>
                        
        </asp:Panel>
            <%--El modalpoput extender : vease el TargetControl que apunta al linkbutton y el popuconttol ID que apunhta al panel--%> 
      <ajaxToolkit:ModalPopupExtender ID="PopDetalle" runat="server" BackgroundCssClass="FondoAplicacion"  
        TargetControlID="lnkDetalle" PopupControlID="PanelDetalle"  >
    </ajaxToolkit:ModalPopupExtender>
  
    <%--Este es el popup que contiene los mensajes de error--%>
             <%--el link button o cualquiero otro control para el manejo del modal--%>
              <asp:LinkButton ID="lnkMensaje" runat="server" ></asp:LinkButton>
             <%--El  panel con el contenido del mensaje--%>
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
               <%--Este es el popup que contiene la grabacion de la OC y adjuntar la proforma--%>
             <%--el link button o cualquiero otro control para el manejo del modal--%>
              <asp:LinkButton ID="lnkOCompra" runat="server" ></asp:LinkButton>
             <%--El  panel con el contenido del mensaje--%>
               <asp:Panel ID="pnlOCompra" runat="server" CssClass="CajaDialogo" Style="display: normal;" Width="700px"> 
                   
                                 <table border="0" width="700px" style="margin: 0px; padding: 0px; background-color:darkred ; 
                        color: #FFFFFF;" > 
                        <tr> 
                            <td align="center" class="auto-style4" > 
                                &nbsp;<asp:Label ID="Label1" runat="server" Text="Grabar OC" /> 
                            </td> 
                            <td width="12%" class="center"> 
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;" 
                                    ImageAlign="Right" /> 
                            </td> 
                        </tr> 
                         
                    </table> 
                      <table style="border: Solid 3px #D55500;"
                cellpadding="0" cellspacing="0" width="700px">
                
                <tr>
                    <td align="right" class="auto-style5">
                        &nbsp;</td>
                      <td align="left" class="auto-style3">
                          &nbsp;</td>
                </tr>
                          <tr>
                              <td align="right" class="auto-style5"></td>
                              <td align="left" class="auto-style3"></td>
                          </tr>
                <tr>
                    <td align="right" class="labelContenido">Adjunte proforma:</td>
                    <td align="left" class="auto-style3">
                        <asp:FileUpload ID="fulOC" runat="server" />
                    </td>
                </tr>
                          <tr>
                              <td align="right" class="labelContenido">&nbsp;</td>
                              <td align="left" class="auto-style3">&nbsp;</td>
                          </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:Label ID="lblGrabarOC" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                    </td>
                </tr>
               
                     <tr>
                         <td class="auto-style26">
                             </td>
                         <td class="auto-style3">
                             </td>
                </tr>
              
                          <tr>
                              <td class="auto-style26">&nbsp;</td>
                              <td class="auto-style3">&nbsp;</td>
                          </tr>
              
                <tr>
                    <td class="center">
                        <asp:Button ID="btnGrabarOC" runat="server" CssClass="boton2" OnClick="btnGrabarOC_Click" Text="Grabar" Width="100px" />
                    </td>
                    <td class="auto-style3">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="Cancelar" Width="100px" CssClass="boton-new" />
                    </td>
                </tr>
              
                <tr>
                    <td class="auto-style27"></td>
                    <td class="auto-style3"></td>
                </tr>
              
                          <tr>
                              <td class="auto-style27">&nbsp;</td>
                              <td class="auto-style3">&nbsp;</td>
                          </tr>
              
            </table>
                </asp:Panel> 
            <ajaxToolkit:ModalPopupExtender ID="PopOCompra" runat="server" TargetControlID="lnkOCompra" 
                    PopupControlID="pnlOCompra" BackgroundCssClass="FondoAplicacion" OkControlID="btnAceptar" 
                     />
     </ContentTemplate>
    </asp:UpdatePanel>
  
</asp:Content>


