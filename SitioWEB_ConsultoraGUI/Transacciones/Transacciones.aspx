<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="Transacciones.aspx.cs" Inherits="SitioVentasWEB_GUI.Transacciones.Transacciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 1220px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" Runat="Server">
    <table >
        <p class="tituloForm">TRANSACCIONES DEL SISTEMA </p>
        <tr>
            <td width ="180px">
                <asp:Image ID="Image1" runat="server" Height="285px" 
                    ImageUrl="~/Images/Transacciones.jpg" Width="274px" />
            </td>
            <td class="auto-style1">
                
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="Faq">
                    <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                    <Nodes>
                        <asp:TreeNode Text="Transacciones" Value="Transacciones">
                            <asp:TreeNode NavigateUrl="~/Transacciones/RegistrarAsignacion.aspx" Text="Registrar Asignaciones" Value="Registrar Asignaciones"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/Transacciones/WebListarAsignaciones.aspx" Text="Listar Asignaciones" Value="Listar Asignaciones"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="DarkBlue" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
                
            </td>
        </tr>
    </table>


</asp:Content>
