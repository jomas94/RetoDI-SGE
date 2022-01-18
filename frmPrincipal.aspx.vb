Public Class frmPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim estaLogeado As Boolean

        estaLogeado = HttpContext.Current.User.Identity.IsAuthenticated
        If Not estaLogeado Then
            FormsAuthentication.RedirectToLoginPage()
        End If

    End Sub

End Class