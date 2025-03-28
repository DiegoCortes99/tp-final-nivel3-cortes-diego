<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="retail_prueba.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>

    <style>
        .card-filter {
            max-height: 85vh;
            overflow-y: auto;
            position: sticky;
            top: 20px;
        }

        .card-body {
            padding: 1rem !important;
        }

        .card-product {
            transition: transform 0.2s;
            height: 100%;
        }

            .card-product:hover {
                transform: translateY(-5px);
            }

        .card-img-fixed {
            object-fit: cover;
            height: 200px;
        }

        .img-container {
            position: relative;
            padding-top: 75%; /* Relación de aspecto 4:3 (ajustar según necesidad) */
            overflow: hidden;
            background: #f8f9fa; /* Color de fondo mientras carga */
        }

        .card-img-adaptive {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            object-fit: cover; /* Ajuste inteligente */
            object-position: center; /* Enfoca el centro de la imagen */
        }

        .card-body {
            display: flex;
            flex-direction: column;
            justify-content: space-between;
        }
    </style>


    <!-- Carrusel -->
    <div id="carouselExampleIndicators" class="carousel slide">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="Images/Img-3.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="Images/Img-2.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="Images/Img-1.jpg" class="d-block w-100" alt="...">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

    <!-- Fin Carrusel -->
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="container-fluid mt-3">
                <div class="row">
                    <!-- Panel de Filtro -->
                    <div class="col-md-3 mb-4">
                        <div class="card card-filter shadow-sm">
                            <div class="card-body">
                                <h4 class="mb-4">Filtrar</h4>

                                <h5>Marcas</h5>
                                <asp:CheckBoxList ID="chkMarcas" runat="server"
                                    RepeatDirection="Vertical"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="FiltrarProductos"
                                    DataValueField="Id"
                                    DataTextField="Descripcion"
                                    CssClass="list-unstyled mb-3">
                                </asp:CheckBoxList>

                                <hr class="my-4">

                                <h5>Categorías</h5>
                                <asp:CheckBoxList ID="chkCategorias" runat="server"
                                    RepeatDirection="Vertical"
                                    CssClass="list-unstyled mb-4"
                                    AutoPostBack="true"
                                    DataValueField="Id"
                                    DataTextField="Descripcion"
                                    OnSelectedIndexChanged="FiltrarProductos">
                                </asp:CheckBoxList>

                                <%--<asp:Button ID="btnFiltrar" runat="server"
                                    CssClass="btn btn-primary w-100"
                                    Text="Aplicar Filtros"
                                    OnClick="btnFiltrar_Click" />--%>
                            </div>
                        </div>
                    </div>

                    <!-- Sección de Productos -->
                    <div class="col-md-9">
                        <asp:Repeater ID="rpArticulos" runat="server">
                            <HeaderTemplate>
                                <div class="row g-4">
                            </HeaderTemplate>

                            <ItemTemplate>
                                <div class="col-lg-4 col-md-6">
                                    <div class="card card-product h-100 shadow-sm">
                                        <div class="img-container">
                                            <img src='<%# Eval("ImagenUrl") %>'
                                                class="card-img-adaptive"
                                                alt='<%# Eval("Nombre") %>'>
                                        </div>

                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                            <p class="card-text flex-grow-1"><%# Eval("Descripcion") %></p>

                                            <div class="mt-3">
                                                <asp:Button ID="btnDetalle" runat="server"
                                                    Text="Ver Detalles"
                                                    CssClass="btn btn-outline-primary w-100"
                                                    CommandArgument='<%# Eval("ID") %>'
                                                    OnCommand="btnDetalle_Command" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>

                            <FooterTemplate>
                                </div>
                                <!-- Cierre del row -->
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Fin Sección de Cards -->
</asp:Content>
