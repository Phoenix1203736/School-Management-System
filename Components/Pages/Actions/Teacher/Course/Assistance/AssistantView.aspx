<%@ Page Title="Control de asistencias" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="AssistantView.aspx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Teacher.Course.Assistance.AssistantView" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="card">
        <div class="card-header">
            <h3 class="mb-0">Control de Asistencias</h3>
        </div>
        <div class="card-body">
            <asp:DropDownList ID="ddlSubjects" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubjects_SelectedIndexChanged" CssClass="form-select mb-3">
                <asp:ListItem Text="Seleccione Curso" Value="0" />
            </asp:DropDownList>

            <div class="row align-items-end mb-3">
                <div class="col-md-4">
                    <asp:Label ID="lblSelectDate" runat="server" Text="Selecciona Fecha:" AssociatedControlID="txtAttendanceDate" CssClass="form-label" />
                    <asp:TextBox ID="txtAttendanceDate" runat="server" TextMode="Date" CssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnLoadAttendance" runat="server" Text="Cargar Asistencia" CssClass="btn btn-primary w-100" OnClick="btnLoadAttendance_Click" />
                </div>
            </div>

            <div class="table-responsive">
                <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False"
                              OnRowEditing="gvAttendance_RowEditing"
                              OnRowCancelingEdit="gvAttendance_RowCancelingEdit"
                              OnRowUpdating="gvAttendance_RowUpdating"
                              DataKeyNames="StudentId"
                              CssClass="table table-striped table-bordered table-hover align-middle mb-0">
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" ReadOnly="true" />

                        <asp:BoundField DataField="StudentName" HeaderText="Estudiante" ReadOnly="true" />

                        <asp:TemplateField HeaderText="Asistencia">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("AttendanceStatusText") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlStatus" runat="server" SelectedValue='<%# Bind("AttendanceStatus") %>' CssClass="form-select">
                                    <asp:ListItem Value="Came">Vino</asp:ListItem>
                                    <asp:ListItem Value="Absent">Falta</asp:ListItem>
                                    <asp:ListItem Value="Justified">Justificado</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ShowEditButton="true" HeaderText="Acciones" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
