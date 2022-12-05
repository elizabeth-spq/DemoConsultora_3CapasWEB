<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="WebAsignacionProyecto.aspx.cs" Inherits="SitioWEB_ConsultoraGUI.Consultas.WebAsignacionProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-family: Verdana;
            font-size: 10pt;
            color: #993366;
            height: 27px;
        }

        .auto-style2 {
            height: 27px;
        }

        .auto-style3 {
            font-family: Verdana;
            font-size: 8pt;
            font-weight: bold;
            height: 17px;
        }

        .auto-style4 {
            text-align: center;
            height: 27px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <p class="tituloForm">
        <br />
        CONSULTA DE ASIGNACIONES POR PROYECTO ENTRE FECHAS
    </p>
    <table width="1000px">
        <tr>
            <td class="labelContenido">Código Proyecto:</td>
            <td width="150px" class="auto-style5">
                <asp:TextBox ID="txtCod" runat="server" CssClass="TextBoxDerecha" MaxLength="4" Width="70px"></asp:TextBox>
                &nbsp;
                <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Images/Buscar.png" OnClick="btnBuscar_Click" Style="width: 16px" CausesValidation="False" />
            </td>
            <td class="auto-style4"></td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="labelContenido">Nombre</td>
            <td colspan="3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBoxDerecha" Width="750px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelContenido">Area:</td>
            <td>
                <asp:DropDownList ID="cboArea" runat="server" Height="20px" ReadOnly="True" Width="300px" EnableTheming="True">
                </asp:DropDownList>
            </td>
            <td class="labelContenido">
                <asp:TextBox ID="txtArea" runat="server" Visible="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">Tipo de proyecto:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtTip" runat="server" CssClass="TextBoxDerecha" Width="300px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="auto-style1">&nbsp;Estado del proyecto:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtEstado" runat="server" CssClass="TextBoxDerecha" Width="173px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelContenido">Presupuesto Inicial:</td>
            <td class="auto-style1">
                <asp:TextBox ID="txtPresu" runat="server" CssClass="TextBoxDerecha" Width="120px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="labelContenido"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="4">INGRESE FECHAS DE CONSULTA ( * Obligatorios):</td>
        </tr>
        <tr>
            <td class="auto-style1">Fecha inicio (*):</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtFecIni" runat="server" CssClass="TextBoxDerecha" Width="100px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFecIni_CalendarExtender" runat="server" BehaviorID="txtFecIni_CalendarExtender" TargetControlID="txtFecIni" />
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecIni" CssClass="labelErrores" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style1">Fecha fin (*):</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtFecFin" runat="server" CssClass="TextBoxDerecha" Width="100px"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFecFin_CalendarExtender" runat="server" BehaviorID="txtFecFin_CalendarExtender" TargetControlID="txtFecFin" />
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecFin" CssClass="labelErrores" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style4">
                <asp:Button ID="btnConsultar" runat="server" CssClass="boton2" OnClick="btnConsultar_Click" Text="Consultar" />
            </td>
            <td class="auto-style2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style1">
                <asp:Label ID="lblRegistros" runat="server" CssClass="labelErrores"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Consultas/Consultas.aspx">Retornar</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <asp:GridView ID="grvAsignaciones" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="1155px" CssClass="GriedView" ShowHeaderWhenEmpty="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Cod_Asig" HeaderText="Codigo Asignacion" />
            <asp:BoundField DataField="Ape_Col" HeaderText="Ape Colaborador" />
            <asp:BoundField DataField="Nom_Col" DataFormatString="{0:d}" HeaderText="Nom Colaborador" />
            <asp:BoundField DataField="Fec_Asig" DataFormatString="{0:d}" HeaderText="Fec. asignacion" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="Tar_Asig" HeaderText="Tarifa (S/.)" />
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
    <%--Este es el modal popup  que contiene los mensajes --%>
    <%--1 Control target (cualquier control)--%>
    <asp:LinkButton ID="lnkMensaje" runat="server"></asp:LinkButton>
    <%--2 el panel que se mostrara en el popup--%>
    <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal;" Width="500">
        <table border="0" width="500px" style="margin: 0px; padding: 0px; background-color: darkred; color: #FFFFFF;">
            <tr>
                <td align="center">
                    <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" />
                </td>
                <td width="12%" class="center">
                    <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;"
                        ImageAlign="Right" />
                </td>
            </tr>

        </table>
        <div>
            <br />
        </div>
        <div>
            <asp:Label ID="lblMensajePopup" runat="server" CssClass="labelTitulo" />
        </div>
        <div>
            <br />
        </div>
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CausesValidation="False" CssClass="boton-new" />
        </div>
        <div>
            <br />
        </div>
    </asp:Panel>
    <%--3 el Modal popup que hace referencia al control target  (1) y al panel (2)--%>
    <ajaxToolkit:ModalPopupExtender ID="PopMensaje" runat="server" TargetControlID="lnkMensaje"
        PopupControlID="pnlMensaje" BackgroundCssClass="FondoAplicacion" OkControlID="btnAceptar" />

</asp:Content>
