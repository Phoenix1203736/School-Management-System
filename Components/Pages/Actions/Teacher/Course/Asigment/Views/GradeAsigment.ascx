<%@ Control Language="C#" CodeBehind="GradeAsigment.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Views.GradeAsigment" %>

<div class="card shadow-sm border-0 rounded-4 p-4">
    <div class="card-body">
        <h4 class="card-title mb-4 text-success fw-bold">
            <i class="bi bi-clipboard-check me-2"></i>Calificar Asignaciones
        </h4>

        <div class="mb-3">
            <label class="form-label fw-semibold">Asignación</label>
            <asp:DropDownList ID="ddlAssignments" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAssignments_SelectedIndexChanged" CssClass="form-select rounded-pill shadow-sm">
                <asp:ListItem Text="-- Seleccione --" Value="" />
            </asp:DropDownList>
        </div>

        <asp:GridView ID="gvGrades" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered rounded-3 overflow-hidden shadow-sm" DataKeyNames="AssignmentId">
            <Columns>
                <asp:BoundField DataField="StudentName" HeaderText="Estudiante" />
                <asp:TemplateField HeaderText="Nota">
                    <ItemTemplate>
                        <asp:TextBox ID="txtGrade" runat="server" CssClass="form-control rounded-3 shadow-sm text-center fw-bold" Text='<%# Bind("Grade") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="d-flex gap-2 mt-3">
            <asp:Button ID="btnSaveGrades" runat="server" Text="Guardar Notas" CssClass="btn btn-success rounded-pill px-4" OnClick="btnSaveGrades_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-outline-danger rounded-pill px-4" OnClick="btnCancel_Click" />
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="mt-3 d-block text-info fw-semibold" />
    </div>
</div>