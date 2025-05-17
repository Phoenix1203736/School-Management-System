<%@ Control Language="C#" CodeBehind="NavBarTeacher.ascx.cs" Inherits="SistemsProyect.Components.NavBar.Teacher.NavBarTeacher" %>
    <div class="container-fluid">
        <a class="navbar-brand" href="<%= ResolveUrl("~/Default.aspx") %>">Edu Soft</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
           <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link" href="<%= ResolveUrl("~/Components/Pages/TeacherViews/TeacherViews.aspx") %>">Administrar Cursos</a>
                </li>
              
            </ul>
        </div>
    </div>
