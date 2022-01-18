<%@ Page Language="vb" 
    AutoEventWireup="false" 
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmPrincipal.aspx.vb" 
    Inherits="RetoDI_SGE.frmPrincipal" %>


    
<asp:Content ID="contenido" ContentPlaceHolderID="ContentPlaceHolderLogin" runat="server" >
    <h1>Estoy en principal</h1>
</asp:Content>

<asp:Content ID="titulo" ContentPlaceHolderID="ContentHeader" runat="server">
    <asp:Menu ID="Menu1" runat="server">
        </asp:Menu><form id="form1" runat="server">
        
        <h1>Estoy en el frmPirncipal.aspx</h1>
    </form>
</asp:Content>