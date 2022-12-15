<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="SitioWEB_ConsultoraGUI.MenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 14px;
        }
        .auto-style3 {
            font-size: x-large;
            color: #FF5050;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" Runat="Server">
    <p class="auto-style3">
        <strong>MENU PRINCIPAL - MODULO CONSULTORA</strong></p>
    <p>
        &nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td class="auto-style2" rowspan="3">
                <asp:Image ID="Image1" runat="server" Height="284px" ImageUrl="~/Images/Ventas.jpg" Width="311px" />
            </td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Mantenimientos/Mantenimientos.aspx">Mantenimientos</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Consultas/Consultas.aspx">Consultas</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Transacciones/Transacciones.aspx">Transacciones</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>

