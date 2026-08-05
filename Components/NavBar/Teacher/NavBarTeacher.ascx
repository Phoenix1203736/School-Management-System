<%@ Control Language="C#" CodeBehind="NavBarTeacher.ascx.cs" Inherits="SistemsProyect.Components.NavBar.Teacher.NavBarTeacher" %>
    <div class="container-fluid">
        <a class="navbar-brand" href="<%= ResolveUrl("~/Default.aspx") %>">Edu Soft</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav ms-auto align-items-lg-center">
                <li class="nav-item">
                    <a class="nav-link" href="<%= ResolveUrl("~/Components/Pages/Actions/Teacher/Course/Assistance/AssistantView.aspx") %>">Asistencias de cursos</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= ResolveUrl("~/Components/Pages/Actions/Teacher/Course/Asigment/Assigment.aspx") %>">Tareas de cursos</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="<%= ResolveUrl("~/Components/Pages/Actions/Teacher/Grades/FinalGrades.aspx") %>">Asignar Calificación Final</a>
                </li>
                <li class="nav-item mt-2 mt-lg-0 ms-lg-2">
                    <asp:Button CssClass="btn btn-outline-light" runat="server" ID="buttonSignOut" OnClick="buttonSignOut_Click"
                        Text="Cerrar Sesión" />
                </li>
            </ul>
        </div>
    </div>
