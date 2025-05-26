<%@ Page Title="Title" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="GenerateReport.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.Reports.GenerateReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Generar Reporte de Materia</h2>

    <asp:DropDownList ID="ddlSubjects" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjects_SelectedIndexChanged" CssClass="form-control">
        <asp:ListItem Text="-- Selecione una materia --" Value="" />
    </asp:DropDownList>
    <br />
    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="StudentFullName" HeaderText="Estudiante" />
            <asp:BoundField DataField="AssignmentAverage" HeaderText="Prom. Trabajos" />
            <asp:BoundField DataField="AttendanceAverage" HeaderText="Prom. Asistencias" />
            <asp:BoundField DataField="FinalGrade" HeaderText="Nota Final" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnExportPdf" runat="server" Text="Exportar a PDF" OnClick="btnExportPdf_Click" CssClass="btn btn-primary" />
</asp:Content>
