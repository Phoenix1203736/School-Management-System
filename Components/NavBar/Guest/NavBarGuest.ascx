<%@ Control Language="C#" CodeBehind="NavBarGuest.ascx.cs" Inherits="SistemsProyect.Components.NavBar.Guest.NavBarGuest"%>
<div class="container-fluid">
    <a class="navbar-brand" href="<%= ResolveUrl("~/Default.aspx") %>">Edu Soft</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav ms-auto">
            <li class="nav-item">
                <a class="nav-link" href="<%= ResolveUrl("~/Components/Pages/Login/Login.aspx") %>">Iniciar Sesión</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="<%= ResolveUrl("~/About.aspx") %>">Acerca de nosotros</a>
            </li>
        </ul>
    </div>
</div>
