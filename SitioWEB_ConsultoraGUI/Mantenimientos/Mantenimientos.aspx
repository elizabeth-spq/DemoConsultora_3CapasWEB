<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="Mantenimientos.aspx.cs" Inherits="SitioVentasWEB_GUI.Mantenimientos.Mantenimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 997px;
    }
    .auto-style2 {
        width: 355px;
    }
</style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" Runat="Server">
    <table >
           <p class="tituloForm">MANTENIMIENTOS DE TABLAS MAESTRAS </p> 
        <tr>
            <td class="auto-style2">
                <asp:Image ID="Image1" runat="server" Height="285px" 
                    ImageUrl="~/Images/Mantenimientos.jpg" Width="335px" />
            </td>
            <td class="auto-style1">
                 
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="Faq">
                    <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                    <Nodes>
                        <asp:TreeNode Text="Mantenimientos" Value="Mantenimientos">
                            <asp:TreeNode NavigateUrl="~/Mantenimientos/WebMantClientes.aspx" Text="Mantenimiento Cliente" Value="Mantenimiento Cliente"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/Mantenimientos/WebMantProyectos.aspx" Text="Mantenimiento Proyecto" Value="Mantenimiento Proyecto"></asp:TreeNode>
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

