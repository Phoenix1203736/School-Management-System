<%@ Page Title="Generar Reporte" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="GenerateReport.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.Reports.GenerateReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            <h3 class="mb-0">Generar Reporte de Materia</h3>
        </div>
        <div class="card-body">
            <div class="mb-3">
                <label class="form-label" for="<%= ddlSubjects.ClientID %>">Selecciona una materia:</label>
                <asp:DropDownList ID="ddlSubjects" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjects_SelectedIndexChanged" CssClass="form-select">
                    <asp:ListItem Text="-- Selecione una materia --" Value="" />
                </asp:DropDownList>
            </div>

            <div class="table-responsive">
                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover align-middle mb-0">
                    <Columns>
                        <asp:BoundField DataField="StudentFullName" HeaderText="Estudiante" />
                        <asp:BoundField DataField="AssignmentAverage" HeaderText="Prom. Trabajos" />
                        <asp:BoundField DataField="AttendanceAverage" HeaderText="Prom. Asistencias" />
                        <asp:BoundField DataField="FinalGrade" HeaderText="Nota Final" />
                    </Columns>
                </asp:GridView>
            </div>

            <div class="mt-3">
                <asp:LinkButton ID="btnExportPdf" runat="server" CssClass="btn btn-primary" OnClick="btnExportPdf_Click">
                    <svg class="icon" viewBox="0 0 24 24" aria-hidden="true"><path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"/><polyline points="7 10 12 15 17 10"/><line x1="12" y1="15" x2="12" y2="3"/></svg>
                    <span>Exportar a PDF</span>
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
