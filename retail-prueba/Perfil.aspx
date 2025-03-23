<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="retail_prueba.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos/EstilosPerfil.css" rel="stylesheet" />

    <div class="perfil-container">
        <h1 class="perfil-title">Portal Nexus</h1>
        <h4 class="perfil-subtitle">Mi Perfil</h4>

        <div class="profile-image-container">
            <asp:Image ID="imgPerfil" runat="server" CssClass="profile-image" ImageUrl="https://thumbs.dreamstime.com/b/default-avatar-profile-icon-vector-social-media-user-image-182145777.jpg" />
        </div>

        <div class="input-group">
            <label for="txtImagenURL">Imagen de Perfil</label>
            <input type="file" name="name" id="txtImagen" runat="server" />

            <%--<asp:TextBox runat="server" ID="txtImagenURL" AutoPostBack="true" OnTextChanged="txtImagenURL_TextChanged" />--%>

            <div class="image-preview">
                <small>La imagen se actualizará al ingresar una Imagen válida</small>
            </div>
        </div>

        <div class="input-group">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" />
        </div>

        <div class="input-group">
            <label for="txtApellido">Apellido</label>
            <asp:TextBox runat="server" ID="txtApellido" />
        </div>

        <div class="input-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox TextMode="Email" ID="txtEmail" runat="server" ReadOnly="true" />
            <small>El email no puede ser modificado</small>
        </div>

        <div class="buttons">
            <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar Cambios" runat="server" OnClick="btnGuardar_Click" />
            <a href="Default.aspx" class="btn btn-secondary">Volver</a>
            <%--<asp:Button ID="btnCambiarPassword" CssClass="btn btn-secondary" Text="Cambiar Contraseña" runat="server" OnClick="btnCambiarPassword_Click" />--%>
        </div>
    </div>


</asp:Content>
