Imports System.Data.OleDb
Public Class frmPeliculas
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

    Public contadorFacturas As Integer = 0

    Shared lineasFactura As New Dictionary(Of Integer, lineaFac)

    Dim contadorDicctionary As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged



    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand

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

        Dim nombreComando As String = e.CommandName

        Dim selectdIndex As Integer = Convert.ToInt32(e.CommandArgument)

        Dim precioPeli As Double

        If nombreComando = "btnAlquilar" Then

            Dim peliculaId As Integer = CInt(GridView1.DataKeys(selectdIndex).Item("PeliculaId"))

            Dim repe As Boolean = False

            For Each lineaFac In lineasFactura

                If lineaFac.Value.peliculaId = peliculaId Then

                    repe = True

                End If

            Next

            If repe = True Then

                MsgBox("Pelicula ya comprada o alquilada")

            Else

                Dim peliculaIdString As String = peliculaId.ToString()

                Dim sql As String = "SELECT [Precio] FROM [Peliculas] WHERE [PeliculaId] LIKE '" + peliculaIdString + "';"

                Dim cmd As OleDbCommand = New OleDbCommand(sql, _OleDbConnection)

                Try
                    _OleDbConnection.Open()
                    precioPeli = cmd.ExecuteScalar


                Catch ex As Exception

                Finally
                    If Not IsNothing(OleDbConnection) Then
                        OleDbConnection.Close()
                    End If
                End Try


                sql = "SELECT COUNT(*) FROM [Facturas];"

                cmd = New OleDbCommand(sql, _OleDbConnection)

                Try
                    _OleDbConnection.Open()
                    contadorFacturas = cmd.ExecuteScalar


                Catch ex As Exception

                Finally
                    If Not IsNothing(OleDbConnection) Then
                        OleDbConnection.Close()
                    End If
                End Try

                contadorFacturas = contadorFacturas + 1

                Dim newLinea As New lineaFac(contadorFacturas, 1, peliculaId, precioPeli, 0, False)

                lineasFactura.Add(contadorDicctionary, newLinea)

                contadorDicctionary = +1

                Dim countLinea As Integer = lineasFactura.Count

            End If

        ElseIf nombreComando = "btnComprar" Then

            Dim peliculaId As Integer = CInt(GridView1.DataKeys(selectdIndex).Item("PeliculaId"))

            Dim peliculaIdString As String = peliculaId.ToString()

            Dim contadorFacturas As Integer = 0

            Dim sql As String = "SELECT [Precio] FROM [Peliculas] WHERE [PeliculaId] LIKE '" + peliculaIdString + "';"

            Dim cmd As OleDbCommand = New OleDbCommand(sql, _OleDbConnection)

            Try
                _OleDbConnection.Open()
                precioPeli = cmd.ExecuteScalar


            Catch ex As Exception

            Finally
                If Not IsNothing(OleDbConnection) Then
                    OleDbConnection.Close()
                End If
            End Try


            sql = "SELECT COUNT(*) FROM [Facturas];"

            cmd = New OleDbCommand(sql, _OleDbConnection)

            Try
                _OleDbConnection.Open()
                contadorFacturas = cmd.ExecuteScalar


            Catch ex As Exception

            Finally
                If Not IsNothing(OleDbConnection) Then
                    OleDbConnection.Close()
                End If
            End Try

            contadorFacturas = contadorFacturas + 1

            Dim newLinea As New lineaFac(contadorFacturas, 1, peliculaId, precioPeli, 0, True)

            lineasFactura.Add(contadorDicctionary, newLinea)

            contadorDicctionary = +1

        End If
    End Sub
End Class