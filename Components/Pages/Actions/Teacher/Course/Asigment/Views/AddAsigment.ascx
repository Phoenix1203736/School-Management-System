<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAsigment.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Views.AddAsigment" %>

<div class="card shadow border-0 rounded-4 p-4">
    <div class="card-body">
        <h4 class="card-title text-primary fw-bold mb-4">
            <svg class="icon me-2" viewBox="0 0 24 24" aria-hidden="true"><path d="M12 5v14M5 12h14"/></svg>Agregar Asignación
        </h4>

        <div class="mb-3">
            <label for="<%= ddlSubjects.ClientID %>" class="form-label fw-semibold">Materia</label>
            <asp:DropDownList 
                ID="ddlSubjects" 
                runat="server" 
                CssClass="form-select shadow-sm rounded-pill">
            </asp:DropDownList>
        </div>

        <div class="mb-3">
            <label for="<%= txtDescription.ClientID %>" class="form-label fw-semibold">Descripción</label>
            <asp:TextBox 
                ID="txtDescription" 
                runat="server" 
                CssClass="form-control shadow-sm rounded-3" 
                TextMode="MultiLine" 
                Rows="3" 
                placeholder="Escribe una descripción...">
            </asp:TextBox>
        </div>

        <div class="d-flex flex-wrap gap-2 mt-3">
            <asp:Button 
                ID="btnAddAssignment" 
                runat="server" 
                Text="Agregar" 
                CssClass="btn btn-primary px-4 rounded-pill shadow-sm" 
                OnClick="btnAddAssignment_Click" />
            
            <asp:Button 
                ID="ButtonCancel" 
                runat="server" 
                Text="Cancelar" 
                CssClass="btn btn-outline-danger px-4 rounded-pill shadow-sm" 
                OnClick="ButtonCancel_Click" />
        </div>

        <asp:Label 
            ID="lblMessage" 
            runat="server" 
            CssClass="d-block mt-4 text-info fw-semibold">
        </asp:Label>
    </div>
</div>