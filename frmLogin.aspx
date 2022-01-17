<%@ Page Language="vb"
    AutoEventWireup="false"
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmLogin.aspx.vb"
    Inherits="RetoDI_SGE.frmLogin" %>


<asp:Content ID="miLogin" ContentPlaceHolderID="ContentPlaceHolderLogin" runat="server">

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="LOGIN"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="User:"></asp:Label>
    
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
   
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Button runat="server" Text="LOG IN" />
            </div>
    </form>
 </asp:Content>

