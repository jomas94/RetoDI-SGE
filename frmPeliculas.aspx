<%@ Page Language="vb"
    AutoEventWireup="false" 
    CodeBehind="frmPeliculas.aspx.vb"
    MasterPageFile="~/WebApp.Master"
    Inherits="RetoDI_SGE.frmPeliculas" %>

<asp:Content ID="formCesta" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2" runat="server" Text="PAIS:" Font-Overline="False" Font-Size="Larger" Font-Strikeout="False"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataMember="DefaultView" DataSourceID="SqlDataSource4" DataTextField="Pais" DataValueField="Pais" Font-Size="Larger">
            </asp:DropDownList>
            <br />
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT [Pais] FROM [Peliculas]"></asp:SqlDataSource>
            <asp:Label ID="Label1" runat="server" Text="GENEROS:" Font-Overline="False" Font-Size="Larger" Font-Strikeout="False"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataMember="DefaultView" DataSourceID="SqlDataSource2" DataTextField="Nombre" DataValueField="Nombre" Font-Size="Larger">
            </asp:DropDownList>
            <br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT DISTINCT [Nombre] FROM [Generos] WHERE [GeneroId] in (SELECT [CodGenero] FROM [Peliculas] WHERE ([Pais] LIKE '%' + ? + '%'))">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" DefaultValue="" Name="Pais" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Titulo,Duracion,Director,Precio" DataMember="DefaultView" DataSourceID="SqlDataSource3">
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Ver Datos" />
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                    <asp:BoundField DataField="Duracion" HeaderText="Duracion" SortExpression="Duracion" />
                    <asp:BoundField DataField="Director" HeaderText="Director" SortExpression="Director" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Comprar" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Alquilar" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [Titulo], [Duracion], [Director], [Precio] FROM [Peliculas] WHERE ([CodGenero] LIKE (SELECT [GeneroId] From Generos WHERE Nombre LIKE  '%' + ? + '%') AND [Pais]  LIKE  '%' + ? + '%') ">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="DropDownListGenero" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="DropDownList2" Name="newparameter" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
        </div>
    </form>

</asp:Content>