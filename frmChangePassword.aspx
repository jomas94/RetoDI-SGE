<%@ Page Language="vb" 
    AutoEventWireup="false"
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmChangePassword.aspx.vb"
    Inherits="RetoDI_SGE.frmChangePassword" %>

<asp:Content ID="menuUsuario" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="CAMBIAR CONTRASEÑA"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="introduzca la nueva Contraseña"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtNewPassword" runat="server" Width="155px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Vuelva ha Introduzir la nueva Contraseña"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtNewPasswordDupe" runat="server" Width="155px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnCambiarPass" runat="server" Text="Cambiar Contraseña" />
        </div>
    </form>
</asp:Content>
