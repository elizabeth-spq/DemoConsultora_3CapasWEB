<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="WebGraficosProyectos.aspx.cs" Inherits="SitioWEB_ConsultoraGUI.Consultas.WebGraficosProyectos" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
        .auto-style2 {
            height: 404px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <p class="tituloForm">Grafico de Proyectos por Año</p>
    <p class="tituloForm">
        <asp:Label ID="lblMensaje" runat="server" CssClass="labelErrores"></asp:Label>
    </p>
    <table class="auto-style1">
        <tr>
            <td colspan="2" aling="center">
                <asp:GridView ID="grvProyectos" runat="server" CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="False" Width="770px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellSpacing="2" HorizontalAlign="Center">
                    <Columns>
                        <asp:BoundField DataField="Año" HeaderText="Año">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total" DataFormatString="{0:n}" HeaderText="Total (S/.)">
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CantProyectos" HeaderText="CantProyectos" FooterStyle-HorizontalAlign="Right">
                            <FooterStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Chart ID="grafTotales" runat="server" aling="center" CssClass="GriedView" Palette="EarthTones" Width="600px">
                    <Series>
                        <asp:Series Name="Series1" ChartType="StackedColumn">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Font="Microsoft YaHei, 8pt, style=Bold" Name="Title1" BackColor="224, 224, 224" Text="Costo Total de proyectos">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
            </td>
            <td class="auto-style2">
                <asp:Chart ID="grafCanti" runat="server"  CssClass="GriedView">
                    <Series>
                        <asp:Series Name="Series1" YValuesPerPoint="2">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                        <asp:Title Font="Microsoft Sans Serif, 8pt, style=Bold" Name="Title1" BackColor="224, 224, 224" Text="Cantidad de proyectos">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style2" aria-label="center">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
