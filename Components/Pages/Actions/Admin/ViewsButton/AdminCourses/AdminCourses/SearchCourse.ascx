<%@ Control Language="C#" CodeBehind="SearchCourse.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.SearchCourse" %>

<div class="container mt-3">
    <div class="row">
        <div class="col-md-6">

            <div class="mb-3">
                <label for="txtId">ID</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>

            <div class="mb-3">
                <label for="txtName">Nombre</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddlTeachers">Profesor</label>
                <asp:DropDownList ID="ddlTeachers" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="calStartDate">Fecha de Inicio</label>
                <asp:Calendar ID="calStartDate" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="calEndDate">Fecha de Fin</label>
                <asp:Calendar ID="calEndDate" runat="server" CssClass="form-control" />
            </div>

            <div class="form-check mb-3">
                <asp:CheckBox ID="chkActive" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="chkActive">¿Activa?</label>
            </div>

            <div class="mb-3">
                <label for="txtDescription">Descripción</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>

            <div class="mb-3">
                <label for="ddlSubjects">Seleccionar Materia</label>
                <asp:DropDownList ID="ddlSubjects" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnCargarMateria" runat="server" CssClass="btn btn-primary me-2" Text="Cargar" OnClick="btnCargarMateria_Click" />
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success me-2" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnFiltrarActivas" runat="server" CssClass="btn btn-secondary me-2" Text="Mostrar Activas" OnClick="btnFiltrarActivas_Click" />
            <asp:Button ID="btnFiltrarInactivas" runat="server" CssClass="btn btn-secondary" Text="Mostrar Inactivas" OnClick="btnFiltrarInactivas_Click" />

        </div>
    </div>
</div>