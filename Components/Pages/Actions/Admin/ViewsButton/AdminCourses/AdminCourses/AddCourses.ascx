<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~/Components/Pages/Actions/Admin/ViewsButton/AdminCourses/AdminCourses/AddCourses.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.AdminCourses.AdminCourses.AddCourses" %>
<div class="card">
    <div class="card-header">
        <h4 class="mb-0">Agregar Materia</h4>
    </div>
    <div class="card-body">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block mb-2" />

        <div class="mb-3">
            <label class="form-label" for="<%= ddlProfessors.ClientID %>">Profesor</label>
            <asp:DropDownList ID="ddlProfessors" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                <asp:ListItem Text="Seleccione un profesor" Value="" />
            </asp:DropDownList>
        </div>

        <div class="mb-3">
            <label class="form-label" for="<%= txtName.ClientID %>">Nombre de la materia</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label class="form-label" for="<%= txtStartDate.ClientID %>">Fecha inicio</label>
            <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="mb-3">
            <label class="form-label" for="<%= txtEndDate.ClientID %>">Fecha fin</label>
            <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date" />
        </div>

        <div class="mb-3">
            <label class="form-label" for="<%= txtDescription.ClientID %>">Descripción</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
        </div>

        <div class="form-check mb-3">
            <asp:CheckBox ID="chkActive" runat="server" CssClass="form-check-input" />
            <label class="form-check-label" for="<%= chkActive.ClientID %>">Materia activa</label>
        </div>

        <asp:Button ID="btnSave" runat="server" Text="Guardar Materia" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</div>
