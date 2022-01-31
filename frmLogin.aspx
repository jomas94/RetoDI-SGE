<%@ Page Language="vb"
    AutoEventWireup="false"
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmLogin.aspx.vb"
    Inherits="RetoDI_SGE.frmLogin" %>


<asp:Content ID="miLogin" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

        <div class="row">
                <div class="col-lg-12">
                    <h3>LOGIN</h3>

                </div>
            </div>

        <div class="row" >
            <div class="col-lg-12">

                <asp:Login ID="Login1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop">
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                    <TextBoxStyle Font-Size="0.8em" />
                    <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
                </asp:Login>
        
            </div>
        </div>
    </form>


 <%--   <form  id="form1" runat="server" >
            <div class="login100-form">    
    <span class="login100-form-title p-b-49">
        Login
    </span>

    <div class="wrap-input100 m-b-23">
        <span class="label-input100">Email</span>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <span class="focus-input100"></span>
    </div>

    <div class="wrap-input100">
        <span class="label-input100">Password</span>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server"></asp:PasswordRecovery>
        <span class="focus-input100"></span>
    </div>
    
    <div class="text-right p-t-8 p-b-31"></div>
    
    <div class="container-login100-form-btn">
        <div class="wrap-login100-form-btn">
            <div class="login100-form-bgbtn"></div>
            <button class="login100-form-btn" type="submit" [disabled]="myForm.invalid">
                Login
            </button>
        </div>
    </div>


    </div>
</form>--%>

 </asp:Content>

