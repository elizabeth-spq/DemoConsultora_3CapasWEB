<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="WebMantClientes.aspx.cs" Inherits="SitioWEB_ConsultoraGUI.Mantenimientos.WebMantClientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" tagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 36px;
        }
        .auto-style3 {
            width: 70%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" Runat="Server">
    <%-- PLANTILLA PARA LA INSERCION DEL REGISTRO --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
       
            <%--Aqui va el titulo del formulario--%>
            <div>
                <p class="tituloForm">MANTENIMIENTO DE CLIENTES</p>
            </div>

               <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo cliente" OnClick="btnNuevo_Click" CssClass="boton2" />
            <br />

             <%--El grid view para el listado de registros, recuerde implementar la primera columna de tipo Button, con el CommanName (recomendado) Editar
                   y con un icono asociado a la accion de editar y formatear las columnas que desea mostrar--%>
            <br />
            <table class="auto-style3">
                <tr>
                    <td class="labelContenido">Ingrese razon social:</td>
                    <td>
                        <asp:TextBox ID="txtFiltro" runat="server" CssClass="TextBox" Width="255px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="btnFiltrar" runat="server" ImageUrl="~/Images/Buscar.png" OnClick="btnFiltrar_Click" style="width: 16px" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="grvClientes" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="1031px" AutoGenerateColumns="False" CssClass="GriedView" AllowPaging="True" OnPageIndexChanging="grvClientes_PageIndexChanging" OnRowCommand="grvClientes_RowCommand" OnRowDataBound="grvClientes_RowDataBound" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Images/Editar.png" Text="Botón" />
                    <asp:BoundField DataField="Cod_Cli" HeaderText="Código" />
                    <asp:BoundField DataField="Nom_Cli" HeaderText="Nombre Cliente" />
                    <asp:BoundField DataField="Tipo_Documento" HeaderText="Tipo Doc" />
                    <asp:BoundField DataField="Num_Doc_Cli" HeaderText="Nº Doc" />
                    <asp:BoundField DataField="Tel_Cli" HeaderText="Teléfono" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo Cliente" />
                    <asp:BoundField DataField="Antiguedad" HeaderText="Antiguedad (Años)" />
                    
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
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
                        Nuevo cliente
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
                        Razon social:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRS1" runat="server" Width="350px" CssClass="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Direccion:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDir1" runat="server" Width="487px" CssClass="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Telefono:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTel1" runat="server" Width="150px" CssClass="TextBox" />
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="labelContenido">RUC: </td>
                         <td align="left">
                             <asp:TextBox ID="txtRUC1" runat="server" CssClass="TextBox" Width="150px" />
                         </td>
                     </tr>
                     <tr>
                         <td align="right" class="labelContenido">Departamento:</td>
                         <td align="left">
                             <asp:DropDownList ID="cboDepartamento1" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cboDepartamento1_SelectedIndexChanged">
                             </asp:DropDownList>
                         </td>
                  </tr>
                  <tr>
                         <td align="right" class="labelContenido">Provincia:</td>
                         <td align="left">
                             <asp:DropDownList ID="cboProvincia1" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cboProvincia1_SelectedIndexChanged">
                             </asp:DropDownList>
                         </td>
                  </tr>
                  <tr>
                         <td align="right" class="labelContenido">Distrito:</td>
                         <td align="left">
                             <asp:DropDownList ID="cboDistrito1" runat="server" Width="300px">
                             </asp:DropDownList>
                         </td>
                  </tr>
                     <tr>
                         <td align="right" class="labelContenido">Representante de ventas:</td>
                         <td align="left">
                             <asp:TextBox ID="txtRepVen1" runat="server" CssClass="TextBox" Width="150px" />
                         </td>
                  </tr>
                  <tr>
                      <td align="right" class="labelContenido">Estado:</td>
                      <td align="left">
                          <asp:CheckBox ID="chkEstado1" runat="server" CssClass="labelTitulo" Text="Activo" />
                      </td>
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
                             <asp:Button ID="btnGrabar1" runat="server" Text="Grabar" Width="100px" CssClass="boton" OnClick="btnGrabar1_Click" />
                             &nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnCerrar1" runat="server"  Text="Cancelar" Width="100px" CssClass="boton" />
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
                        Actualizar cliente
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
                        <asp:Label ID="lblEtiquetaCod" runat="server" Text="Codigo:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblCod" runat="server" CssClass="labelTitulo"></asp:Label>
                    </td>
                </tr>
               <tr>
                    <td align="right" class="labelContenido">
                        Razon social:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRS2" runat="server" Width="350px" CssClass="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Direccion:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDir2" runat="server" Width="487px" CssClass="TextBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="labelContenido">
                        Telefono:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTel2" runat="server" Width="150px" CssClass="TextBox" />
                    </td>
                </tr>
               
                     <tr>
                         <td align="right" class="labelContenido">RUC: </td>
                         <td align="left">
                             <asp:TextBox ID="txtRUC2" runat="server" CssClass="TextBox" Width="150px" />
                         </td>
                     </tr>
                     <tr>
                         <td align="right" class="labelContenido">Departamento:</td>
                         <td align="left">
                             <asp:DropDownList ID="cboDepartamento2" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cboDepartamento2_SelectedIndexChanged">
                             </asp:DropDownList>
                         </td>
                  </tr>
                  <tr>
                         <td align="right" class="labelContenido">Provincia:</td>
                         <td align="left">
                             <asp:DropDownList ID="cboProvincia2" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cboProvincia2_SelectedIndexChanged">
                             </asp:DropDownList>
                         </td>
                  </tr>
                  <tr>
                         <td align="right" class="labelContenido">Distrito:</td>
                         <td align="left">
                             <asp:DropDownList ID="cboDistrito2" runat="server" Width="300px">
                             </asp:DropDownList>
                         </td>
                  </tr>
                     <tr>
                         <td align="right" class="labelContenido">Representante de ventas:</td>
                         <td align="left">
                             <asp:TextBox ID="txtRepVen2" runat="server" CssClass="TextBox" Width="150px" />
                         </td>
                  </tr>
                  <tr>
                      <td align="right" class="labelContenido">Estado:</td>
                      <td align="left">
                          <asp:CheckBox ID="chkEstado2" runat="server" CssClass="labelTitulo" Text="Activo" />
                      </td>
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
                             <asp:Button ID="btnGrabar2" runat="server" Text="Grabar" Width="100px" CssClass="boton" OnClick="btnGrabar2_Click" />
                             &nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnCerrar2" runat="server"  Text="Cancelar" Width="100px" CssClass="boton" />
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
