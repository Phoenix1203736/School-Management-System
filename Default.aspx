<%@ Page Title="Edu Soft - Sistema de Gestión Escolar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemsProyect.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!-- Hero -->
        <section class="py-5">
            <div class="text-center mb-5">
                <h1 class="fw-bold">Acerca de Edu Soft</h1>
                <p class="lead text-muted mx-auto" style="max-width: 720px;">
                    Edu Soft es una solución integral de gestión educativa diseñada para facilitar las tareas
                    administrativas y académicas dentro de una institución escolar. Nuestro software permite a
                    profesores, administradores y directivos escolares coordinar, automatizar y optimizar los
                    procesos clave que forman parte del día a día en cualquier centro educativo.
                </p>
            </div>
        </section>

        <!-- Funcionalidades principales -->
        <section class="pb-4">
            <h2 class="mb-4">Funcionalidades principales</h2>
            <div class="row g-4">
                <div class="col-md-6 col-lg-4">
                    <div class="card h-100 feature-card">
                        <div class="card-body">
                            <span class="feature-icon">
                                <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M22 10L12 5 2 10l10 5 10-5z"/><path d="M6 12v5c0 1.7 2.7 3 6 3s6-1.3 6-3v-5"/></svg>
                            </span>
                            <h5 class="fw-bold">Gestión Académica</h5>
                            <p class="text-muted mb-0">Registro y seguimiento de calificaciones, asistencia, tareas y evaluaciones por parte de los docentes.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-lg-4">
                    <div class="card h-100 feature-card">
                        <div class="card-body">
                            <span class="feature-icon">
                                <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/><circle cx="9" cy="7" r="4"/><path d="M19 8v6M22 11h-6"/></svg>
                            </span>
                            <h5 class="fw-bold">Panel del Profesor</h5>
                            <p class="text-muted mb-0">Herramientas intuitivas para crear horarios, planificar clases, subir material didáctico y comunicarse con los alumnos.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-lg-4">
                    <div class="card h-100 feature-card">
                        <div class="card-body">
                            <span class="feature-icon">
                                <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M3 21h18M5 21V7l7-4 7 4v14M9 21v-6h6v6M9 10h.01M15 10h.01M9 14h.01M15 14h.01"/></svg>
                            </span>
                            <h5 class="fw-bold">Administración Escolar</h5>
                            <p class="text-muted mb-0">Control total sobre inscripciones, matrículas, expedientes académicos, recursos escolares y más.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-lg-4">
                    <div class="card h-100 feature-card">
                        <div class="card-body">
                            <span class="feature-icon">
                                <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><polygon points="12 2 2 7 12 12 22 7 12 2"/><polyline points="2 17 12 22 22 17"/><polyline points="2 12 12 17 22 12"/></svg>
                            </span>
                            <h5 class="fw-bold">Flexibilidad y Adaptabilidad</h5>
                            <p class="text-muted mb-0">Diseñado para ajustarse a la estructura y necesidades específicas de cada escuela.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-lg-4">
                    <div class="card h-100 feature-card">
                        <div class="card-body">
                            <span class="feature-icon">
                                <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><circle cx="12" cy="12" r="10"/><line x1="2" y1="12" x2="22" y2="12"/><path d="M12 2a15.3 15.3 0 0 1 4 10 15.3 15.3 0 0 1-4 10 15.3 15.3 0 0 1-4-10 15.3 15.3 0 0 1 4-10z"/></svg>
                            </span>
                            <h5 class="fw-bold">Accesibilidad</h5>
                            <p class="text-muted mb-0">Interfaz amigable y fácil de usar, accesible desde cualquier dispositivo con conexión a Internet.</p>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- ¿Por qué elegir Edu Soft? -->
        <section class="py-4">
            <div class="card feature-card">
                <div class="card-body p-4">
                    <h2 class="mb-3">¿Por qué elegir Edu Soft?</h2>
                    <ul class="list-unstyled row g-2 mb-0">
                        <li class="col-md-4 d-flex align-items-center">
                            <svg class="icon text-primary me-2" viewBox="0 0 24 24" aria-hidden="true"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/></svg>
                            Fácil de usar
                        </li>
                        <li class="col-md-4 d-flex align-items-center">
                            <svg class="icon text-primary me-2" viewBox="0 0 24 24" aria-hidden="true"><path d="M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z"/></svg>
                            Seguro y confiable
                        </li>
                        <li class="col-md-4 d-flex align-items-center">
                            <svg class="icon text-primary me-2" viewBox="0 0 24 24" aria-hidden="true"><rect x="2" y="2" width="20" height="8" rx="2"/><rect x="2" y="14" width="20" height="8" rx="2"/><line x1="6" y1="6" x2="6.01" y2="6"/><line x1="6" y1="18" x2="6.01" y2="18"/></svg>
                            Todo en local
                        </li>
                    </ul>
                </div>
            </div>
            <p class="mt-4"><strong>Edu Soft</strong> no solo digitaliza procesos, sino que transforma la gestión escolar en una experiencia más ágil, moderna y eficiente.</p>
        </section>
    </main>
</asp:Content>
