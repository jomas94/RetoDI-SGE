<%@ Page Language="vb" 
    AutoEventWireup="false" 
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmPrincipal.aspx.vb" 
    Inherits="RetoDI_SGE.frmPrincipal" %>


    
<asp:Content ID="menuPrincipal" ContentPlaceHolderID="ContentPlaceMenu" runat="server">
   <form id="form1" runat="server">
       <div class="container principal">
           <asp:Image ImageUrl="~\imagenes\upFlix.png" runat="server" />
       </div>
        <%--   <asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#FFFBD6" />
                <DynamicSelectedStyle BackColor="#FFCC66" />
                <Items>
                    <asp:MenuItem Text="Peliculas" Value="Peliculas" NavigateUrl="~/frmPeliculas.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Cesta de Compra" Value="Cesta de Compra" NavigateUrl="~/frmCesta.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Cambiar Contraseña" Value="Cambiar Contraseña" NavigateUrl="~/frmChangePassword.aspx"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <StaticSelectedStyle BackColor="#FFCC66" />
            </asp:Menu>
           --%>
    </form>
</asp:Content>
