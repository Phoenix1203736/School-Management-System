<%@ Control Language="C#" CodeBehind="GradeAsigment.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Asigment.Views.GradeAsigment" %>

<div class="card p-3">
    <h4 class="card-title">Calificar Asignaciones</h4>

    <div class="mb-3">
        <label for="ddlAssignments" class="form-label">Asignación</label>
        <asp:DropDownList ID="ddlAssignments" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAssignments_SelectedIndexChanged" CssClass="form-select" >
            <asp:ListItem Text="-- Seleccione --" Value="" />
        </asp:DropDownList>
        
    </div>

    <asp:GridView ID="gvGrades" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="AssignmentId">
        <Columns>
            <asp:BoundField DataField="StudentName" HeaderText="Estudiante" />
            <asp:TemplateField HeaderText="Nota">
                <ItemTemplate>
                    <asp:TextBox ID="txtGrade" runat="server" CssClass="form-control" Text='<%# Bind("Grade") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnSaveGrades" runat="server" Text="Guardar Notas" CssClass="btn btn-success" OnClick="btnSaveGrades_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
    <asp:Label ID="lblMessage" runat="server" CssClass="mt-2 d-block" />
</div>