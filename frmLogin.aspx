<%@ Page Language="vb"
    AutoEventWireup="false"
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmLogin.aspx.vb"
    Inherits="RetoDI_SGE.frmLogin" %>


<asp:Content ID="miLogin" ContentPlaceHolderID="ContentPlaceHolderLogin" runat="server">

    <form id="form1" runat="server">
        <div>
            <asp:Login ID="Login1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            </asp:Login>
        
        </div>
    </form>
 </asp:Content>

