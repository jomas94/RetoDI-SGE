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

    Function ValidatePassword(ByVal pwd As String,
    Optional ByVal minLength As Integer = 8,
    Optional ByVal numUpper As Integer = 1,
    Optional ByVal numLower As Integer = 1,
    Optional ByVal numNumbers As Integer = 1,
    Optional ByVal numSpecial As Integer = 1) As Boolean

        ' Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above".
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        ' Check the length.
        If Len(pwd) < minLength Then Return False
        ' Check for minimum number of occurrences.
        If upper.Matches(pwd).Count < numUpper Then Return False
        If lower.Matches(pwd).Count < numLower Then Return False
        If number.Matches(pwd).Count < numNumbers Then Return False
        If special.Matches(pwd).Count < numSpecial Then Return False

        ' Passed all checks.
        Return True

    End Function

    Protected Sub btnCambiarPass_Click(sender As Object, e As EventArgs) Handles btnCambiarPass.Click

        If txtNewPassword.Text.Equals(txtNewPasswordDupe.Text) Then

            If ValidatePassword(txtNewPassword.Text, 8, 1, 1, 1, 1) = True Then

                CambiarPass(txtNewPasswordDupe.Text)

                txtNewPassword.Text = ""

                txtNewPasswordDupe.Text = ""

            Else

                txtNewPassword.Text = ""

                txtNewPasswordDupe.Text = ""

            End If

        Else

            txtNewPassword.Text = ""

            txtNewPasswordDupe.Text = ""

        End If

    End Sub

    Protected Sub CambiarPass(newPassword As String)

        Dim id As Integer = HttpContext.Current.Session("userID")

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

        Dim sql As String = "UPDATE Clientes SET [Password] = '" & newPassword & "' WHERE [ClienteId] = " & id & ";"

        Try
            _OleDbConnection.Open()
            Dim cmd As OleDbCommand = New OleDbCommand(sql, _OleDbConnection)
            cmd.ExecuteNonQuery()


        Catch ex As Exception

        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try

    End Sub

End Class