<%@ Control Language="C#" CodeBehind="GradeAsigment.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Views.GradeAsigment" %>

<div class="card shadow border-0 rounded-4 p-4">
    <div class="card-body">
        <h4 class="card-title text-success fw-bold mb-4">
            <i class="bi bi-clipboard-check me-2"></i>Calificar Asignaciones
        </h4>

        <div class="mb-3">
            <label for="<%= ddlAssignments.ClientID %>" class="form-label fw-semibold">Asignación</label>
            <asp:DropDownList 
                ID="ddlAssignments" 
                runat="server" 
                AutoPostBack="true" 
                OnSelectedIndexChanged="ddlAssignments_SelectedIndexChanged"
                CssClass="form-select rounded-pill shadow-sm">
                <asp:ListItem Text="-- Seleccione --" Value="" />
            </asp:DropDownList>
        </div>

        <div class="mb-3">
            <label for="<%= txtGradeDate.ClientID %>" class="form-label fw-semibold">Fecha de Calificación</label>
            <asp:TextBox 
                ID="txtGradeDate" 
                runat="server" 
                CssClass="form-control rounded-pill shadow-sm" 
                TextMode="Date" />
            <asp:RequiredFieldValidator 
                ID="rfvGradeDate" 
                runat="server" 
                ControlToValidate="txtGradeDate"
                ErrorMessage="La fecha es obligatoria."
                CssClass="text-danger d-block mt-1"
                Display="Dynamic" />
        </div>

        <div class="table-responsive rounded-3 shadow-sm">
            <asp:GridView 
                ID="gvGrades" 
                runat="server" 
                AutoGenerateColumns="False" 
                DataKeyNames="AssignmentId"
                CssClass="table table-bordered table-hover align-middle mb-0">
                <Columns>
                    <asp:BoundField DataField="StudentName" HeaderText="Estudiante" />
                    <asp:TemplateField HeaderText="Nota">
                        <ItemTemplate>
                            <asp:TextBox 
                                ID="txtGrade" 
                                runat="server" 
                                CssClass="form-control rounded-3 shadow-sm text-center fw-bold" 
                                Text='<%# Bind("Grade") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="d-flex flex-wrap gap-2 mt-4">
            <asp:Button 
                ID="btnSaveGrades" 
                runat="server" 
                Text="Guardar Notas" 
                CssClass="btn btn-success px-4 rounded-pill shadow-sm" 
                OnClick="btnSaveGrades_Click" />

            <asp:Button 
                ID="btnCancel" 
                runat="server" 
                Text="Cancelar" 
                CssClass="btn btn-outline-danger px-4 rounded-pill shadow-sm" 
                OnClick="btnCancel_Click" />
        </div>

        <asp:Label 
            ID="lblMessage" 
            runat="server" 
            CssClass="d-block mt-4 text-info fw-semibold" />
    </div>
</div>
