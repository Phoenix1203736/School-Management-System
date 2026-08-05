<%@ Page Title="Acerca de nostros" Language="C#" MasterPageFile="Site.Master" CodeBehind="About.aspx.cs" Inherits="SistemsProyect.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <main>
        <!-- Sección Acerca de Nosotros -->
        <section id="about-us" class="py-5">
            <div class="container">
                <div class="row align-items-center">
                    <!-- Representación visual -->
                    <div class="col-md-6 mb-4 mb-md-0">
                        <div class="feature-icon bg-primary bg-opacity-10 rounded-4 p-5 d-flex align-items-center justify-content-center">
                            <svg class="icon-lg" viewBox="0 0 24 24" aria-hidden="true"><path d="M22 10L12 5 2 10l10 5 10-5z"/><path d="M6 12v5c0 1.7 2.7 3 6 3s6-1.3 6-3v-5"/></svg>
                        </div>
                    </div>
                    <!-- Contenido -->
                    <div class="col-md-6">
                        <h2 class="fw-bold mb-3">¿Quiénes Somos?</h2>
                        <p class="text-muted">
                            <strong>Edu Soft</strong> es una plataforma tecnológica dedicada a simplificar y mejorar la gestión escolar en todos sus niveles. Combinamos la experiencia educativa con innovación tecnológica para ofrecer una solución completa para instituciones, docentes, alumnos y padres
                        </p>
                        <ul class="list-unstyled">
                            <li class="mb-3 d-flex align-items-center">
                                <svg class="icon text-primary me-2" viewBox="0 0 24 24" aria-hidden="true"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/></svg>
                                Plataforma intuitiva para docentes y administradores.
                            </li>
                            <li class="mb-3 d-flex align-items-center">
                                <svg class="icon text-primary me-2" viewBox="0 0 24 24" aria-hidden="true"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/></svg>
                                Automatización de tareas académicas y administrativas.
                            </li>
                            <li class="mb-3 d-flex align-items-center">
                                <svg class="icon text-primary me-2" viewBox="0 0 24 24" aria-hidden="true"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/></svg>
                                Seguridad y privacidad en el manejo de datos escolares.
                            </li>
                            <li class="mb-3 d-flex align-items-center">
                                <svg class="icon text-primary me-2" viewBox="0 0 24 24" aria-hidden="true"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/></svg>
                                Soporte continuo y adaptación a las necesidades locales.
                            </li>
                        </ul>
                    </div>
                </div>

                <!-- Misión, Visión y Valores -->
                <div class="row text-center mt-5">
                    <div class="col-md-4 mb-4">
                        <div class="card border-0 h-100 shadow-sm p-4 feature-card">
                            <span class="feature-icon mx-auto">
                                <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><circle cx="12" cy="12" r="10"/><circle cx="12" cy="12" r="6"/><circle cx="12" cy="12" r="2"/></svg>
                            </span>
                            <h5 class="fw-bold">Nuestra Misión</h5>
                            <p class="text-muted">
                                Facilitar la transformación digital de las instituciones educativas mediante soluciones efectivas, accesibles y seguras.
                            </p>
                        </div>
                    </div>
                    <div class="col-md-4 mb-4">
                        <div class="card border-0 h-100 shadow-sm p-4 feature-card">
                            <span class="feature-icon mx-auto">
                                <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/></svg>
                            </span>
                            <h5 class="fw-bold">Nuestra Visión</h5>
                            <p class="text-muted">
                                Ser reconocidos como el software educativo más confiable de Latinoamérica, impulsando el aprendizaje y la gestión moderna.
                            </p>
                        </div>
                    </div>
                    <div class="col-md-4 mb-4">
                        <div class="card border-0 h-100 shadow-sm p-4 feature-card">
                            <span class="feature-icon mx-auto">
                                <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M20.84 4.61a5.5 5.5 0 0 0-7.78 0L12 5.67l-1.06-1.06a5.5 5.5 0 0 0-7.78 7.78l1.06 1.06L12 21.23l7.78-7.78 1.06-1.06a5.5 5.5 0 0 0 0-7.78z"/></svg>
                            </span>
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
