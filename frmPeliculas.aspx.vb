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

    'Public Shared lineasFactura As New Dictionary(Of Integer, lineaFac)

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
        Dim cesta As New List(Of lineaFac)

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
            'Dim nombrePeliculaIndex As Integer = CInt(GridView1.DataKeys.Item("Titulo"))
            Dim nombrePelicula As String = GridView1.Rows(selectdIndex).Cells(2).Text
            Dim repe As Boolean = False

            If ComprobarPeliCompradaAlqilada(peliculaId) = True Then

                MsgBox("Peli ya comprada o alquilada")

            Else

                If Not IsNothing(HttpContext.Current.Session("Reto2Carrito")) Then
                    ' recuperar la cesta desde sesión
                    cesta = HttpContext.Current.Session("Reto2Carrito")
                End If

                For i = 0 To cesta.Count - 1

                    If cesta(i).peliculaId = peliculaId Then

                        repe = True

                    End If

                Next

                If repe = True Then

                    MsgBox("Pelicula ya comprada o alquilada")

                Else

                    Dim peliculaIdString As String = peliculaId.ToString()

                    Dim sql As String = "SELECT [Precio] FROM [Peliculas] WHERE [PeliculaId] = " & peliculaIdString & ";"

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

                    sql = "SELECT MAX(FacturaId) FROM [Facturas];"

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

                    Dim newLinea As New lineaFac(contadorFacturas, cesta.Count + 1, peliculaId, precioPeli, 0, False, nombrePelicula)

                    cesta.Add(newLinea)
                    HttpContext.Current.Session("Reto2Carrito") = cesta

                    contadorDicctionary = +1

                    Dim countLinea As Integer = cesta.Count

                End If

            End If

        ElseIf nombreComando = "btnComprar" Then

            Dim peliculaId As Integer = CInt(GridView1.DataKeys(selectdIndex).Item("PeliculaId"))
            Dim nombrePelicula As String = GridView1.Rows(selectdIndex).Cells(2).Text
            Dim peliculaIdString As String = peliculaId.ToString()

            If ComprobarPeliCompradaAlqilada(peliculaId) = True Then

                MsgBox("Peli ya comprada o alquilada")

            Else

                Dim contadorFacturas As Integer = 0

                Dim repe As Boolean = False

                If Not IsNothing(HttpContext.Current.Session("Reto2Carrito")) Then
                    ' recuperar la cesta desde sesión
                    cesta = HttpContext.Current.Session("Reto2Carrito")
                End If

                For i = 0 To cesta.Count - 1

                    If cesta(i).peliculaId = peliculaId Then

                        repe = True

                    End If

                Next

                If repe = True Then

                    MsgBox("Pelicula ya comprada o alquilada")

                Else

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


                    sql = "SELECT MAX(FacturaId) FROM [Facturas];"

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

                    Dim newLinea As New lineaFac(contadorFacturas, cesta.Count + 1, peliculaId, precioPeli, 0, True, nombrePelicula)

                    cesta.Add(newLinea)
                    HttpContext.Current.Session("Reto2Carrito") = cesta

                    contadorDicctionary = +1

                End If

            End If

        ElseIf nombreComando = "btnVer" Then

            Dim peliculaIdFRM As Integer

            Dim nombrePelicula As String

            If Not IsNothing(HttpContext.Current.Session("idPeliEdit")) Then
                ' recuperar la cesta desde sesión
                peliculaIdFRM = HttpContext.Current.Session("idPeliEdit")
            End If

            If Not IsNothing(HttpContext.Current.Session("nombrePeli")) Then
                ' recuperar la cesta desde sesión
                nombrePelicula = HttpContext.Current.Session("nombrePeli")
            End If


            nombrePelicula = GridView1.Rows(selectdIndex).Cells(2).Text

            HttpContext.Current.Session("nombrePeli") = nombrePelicula

            peliculaIdFRM = CInt(GridView1.DataKeys(selectdIndex).Item("PeliculaId"))

            HttpContext.Current.Session("idPeliEdit") = peliculaIdFRM



            Response.Redirect("frmPeliculasEdit.aspx")

        End If
    End Sub

    Public Function ComprobarPeliCompradaAlqilada(Id As Integer) As Boolean

        Dim StringId As String = Id.ToString()

        Dim sql As String = "SELECT * FROM [LineasFac] WHERE [PeliculaId] LIKE '" + StringId + "' ;"

        Dim cmd As OleDbCommand = New OleDbCommand(sql, _OleDbConnection)

        Dim esCompradaalquilada As Boolean = False

        Try
            _OleDbConnection.Open()

            If cmd.ExecuteScalar IsNot Nothing Then

                esCompradaalquilada = True

            End If

        Catch ex As Exception

        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try

        Return esCompradaalquilada

    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCesta.Click

        Response.Redirect("frmCesta.aspx")

    End Sub
End Class