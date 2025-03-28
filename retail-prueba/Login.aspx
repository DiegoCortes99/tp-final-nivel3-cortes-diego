<%@ Page Title="" Language="C#" MasterPageFile="~/SinMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="retail_prueba.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/ValidatorRequerid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos/EstilosLogin.css" rel="stylesheet" />

    <div class="login-container">
        <h1 class="login-title">Portal Nexus</h1>
        <h4 class="login-subtitle">Plataforma integrada de servicios digitales</h4>


        <div class="input-group">
            <label for="txtUsuario">Nombre de usuario</label>
            <asp:TextBox ID="txtUsuarioo" TextMode="Email" runat="server" />
            <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="El email es requerido" ControlToValidate="txtUsuarioo" runat="server" />
            <%--<input runat="server" type="text" id="txtUsuario" name="txtUsuario" placeholder="Ingrese su nombre de usuario" required>--%>
        </div>

        <div class="input-group">
            <label for="txtContra">Contraseña</label>
            <asp:TextBox ID="txtContraa" TextMode="Password" runat="server" />
            <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="La contraseña es requerida" ControlToValidate="txtContraa" runat="server" />
            <%--<input runat="server" type="password" id="txtContra" name="txtContra" placeholder="Ingrese su contraseña" required>--%>
        </div>

        <div class="buttons">
            <asp:Button ID="btnIngresar" class="btn btn-primary" Text="Ingresar" runat="server" OnClick="btnIngresar_Click" />
            <a href="Registro.aspx" class="btn btn-secondary">Registrarse</a>
        </div>

        <%--<div class="register-link">
            <a href="Registro.aspx" class="btn btn-secondary">Registrarse</a>
        </div>--%>

    </div>

</asp:Content>
