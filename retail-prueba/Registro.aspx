<%@ Page Title="" Language="C#" MasterPageFile="~/SinMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="retail_prueba.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos/ValidatorRequerid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos/EstilosRegistro.css" rel="stylesheet" />

    <div class="register-container">
        <h1 class="register-title">Portal Nexus</h1>
        <h4 class="register-subtitle">Crear nueva cuenta</h4>

        <div class="input-group">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombree" />
            <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="Debe Ingresar el Nombre" ControlToValidate="txtNombree" runat="server" />
            <%--<input runat="server" type="text" id="txtNombre" name="txtNombre" placeholder="Ingrese su nombre" required>--%>
        </div>

        <div class="input-group">
            <label for="txtApellido">Apellido</label>
            <asp:TextBox runat="server" ID="txtApellidoo" />
            <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="Debe Ingresar el Apellido" ControlToValidate="txtApellidoo" runat="server" />
            <%--<input runat="server" type="text" id="txtApellido" name="txtApellido" placeholder="Ingrese su apellido" required>--%>
        </div>

        <%--<div class="input-group">
            <label for="txtFecha">Fecha de nacimiento</label>
            <input runat="server" type="date" id="txtFecha" name="txtFecha" required>
        </div>--%>

        <div class="input-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmaill" runat="server" />
            <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="Debe Ingresar el Email" ControlToValidate="txtEmaill" runat="server" />

            <asp:RegularExpressionValidator ErrorMessage="Formato Email Incorrecto" ControlToValidate="txtEmaill" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3}|cl)(\]?)$" />
            <%--<input runat="server" type="email" id="txtEmail" name="txtEmail" placeholder="Ingrese su email" required>--%>
        </div>

        <div class="input-group">
            <label for="txtContra">Contraseña</label>
            <asp:TextBox TextMode="Password" ID="txtContraa" runat="server" />
            <asp:RequiredFieldValidator CssClass="validarRequerido" ErrorMessage="Debe Ingresar la Contraseña" ControlToValidate="txtContraa" runat="server" />
            <%--<input runat="server" type="password" id="txtContra" name="txtContra" placeholder="Ingrese una contraseña" required>--%>
        </div>

        <div class="buttons"> 
            <asp:Button ID="btnRegistro" CssClass="btn btn-primary" Text="Registrarse" runat="server" OnClick="btnRegistro_Click" />
            <a href="Login.aspx" class="btn btn-secondary">Volver</a>
        </div> 
    </div>
</asp:Content>
