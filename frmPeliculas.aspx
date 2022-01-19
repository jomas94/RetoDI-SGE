<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmPeliculas.aspx.vb" Inherits="RetoDI_SGE.frmPeliculas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="165px" Width="311px">
                <Columns>
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                    <asp:BoundField DataField="Director" HeaderText="Director" SortExpression="Director" />
                    <asp:BoundField DataField="Duracion" HeaderText="Duracion" SortExpression="Duracion" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [Titulo], [Precio], [Director], [Duracion] FROM [Peliculas]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
