﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="WebMantProyectos.aspx.cs" Inherits="SitioWEB_ConsultoraGUI.Mantenimientos.WebMantProyectos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
        .auto-style5 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 36px;
            width: 347px;
        }
        .auto-style7 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 36px;
            width: 468px;
        }
        .auto-style8 {
            height: 308px;
            width: 700px;
        }
        .auto-style12 {
            width: 347px;
        }
        .auto-style13 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            width: 200px;
        }
        .auto-style14 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 36px;
            width: 200px;
        }
        .auto-style15 {
            font-family: Verdana;
            font-size: 10pt;
            color: black;
            margin-left: 0px;
        }
        .auto-style17 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 36px;
            width: 37%;
        }
        .auto-style18 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            width: 39%;
        }
        .auto-style19 {
            width: 468px;
        }
        .auto-style20 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            width: 37%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="Server">
    <%-- PLANTILLA PARA LA INSERCION DEL REGISTRO --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%--Aqui va el titulo del formulario--%>
            <div>
                <p class="tituloForm">MANTENIMIENTO DE PROYECTOS</p>
            </div>

            <%--Boton ( o link button ) para mostrar el modal de insercion PopMant del nuevo registro--%>
            <br />

            <%--El grid view para el listado de registros, recuerde implementar la primera columna de tipo Button, con el CommanName (recomendado) Editar
                   y con un icono asociado a la accion de editar y formatear las columnas que desea mostrar--%>
            <br />
            <table class="auto-style3">
                <tr>
                    <td class="labelContenido">Ingrese nombre del proyecto:</td>
                    <td>
                        <asp:TextBox ID="txtFiltro" runat="server" CssClass="TextBox" Width="255px"></asp:TextBox>
                        &nbsp;
                        <asp:ImageButton ID="btnFiltrar" runat="server" ImageUrl="~/Images/Buscar.png" OnClick="btnFiltrar_Click" Style="width: 16px" />
                    </td>
                    <td>
                        <asp:Button ID="btnNuevo" runat="server" CssClass="boton3" OnClick="btnNuevo_Click" Text="Nuevo proyecto" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="grvProyectos" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="1031px" AutoGenerateColumns="False" CssClass="GriedView" AllowPaging="True" OnPageIndexChanging="grvProyectos_PageIndexChanging" OnRowCommand="grvProyectos_RowCommand" OnRowDataBound="grvProyectos_RowDataBound" ShowHeaderWhenEmpty="True">
                <Columns>
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" ImageUrl="~/Images/Editar.png" Text="Botón" />
                    <asp:BoundField DataField="Cod_Proy" HeaderText="Código" />
                    <asp:BoundField DataField="Nom_Proy" HeaderText="Proyecto" />
                    <asp:BoundField DataField="Nom_Area" HeaderText="Área" />
                    <asp:BoundField DataField="Tipo_Proyecto" HeaderText="Tipo" />
                    <asp:BoundField DataField="Imp_Imp_Estm" HeaderText="Presupuesto Inicial" />
                    <asp:BoundField DataField="Estado_Proyecto" HeaderText="Estado" />
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
            <asp:Panel ID="PanelMan1" runat="server" CssClass="CajaDialogo" align="center" Style="display: table" Width="700">
                <table style="border: Solid 3px #336666; height: 308px;"
                    cellpadding="0" cellspacing="0">
                    <tr style="background-color: #336666">
                        <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                            align="center">Nuevo proyecto</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style20">&nbsp;</td>
                        <td align="left" class="auto-style19">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style20">Nombre:
                        </td>
                        <td align="left" class="auto-style19">
                            <asp:TextBox ID="txtNombre1" runat="server" Width="350px" CssClass="TextBox" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="right" class="auto-style20">Área:</td>
                        <td align="left" class="auto-style19">
                            <asp:DropDownList ID="cboArea1" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cboArea1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="auto-style20">Tipo Proyecto:</td>
                        <td align="left" class="auto-style19">
                            <asp:RadioButtonList ID="rdbListTip1" runat="server" CssClass="labelRadioButton">
                                <asp:ListItem Value="1">Facturable recurrente</asp:ListItem>
                                <asp:ListItem Value="2">Facturable no recurrente</asp:ListItem>
                                <asp:ListItem Value="3">Por horas trabajadas</asp:ListItem>
                                <asp:ListItem Value="4">No Facturable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style20">&nbsp;</td>
                        <td align="left" class="auto-style19">&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="auto-style20">Estado:</td>
                        <td align="left" class="auto-style19">
                            <asp:RadioButtonList ID="rdbListEstado1" runat="server" CssClass="auto-style15" Width="247px">
                                <asp:ListItem Value="0">Programado</asp:ListItem>
                                <asp:ListItem Value="1">En ejecucion</asp:ListItem>
                                <asp:ListItem Value="2">Detenido</asp:ListItem>
                                <asp:ListItem Value="3">Cancelado</asp:ListItem>
                                <asp:ListItem Value="4">Finalizado</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="auto-style20">Presupuesto:</td>
                        <td align="left" class="auto-style19">
                            <asp:TextBox ID="txtPresu1" runat="server" CssClass="TextBox" Width="150px" />
                        </td>
                    </tr>
                
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMensaje1" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">&nbsp;</td>
                        <td class="auto-style7">
                            <asp:Button ID="btnGrabar1" runat="server" Text="Grabar" Width="100px" CssClass="boton" OnClick="btnGrabar1_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnCerrar1" runat="server" Text="Cancelar" Width="100px" CssClass="boton" />
                        </td>
                    </tr>

                </table>

            </asp:Panel>
            <%--Modalpopup extender PopMan01 para nuevos registros : vease el TargetControl que apunta al linkbutton  lnkPopup1 
                  y el PopupcontrolID que apunta al panel PanelMan1--%>
            <ajaxToolkit:ModalPopupExtender ID="PopMan01" TargetControlID="lnkPopup1"
                PopupControlID="PanelMan1" runat="server" BackgroundCssClass="FondoAplicacion">
            </ajaxToolkit:ModalPopupExtender>



            <%-- PLANTILLA PARA LA EDICION DEL REGISTRO (incluye un label para el codigo o PK del registro)--%>
            <%--Control target del ModalPopup de edicion--%>
            <asp:LinkButton ID="lnkPopup2" runat="server"></asp:LinkButton>

            <%--Panel cuyo contenido de mostrara en el ModalPopup de Edicion--%>
            <asp:Panel ID="PanelMan2" runat="server" CssClass="CajaDialogo" align="center" Style="display: table" Width="700">
                <table style="border: Solid 3px #336666; "
                    cellpadding="0" cellspacing="0" class="auto-style8">
                    <tr style="background-color: #336666">
                        <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger"
                            align="center">Actualizar proyecto
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style13">&nbsp;</td>
                        <td align="left" class="auto-style12">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style13">
                            <asp:Label ID="lblEtiquetaCod" runat="server" Text="Codigo:"></asp:Label>
                        </td>
                        <td align="left" class="auto-style12">
                            <asp:Label ID="lblCod" runat="server" CssClass="labelTitulo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style13">Nombre:
                        </td>
                        <td align="left" class="auto-style12">
                            <asp:TextBox ID="txtNombre2" runat="server" Width="350px" CssClass="TextBox" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td align="right" class="auto-style13">Área:</td>
                        <td align="left" class="auto-style12">
                            <asp:DropDownList ID="cboArea2" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="cboArea2_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="auto-style13">Tipo Proyecto:</td>
                        <td align="left" class="auto-style12">
                            <asp:RadioButtonList ID="rdbListTip2" runat="server" CssClass="labelRadioButton">
                                <asp:ListItem Value="1">Facturable recurrente</asp:ListItem>
                                <asp:ListItem Value="2">Facturable no recurrente</asp:ListItem>
                                <asp:ListItem Value="3">Por horas trabajadas</asp:ListItem>
                                <asp:ListItem Value="4">No Facturable</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style13">&nbsp;</td>
                        <td align="left" class="auto-style12">&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="auto-style13">Estado:</td>
                        <td align="left" class="auto-style12">
                            <asp:RadioButtonList ID="rdbListEstado2" runat="server" CssClass="labelRadioButton">
                                <asp:ListItem Value="0">Programado</asp:ListItem>
                                <asp:ListItem Value="1">En ejecucion</asp:ListItem>
                                <asp:ListItem Value="2">Detenido</asp:ListItem>
                                <asp:ListItem Value="3">Cancelado</asp:ListItem>
                                <asp:ListItem Value="4">Finalizado</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right" class="auto-style13">Presupuesto:</td>
                        <td align="left" class="auto-style12">
                            <asp:TextBox ID="txtPresu2" runat="server" CssClass="TextBox" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMensaje2" runat="server" CssClass="labelErrores" Width="400px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style5">
                            <asp:Button ID="btnGrabar2" runat="server" Text="Grabar" Width="100px" CssClass="boton" OnClick="btnGrabar2_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnCerrar2" runat="server" Text="Cancelar" Width="100px" CssClass="boton" />
                        </td>
                    </tr>

                </table>
            </asp:Panel>
            <%--Modalpopup extender PopMan02 para el edicion de registros: vease el TargetControl que apunta al linkbutton  lnkPopup2 y el PopupcontrolID que apunta al panel PanelMan2--%>
            <ajaxToolkit:ModalPopupExtender ID="PopMan02" TargetControlID="lnkPopup2"
                PopupControlID="PanelMan2" runat="server" BackgroundCssClass="FondoAplicacion">
            </ajaxToolkit:ModalPopupExtender>

            <%--CONFIGURACION DEL MODALPOPUP DE MENSAJES --%>
            <%--Control target para el ModalPopup de mensajes--%>
            <asp:LinkButton ID="lnkMensaje" runat="server"></asp:LinkButton>
            <%-- El panel cuyo contenido se mostrara en el ModalPopup de mensajes--%>
            <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal;" Width="500">
                <table border="0" width="500px" style="margin: 0px; padding: 0px; background-color: #336666; color: #FFFFFF;">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" />
                        </td>
                        <td width="12%" class="auto-style1">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;"
                                ImageAlign="Right" />
                        </td>
                    </tr>

                </table>
                <div>
                    <asp:Label ID="lblMensajePopup" runat="server" ForeColor="Black" CssClass="labelTitulo" />
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
                PopupControlID="pnlMensaje" runat="server" BackgroundCssClass="FondoAplicacion">
            </ajaxToolkit:ModalPopupExtender>
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
