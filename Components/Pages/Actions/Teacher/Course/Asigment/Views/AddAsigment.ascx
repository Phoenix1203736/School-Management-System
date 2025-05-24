<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAsigment.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Views.AddAsigment" %>
<div class="card p-3">
  <h4 class="card-title">Agregar Asignación</h4>
  <div class="mb-3">
    <label for="ddlSubjects" class="form-label">Materia</label>
    <asp:DropDownList ID="ddlSubjects" runat="server" CssClass="form-select"></asp:DropDownList>
  </div>
  <div class="mb-3">
    <label for="txtDescription" class="form-label">Descripción</label>
    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
  </div>
  <asp:Button ID="btnAddAssignment" runat="server" CssClass="btn btn-primary" Text="Agregar" OnClick="btnAddAssignment_Click" />
  <asp:Button runat="server" ID="ButtonCancel" Text="Cancelar" CssClass="btn btn-danger" OnClick="ButtonCancel_Click"/>
  <asp:Label ID="lblMessage" runat="server" CssClass="mt-2 d-block"></asp:Label>
</div>