<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="retail_prueba.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/ValidatorRequerid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container">
        <h1>Formulario de Articulos</h1>
        <div class="row">
            <div class="col-6">
                <%if (Request.QueryString["id"] != null)
                    {
                %>
                <div class="mb-3">
                    <label for="txtId" class="form-label">Id: </label>
                    <asp:TextBox ID="txtId" TextMode="Number" CssClass="form-control" runat="server" />
                </div>
                <% } %>

                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Codigo: </label>
                    <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="El campo no puede estar vacio" ControlToValidate="txtCodigo" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre: </label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="El campo no puede estar vacio" ControlToValidate="txtNombre" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="ddlMarca" class="form-label">Marca: </label>
                    <asp:DropDownList ID="ddlMarca" CssClass="form-control" runat="server" />

                    <%if (!(Request.QueryString["id"] != null))
                        {
                    %>
                    <div class="mt-1 mt-1 d-flex flex-column align-items-end">
                        <asp:TextBox ID="txtAgregarMarca" CssClass="form-control mb-1" runat="server" />
                        <asp:Button Visible="true" ID="btnAgregarMarca" OnClick="btnAgregarMarca_Click" Text="Agregar" CssClass="btn btn-success mb-1" runat="server" />
                    </div>
                    <% } %>
                </div>

                <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoria: </label>
                    <asp:DropDownList ID="ddlCategoria" DataTextField="Categoria" DataValueField="Id" CssClass="form-control" runat="server" />
                    <%if (!(Request.QueryString["id"] != null))
                        {
                    %>
                    <div class="mt-1 mt-1 d-flex flex-column align-items-end">
                        <asp:TextBox ID="txtAgregarCategoria" CssClass="form-control mb-1" runat="server" />
                        <asp:Button Visible="true" ID="btnAgregarCategoria" OnClick="btnAgregarCategoria_Click" Text="Agregar" CssClass="btn btn-success mb-1" runat="server" />
                    </div>
                    <% } %>
                </div>

                <asp:Button CssClass="btn btn-primary" ID="btnAceptar" Text="Aceptar" runat="server" OnClick="btnAceptar_Click" />
                <a href="ListaArticulos.aspx" class="btn btn-danger">Volver</a>

            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="Descripcion" class="form-label">Descripcion: </label>
                    <asp:TextBox TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="El campo no puede estar vacio" ControlToValidate="txtDescripcion" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="Precio" class="form-label">Precio: </label>
                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
                    <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="El campo no puede estar vacio" ControlToValidate="txtPrecio" runat="server" />
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtImagenUrl" class="form-label">Url Imagen: </label>
                            <asp:TextBox AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" ID="txtImagenUrl" CssClass="form-control" runat="server" />
                            <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="El campo no puede estar vacio" ControlToValidate="txtImagenUrl" runat="server" />
                        </div>
                        <asp:Image CssClass="mb-1" ID="imgArticulo" ImageUrl="https://images.ctfassets.net/ihx0a8chifpc/GTlzd4xkx4LmWsG1Kw1BB/ad1834111245e6ee1da4372f1eb5876c/placeholder.com-1280x720.png?w=1920&q=60&fm=webp" Width="400px" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                <div class="row">
                    <div>
                        <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" CssClass="btn btn-warning mb-1" OnClick="btnEliminar_Click" />

                    </div>
                    <div class="col-5 d-flex justify-content-start gap-2 mb-1">
                        <asp:TextBox runat="server" ID="txtEliminar" PlaceHolder="Ingrese el codigo del producto y presione Tab" CssClass="form-control" Style="width: 350px" AutoPostBack="true" OnTextChanged="txtEliminar_TextChanged" />
                        <asp:Button ID="btnConfirmarEliminacion" runat="server" Text="Eliminar" OnClick="btnConfirmarEliminacion_Click" Visible="false" Enabled="false" CssClass="btn btn-danger m-1" />
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
