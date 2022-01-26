Public Class WebApp
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Salir()

        Session.Abandon()
        FormsAuthentication.SignOut()
        Response.Redirect("frmPrincipal.aspx")

    End Sub

End Class