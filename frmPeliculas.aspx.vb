Public Class frmPeliculas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged



    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim nombreComando As String = e.CommandName

        Dim selectdIndex As Integer = Convert.ToInt32(e.CommandArgument)

        If nombreComando = "btnAlquilar" Then

            Dim peliculaId As Integer = CInt(GridView1.DataKeys(selectdIndex).Item("PeliculaId"))



        End If
    End Sub
End Class