<%@ Page Title="Acerca de Nosotros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SistemsProyect.Components.Pages.About.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Sección Acerca de Nosotros -->
        <section id="about-us" class="py-5 bg-white">
            <div class="container">
                <div class="row align-items-center">
                    <!-- Imagen representativa -->
                    <div class="col-md-6 mb-4 mb-md-0">
                        <!-- falta agregar fotos-->
                        <!--Missing add photos -->
                        <img src="" alt="Equipo Edu Soft" class="img-fluid rounded-4 shadow-sm" />
                    </div>
                    <!-- Contenido -->
                    <div class="col-md-6">
                        <h2 class="fw-bold mb-3">¿Quiénes Somos?</h2>
                        <p class="text-muted">
                            <strong>Edu Soft</strong> es una plataforma tecnológica dedicada a simplificar y mejorar la gestión escolar en todos sus niveles. Combinamos la experiencia educativa con innovación tecnológica para ofrecer una solución completa para instituciones, docentes, alumnos y padres
                        </p>
                        <ul class="list-unstyled">
                            <li class="mb-3">
                                <i class="bi bi-check-circle-fill text-primary me-2"></i>
                                Plataforma intuitiva para docentes y administradores.
          </li>
                            <li class="mb-3">
                                <i class="bi bi-check-circle-fill text-primary me-2"></i>
                                Automatización de tareas académicas y administrativas.
          </li>
                            <li class="mb-3">
                                <i class="bi bi-check-circle-fill text-primary me-2"></i>
                                Seguridad y privacidad en el manejo de datos escolares.
          </li>
                            <li class="mb-3">
                                <i class="bi bi-check-circle-fill text-primary me-2"></i>
                                Soporte continuo y adaptación a las necesidades locales.
          </li>
                        </ul>
                    </div>
                </div>

                <!-- Misión, Visión y Valores -->
                <div class="row text-center mt-5">
                    <div class="col-md-4 mb-4">
                        <div class="card border-0 h-100 shadow-sm p-4">
                            <i class="bi bi-bullseye text-primary fs-1 mb-3"></i>
                            <h5 class="fw-bold">Nuestra Misión</h5>
                            <p class="text-muted">
                                Facilitar la transformación digital de las instituciones educativas mediante soluciones efectivas, accesibles y seguras.

                            </p>
                        </div>
                    </div>
                    <div class="col-md-4 mb-4">
                        <div class="card border-0 h-100 shadow-sm p-4">
                            <i class="bi bi-eye text-success fs-1 mb-3"></i>
                            <h5 class="fw-bold">Nuestra Visión</h5>
                            <p class="text-muted">
                                Ser reconocidos como el software educativo más confiable de Latinoamérica, impulsando el aprendizaje y la gestión moderna.

                            </p>
                        </div>
                    </div>
                    <div class="col-md-4 mb-4">
                        <div class="card border-0 h-100 shadow-sm p-4">
                            <i class="bi bi-heart text-danger fs-1 mb-3"></i>
                            <h5 class="fw-bold">Nuestros Valores</h5>
                            <p class="text-muted">
                                Compromiso con la educación, innovación constante, respeto por la privacidad, y apoyo permanente a nuestros usuarios.

                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

    </main>
</asp:Content>