<%@ Page Language="vb"
    AutoEventWireup="false"
    MasterPageFile="~/WebApp.Master"
    CodeBehind="frmCesta.aspx.vb" 
    Inherits="RetoDI_SGE.frmCesta" %>

<asp:Content ID="formCesta" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">

        <div>
            <h3>Carrito de compra</h3>

            
            <div class="row">
                <div class="col-lg-8">

                    
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False">CARRITO VACIO</asp:Label>


                    <asp:GridView ID="gvCarrito" CssClass="table " AutoGenerateColumns="False" runat="server">
                        <Columns>
                           <%-- <asp:BoundField DataField="CodFac" HeaderText="Cod_factura"  />--%>
                            <asp:BoundField DataField="linea" HeaderText="Linea" />
                            <%--<asp:BoundField DataField="peliculaId" HeaderText="ID Pelicula" />--%>
                            <asp:BoundField DataField="nombrePelicula" HeaderText="Nombre Pelicula" />
                            <asp:BoundField DataField="precio" HeaderText="Precio" />
                            <asp:BoundField DataField="descuento" HeaderText="Descuento" />
                            <asp:CheckBoxField DataField="esCompra"  HeaderText="Compra"/>
                            <asp:ButtonField ButtonType="Button" CommandName="Delete" ControlStyle-CssClass="btn btn-danger" Text="Excluir" />
                        </Columns>
                        <EditRowStyle Font-Bold="True" />
                    </asp:GridView>

                </div>

            </div>

            <div class="row">
                <div class="col-lg-12">
                    <asp:Button ID="Comprar" CssClass="btn btn-default btn-lg" runat="server" Text="Comprar" />
                </div>
            </div>
            
            <%--<asp:Table ID="Table1" runat="server">

            </asp:Table>--%>
        </div>
        </form>
</asp:Content>
    

