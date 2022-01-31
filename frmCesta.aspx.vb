Imports System.Data.OleDb

Public Class frmCesta
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



        If Not IsPostBack Then

            Dim cesta As List(Of lineaFac) = New List(Of lineaFac)

            cesta = HttpContext.Current.Session("Reto2Carrito")

            If Not IsNothing(cesta) Then

                'Label1.Visible = True


            End If

            Me.gvCarrito.DataSource = cesta
            Me.gvCarrito.DataBind()


        End If


    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCarrito.RowCommand

        Dim selectdIndex As Integer = Convert.ToInt32(e.CommandArgument)

        Dim cesta As List(Of lineaFac) = New List(Of lineaFac)
        If Not IsNothing(HttpContext.Current.Session("Reto2Carrito")) Then
            cesta = HttpContext.Current.Session("Reto2Carrito")
            cesta.RemoveAt(selectdIndex)
            Me.gvCarrito.DataSource = cesta
            Me.gvCarrito.DataBind()
            HttpContext.Current.Session("Reto2Carrito") = cesta
        End If


    End Sub
    'controla la exepcion del RowDeleting
    Protected Sub gvCarrito_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvCarrito.RowDeleting
        Dim algo As String = ""
    End Sub

    Protected Sub Comprar_Click(sender As Object, e As EventArgs) Handles Comprar.Click

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


        'cogemos la cesta en la  variable de Session
        Dim cesta As List(Of lineaFac) = New List(Of lineaFac)
        If Not IsNothing(HttpContext.Current.Session("Reto2Carrito")) Then
            cesta = HttpContext.Current.Session("Reto2Carrito")
        End If

        Dim iDfactura As Integer = cesta(0).CodFac
        Dim fechaActual As Date = DateTime.Today()
        Dim totalFactura As Integer = getTotalFactura()

        Dim queryFactura As String = " INSERT INTO Facturas([FacturaId], [Fecha], [CodCli], [CodVend], [Importe], [IVA], [Descuento], [Devuelta]  ) VALUES( " & iDfactura & ", " & fechaActual & ", 1 , 3 ," & totalFactura & ", 5 , 6 , False );"

        Dim cmdFAC As OleDbCommand = New OleDbCommand(queryFactura, _OleDbConnection)

        Try
            'creamos la factura
            _OleDbConnection.Open()
            Dim filasFac As Integer = cmdFAC.ExecuteNonQuery()

            If filasFac > 0 Then

                'Se inserta las lineas de la Factura
                If Not IsNothing(OleDbConnection) Then
                    OleDbConnection.Close()
                End If

                For index = 0 To cesta.Count - 1


                    Dim queryLineaFac As String = " INSERT INTO LineasFac([CdFac], [Linea], [PeliculaId], [Precio], [Descuento], [EsCompra] ) VALUES(" & cesta(index).CodFac & " , " & cesta(index).linea & " , " & cesta(index).peliculaId & " , " & cesta(index).precio & " , " & cesta(index).descuento & " , " & cesta(index).esCompra & ");"

                    Dim cmd As OleDbCommand = New OleDbCommand(queryLineaFac, _OleDbConnection)

                    Try
                        _OleDbConnection.Open()
                        Dim filas As Integer = cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        If Not IsNothing(OleDbConnection) Then
                            OleDbConnection.Close()
                        End If
                    End Try



                Next

            Else
                MsgBox("error al comprar")
            End If

            'limpiamos el carrito y volvemos a meterlo en la variable de session
            If Not IsNothing(HttpContext.Current.Session("Reto2Carrito")) Then

                cesta.Clear()
                Me.gvCarrito.DataSource = cesta
                Me.gvCarrito.DataBind()
                HttpContext.Current.Session("Reto2Carrito") = cesta
            End If

            MsgBox("Compra Finalizada")

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not IsNothing(OleDbConnection) Then
                OleDbConnection.Close()
            End If
        End Try


    End Sub

    Private Function getTotalFactura() As Integer

        Dim cesta As List(Of lineaFac) = New List(Of lineaFac)
        If Not IsNothing(HttpContext.Current.Session("Reto2Carrito")) Then
            cesta = HttpContext.Current.Session("Reto2Carrito")
        End If

        Dim total As Integer

        For index = 0 To cesta.Count - 1

            total += cesta(index).precio

        Next

        Return total

        'HttpContext.Current.User.Identity.Name
        'HttpContext.Current.Session("idUser") = ""

    End Function



End Class



