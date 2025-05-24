<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAsigment.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Views.AddAsigment" %>
<div class="card shadow-sm border-0 rounded-4 p-4">
    <div class="card-body">
        <h4 class="card-title mb-4 text-primary fw-bold">
            <i class="bi bi-plus-circle me-2"></i>Agregar Asignación
        </h4>

        <div class="mb-3">
            <label class="form-label fw-semibold">Materia</label>
            <asp:DropDownList ID="ddlSubjects" runat="server" CssClass="form-select rounded-pill shadow-sm"></asp:DropDownList>
        </div>

        <div class="mb-3">
            <label class="form-label fw-semibold">Descripción</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control rounded-3 shadow-sm" TextMode="MultiLine" Rows="3" placeholder="Escribe una descripción..."></asp:TextBox>
        </div>

        <div class="d-flex gap-2">
            <asp:Button ID="btnAddAssignment" runat="server" CssClass="btn btn-primary rounded-pill px-4" Text="Agregar" OnClick="btnAddAssignment_Click" />
            <asp:Button runat="server" ID="ButtonCancel" Text="Cancelar" CssClass="btn btn-outline-danger rounded-pill px-4" OnClick="ButtonCancel_Click"/>
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 d-block text-info fw-semibold"></asp:Label>
    </div>
</div>