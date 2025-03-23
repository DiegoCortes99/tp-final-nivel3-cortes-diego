<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="retail_prueba.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <h1>Lista de Articulos</h1>
        <asp:GridView DataKeyNames="Id" CssClass="table table-bordered border-dark" ID="dgvArticulos" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Codigo Articulo" DataField="codigoArticulo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                <asp:BoundField HeaderText="Precio" DataField="precio" />
                <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="✍️" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnAgregar" Text="Agregar Articulo" runat="server" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
    </div>

</asp:Content>
