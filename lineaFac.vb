Public Class lineaFac

    Public Sub New(CodFactd As Integer, lineatd As Integer, peliculaIdtd As Integer, preciotd As Double, descuentotd As Double, esCompratd As Boolean)

        Me.CodFac = CodFactd
        Me.linea = lineatd
        Me.peliculaId = peliculaIdtd
        Me.precio = preciotd
        Me.descuento = descuentotd
        Me.esCompra = esCompratd

    End Sub

    Private _CdFac As Integer
    Public Property CodFac() As Integer
        Get
            Return _CdFac
        End Get
        Set(ByVal value As Integer)
            _CdFac = value
        End Set
    End Property

    Private _linea As Integer
    Public Property linea() As Integer
        Get
            Return _linea
        End Get
        Set(ByVal value As Integer)
            _linea = value
        End Set
    End Property

    Private _peliculaId As Integer
    Public Property peliculaId() As Integer
        Get
            Return _peliculaId
        End Get
        Set(ByVal value As Integer)
            _peliculaId = value
        End Set
    End Property

    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Private _descuento As Double
    Public Property descuento() As Double
        Get
            Return _descuento
        End Get
        Set(ByVal value As Double)
            _descuento = value
        End Set
    End Property

    Private _esCompra As Boolean
    Public Property esCompra() As Boolean
        Get
            Return _esCompra
        End Get
        Set(ByVal value As Boolean)
            _esCompra = value
        End Set
    End Property

    Public Sub lineaFac()


    End Sub

End Class
