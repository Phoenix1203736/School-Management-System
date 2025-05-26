<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminCourses/AddCourseStudent.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.AddCourseStudent" %>
<div class="card p-3 mb-3">
    <h5>Agregar Alumno a Curso</h5>
    
    <div class="mb-2">
        <label class="form-label">Curso (Activo)</label>
        <asp:DropDownList runat="server" ID="dropdownSubjectActive" CssClass="form-select" />
    </div>
    
    <div class="mb-2">
        <label class="form-label">ID del Estudiante</label>
        <asp:TextBox ID="txtAlumno" runat="server" CssClass="form-control" />
    </div>
    
    <asp:Button ID="btnVincular" runat="server" Text="Agregar" CssClass="btn btn-success"
                OnClick="btnVincular_Click" />
        
    <asp:Label ID="lblResultado" runat="server" CssClass="form-text mt-2" />
</div>