<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarAdmin.ascx.cs"
    Inherits="SistemsProyect.Components.NavBar.Admin.NavBarAdmin" %>
<div class="container-fluid">
    <a class="navbar-brand" href="<%= ResolveUrl("~/Default.aspx") %>">Edu Soft</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown"
        aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNavDropdown">
        <ul class="navbar-nav ms-auto align-items-lg-center">
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Administrar
                </a>
                <ul class="dropdown-menu dropdown-menu-end">
                    <li><a class="dropdown-item" href="<%= ResolveUrl("~/Components/Pages/Actions/Admin/ViewsButton/AdminStudent/AdminViewStudents.aspx") %>">Alumnos</a></li>
                    <li><a class="dropdown-item" href="<%= ResolveUrl("~/Components/Pages/Actions/Admin/ViewsButton/Teacher/AdminView.aspx") %>">Profesores</a></li>
                    <li><a class="dropdown-item" href="<%= ResolveUrl("~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminViewCourses.aspx") %>">Cursos</a></li>
                    <li><hr class="dropdown-divider" /></li>
                    <li><a class="dropdown-item" href="<%= ResolveUrl("~/Components/Pages/Actions/Admin/Reports/GenerateReport.aspx") %>">Reportes</a></li>
                </ul>
            </li>
            <li class="nav-item mt-2 mt-lg-0 ms-lg-2">
                <asp:Button CssClass="btn btn-outline-light" runat="server" ID="buttonSignOut" OnClick="buttonSignOut_Click"
                    Text="Cerrar Sesión" />
            </li>
        </ul>
    </div>
</div>
