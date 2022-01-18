Imports System.Data.OleDb
Public Class frmChangePassword
    Inherits System.Web.UI.Page

    Private _OleDbConnection As OleDbConnection
    Public Property OleDbConnection() As OleDbConnection
        Get
            Return _OleDbConnection
        End Get
        Set(ByVal value As OleDbConnection)
            _OleDbConnection = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub

    Protected Sub btnCambiarPass_Click(sender As Object, e As EventArgs) Handles btnCambiarPass.Click

        If txtNewPassword.Text.Equals(txtNewPasswordDupe.Text) Then



        End If

    End Sub

    Protected Sub CambiarPass(newPassword As String)

        Dim id As Integer = HttpContext.Current.Session("UserId")

        Dim User_Exist As Boolean = False

        Dim fileName As String
        Dim path As String = AppDomain.CurrentDomain.BaseDirectory
        path = System.IO.Path.Combine(path, "App_Data", "EMPRESA.mdb")


        fileName = path

        Dim cnnString As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", fileName)
        OleDbConnection = New OleDbConnection(cnnString)

        Try
            OleDbConnection.Open()
            If OleDbConnection.State = System.Data.ConnectionState.Open Then

            End If
        Catch ex As Exception

        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try

        Dim sql As String = "UPDATE CLientes Set Password = '" & newPassword & "' WHERE ClienteId = '" & id & "'"

        Dim cmd As OleDbCommand = New OleDbCommand(sql, _OleDbConnection)

        Try
            _OleDbConnection.Open()
            ' Dim numRegistrosAfectados = cmd.ExecuteScalar

        Catch ex As Exception

        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try

    End Sub

End Class