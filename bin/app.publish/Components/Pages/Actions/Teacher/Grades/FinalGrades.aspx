<%@ Page Title="Notas Finales" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="FinalGrades.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Grades.FinalGrades" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="MainContent">
    <h2 class="mt-3">Notas Finales por Curso</h2>

    <div class="mb-3">
        <label>Selecciona una materia:</label>
        <asp:DropDownList ID="ddlSubjects" runat="server" AutoPostBack="true"
                          OnSelectedIndexChanged="ddlSubjects_SelectedIndexChanged" CssClass="form-select">
        </asp:DropDownList>
    </div>

    <asp:GridView ID="gvFinalGrades" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered"
                  DataKeyNames="StudentId">
        <Columns>
            <asp:BoundField DataField="StudentName" HeaderText="Estudiante" />
            <asp:BoundField DataField="AverageGrade" HeaderText="Promedio de Trabajos" />
            <asp:BoundField DataField="AttendancePercentage" HeaderText="% Asistencia" DataFormatString="{0:0.##}%" />
            <asp:TemplateField HeaderText="Nota Final">
                <ItemTemplate>
                    <asp:TextBox ID="txtFinalGrade" runat="server" CssClass="form-control"
                                 Text='<%# Bind("FinalGrade") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnSaveFinalGrades" runat="server" Text="Guardar Notas Finales"
                CssClass="btn btn-primary" OnClick="btnSaveFinalGrades_Click" />

    <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3 d-block"></asp:Label>
</asp:Content>