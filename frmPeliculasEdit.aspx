<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmPeliculasEdit.aspx.vb" Inherits="RetoDI_SGE.frmPeliculasEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="TITULO"></asp:Label>
            <br />
            <asp:Label ID="lblCodigoPeli" runat="server" Visible="False"></asp:Label>
        </div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                <asp:BoundField DataField="Duracion" HeaderText="Duracion" SortExpression="Duracion" />
                <asp:BoundField DataField="CodGenero" HeaderText="CodGenero" SortExpression="CodGenero" />
                <asp:BoundField DataField="Anyo" HeaderText="Anyo" SortExpression="Anyo" />
                <asp:BoundField DataField="Productora" HeaderText="Productora" SortExpression="Productora" />
                <asp:BoundField DataField="Pais" HeaderText="Pais" SortExpression="Pais" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                <asp:BoundField DataField="Director" HeaderText="Director" SortExpression="Director" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT [Titulo], [Duracion], [CodGenero], [Anyo], [Productora], [Pais], [Precio], [Director] FROM [Peliculas] WHERE [PeliculaId] = ? ">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblCodigoPeli" Name="?" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" Text="Volver" />
    </form>
</body>
</html>
