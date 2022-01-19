<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmChangePassword.aspx.vb" Inherits="RetoDI_SGE.frmChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
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
</body>
</html>
