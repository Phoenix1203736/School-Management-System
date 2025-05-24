<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminCourses/AddCourses.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.AddCourses" %>
<div class="card p-4 shadow-sm rounded-3">
    <h4 class="mb-3">Agregar Materia</h4>
    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" />

    <div class="mb-3">
        <label for="ddlProfessors" class="form-label">Profesor</label>
        <asp:DropDownList ID="ddlProfessors" runat="server" CssClass="form-select" AppendDataBoundItems="true">
            <asp:ListItem Text="Seleccione un profesor" Value="" />
        </asp:DropDownList>
    </div>

    <div class="mb-3">
        <label for="txtFirstName" class="form-label">Nombre de la materia</label>
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
    </div>

    <div class="mb-3">
        <label for="txtStartDate" class="form-label">Fecha inicio</label>
        <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date" />
    </div>

    <div class="mb-3">
        <label for="txtEndDate" class="form-label">Fecha fin</label>
        <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date" />
    </div>

    <div class="mb-3">
        <label for="txtDescription" class="form-label">Descripción</label>
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>
    <div class="form-check mb-3">
        <asp:CheckBox ID="chkActive" runat="server" CssClass="form-check-input" />
        <label class="form-check-label" for="chkActive">Materia activa</label>
    </div>

    <asp:Button ID="btnSave" runat="server" Text="Guardar Materia" CssClass="btn btn-primary mt-3" OnClick="btnSave_Click" />
</div>
