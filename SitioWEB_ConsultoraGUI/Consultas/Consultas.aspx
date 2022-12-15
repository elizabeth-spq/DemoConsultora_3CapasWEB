<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="SitioVentasWEB_GUI.Consultas.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" Runat="Server">
    &nbsp;<table >
        <p class="tituloForm">CONSULTAS DEL SISTEMA </p>
        <tr>
            <td class="style2">
                <asp:Image ID="Image1" runat="server" Height="267px" 
                    ImageUrl="~/Images/Consultas.jpg" Width="274px" />
            </td>
            <td>
                
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="Faq">
                    <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                    <Nodes>
                        <asp:TreeNode Text="Consultas" Value="Consultas">
                            <asp:TreeNode NavigateUrl="~/Consultas/WebAsignacionProyecto.aspx" Text="Asignaciones por proyecto" Value="Asignaciones por proyecto"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/Consultas/WebColaboradoresPaginada.aspx" Text="Lista Colaboradores Paginada" Value="Lista Colaboradores Paginada"></asp:TreeNode>
                            <asp:TreeNode NavigateUrl="~/Consultas/WebGraficosProyectos.aspx" Text="Gráficos" Value="Gráficos"></asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="DarkBlue" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
                
            </td>
        </tr>
    </table>
&nbsp;
</asp:Content>


