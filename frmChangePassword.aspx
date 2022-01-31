<%@ Page Language="vb" 
    AutoEventWireup="false"
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmChangePassword.aspx.vb"
    Inherits="RetoDI_SGE.frmChangePassword" %>

<asp:Content ID="menuUsuario" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>

            <div class="row">
                <div class="col-lg-12">
                    <h3>CAMBIAR CONTRASEÑA</h3>

                </div>
            </div>
            <br />
            <br />
          
            <p>Introduzca la nueva Contraseña</p>
            <div class="row">
                
                <div class="col-lg-12">
                    <asp:TextBox ID="txtNewPassword" CssClass="form-control" runat="server" Width="200px" placeholder="Introduzca la contraseña"></asp:TextBox>

                </div>

            </div>
            <br />
             <div class="row">
                
                <div class="col-lg-12">
                     
                    <asp:TextBox ID="txtNewPasswordDupe" CssClass="form-control" runat="server" Width="200px" placeholder="Repita la contraseña"></asp:TextBox>

                </div>

            </div>            
            <br />
            <asp:Button ID="btnCambiarPass" runat="server" CssClass="btn-second" Text="Cambiar Contraseña" />
        </div>
    </form>
</asp:Content>
