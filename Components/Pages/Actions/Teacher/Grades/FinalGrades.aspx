<%@ Page Title="Notas Finales" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="FinalGrades.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Grades.FinalGrades" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="MainContent">
    <div class="card">
        <div class="card-header">
            <h3 class="mb-0">Notas Finales por Curso</h3>
        </div>
        <div class="card-body">
            <div class="mb-3">
                <label class="form-label" for="<%= ddlSubjects.ClientID %>">Selecciona una materia:</label>
                <asp:DropDownList ID="ddlSubjects" runat="server" AutoPostBack="true"
                                  OnSelectedIndexChanged="ddlSubjects_SelectedIndexChanged" CssClass="form-select">
                </asp:DropDownList>
            </div>

            <div class="table-responsive">
                <asp:GridView ID="gvFinalGrades" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover align-middle mb-0"
                              DataKeyNames="StudentId">
                    <Columns>
                        <asp:BoundField DataField="StudentName" HeaderText="Estudiante" />
                        <asp:BoundField DataField="AverageGrade" HeaderText="Promedio de Trabajos" />
                        <asp:BoundField DataField="AttendancePercentage" HeaderText="% Asistencia" DataFormatString="{0:0.##}%" />
                        <asp:TemplateField HeaderText="Nota Final">
                            <ItemTemplate>
                                <asp:TextBox ID="txtFinalGrade" runat="server" CssClass="form-control form-control-sm"
                                             Text='<%# Bind("FinalGrade") %>' aria-label="Nota final del estudiante"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <div class="mt-3 d-flex align-items-center gap-3">
                <asp:Button ID="btnSaveFinalGrades" runat="server" Text="Guardar Notas Finales"
                            CssClass="btn btn-primary" OnClick="btnSaveFinalGrades_Click" />
                <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
