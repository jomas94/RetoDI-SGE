Imports System.Data.OleDb

Public Class frmLogin
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

        Me.Master.FindControl("ContentPlaceMainPage").Visible = True

    End Sub


    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate

        If Validar_User(Me.Login1.UserName, Me.Login1.Password) = True Then

            'e.Authenticated = True
            'Response.Redirect("frmPrincipal.aspx")

            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)

        End If

        'If Me.Login1.UserName = "Jomario" And Me.Login1.Password = "1234" Then
        'e.Authenticated = True
        'Response.Redirect("frmPrincipal.aspx")

        'FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
        '   End If

    End Sub

    Protected Function Validar_User(Nombre As String, Password As String) As Boolean

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

        Dim sql As String = "SELECT * FROM Clientes WHERE Nombre = '" & Nombre & "' AND Password = '" & Password & "'"

        Dim cmd As OleDbCommand = New OleDbCommand(sql, _OleDbConnection)

        Try
            _OleDbConnection.Open()
            Dim numRegistrosAfectados = cmd.ExecuteScalar

            If (numRegistrosAfectados IsNot Nothing) Then

                User_Exist = True

            Else

                User_Exist = False

            End If

        Catch ex As Exception

        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try

        Return User_Exist

    End Function

End Class