Public Class frmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    End Sub


    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate

        If Me.Login1.UserName = "Jomario" And Me.Login1.Password = "1234" Then
            'e.Authenticated = True
            'Response.Redirect("frmPrincipal.aspx")

            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
        End If

    End Sub

End Class