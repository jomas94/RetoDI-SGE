<%@ Page Language="vb" 
    AutoEventWireup="false" 
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmPrincipal.aspx.vb" 
    Inherits="RetoDI_SGE.frmPrincipal" %>


<asp:Content ID="cabecera" ContentPlaceHolderID="ContentPlaceHeader" runat="server">
    <div id="header">
        <h2> Web App</h2>
        <div style="width:100px">
            <asp:Image ImageUrl=".\imagenes\clapperboard.png" runat="server" />

        </div>
    </div>
</asp:Content>


    
<asp:Content ID="menuPrincipal" ContentPlaceHolderID="ContentPlaceMenu" runat="server">
   <form id="form1" runat="server">
    
           <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#FFFBD6" />
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <Items>
                    <asp:MenuItem Text="Peliculas" Value="Peliculas"></asp:MenuItem>
                    <asp:MenuItem Text="Cesta de Compra" Value="Cesta de Compra"></asp:MenuItem>
                    <asp:MenuItem Text="Cambiar Contraseña" Value="Cambiar Contraseña"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#FFCC66" />
            </asp:Menu>
           
    </form>
</asp:Content>

<%--<asp:Content ID="menuUsuario" ContentPlaceHolderID="ContentPlaceMenuUsuario" runat="server">
   <form id="form2" runat="server">
      
           <asp:Menu ID="Menu2" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#FFFBD6" />
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <Items>
                    <asp:MenuItem Text="Peliculas" Value="Peliculas"></asp:MenuItem>
                    <asp:MenuItem Text="Cesta de Compra" Value="Cesta de Compra"></asp:MenuItem>
                    <asp:MenuItem Text="Cambiar Contraseña" Value="Cambiar Contraseña"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#FFCC66" />
            </asp:Menu>   
    </form>
</asp:Content>--%>