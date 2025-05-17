<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchTeacher.ascx.cs"
    Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher.SearchTeacher" %>
<div class="container mt-3">
    <h4>Buscar Maestro</h4>

    <div class="row mb-3">
        <div class="col-md-6">
            <asp:TextBox ID="txtSearchTerm" runat="server" CssClass="form-control" placeholder="Ingrese nombre o email"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <div class="form-check form-check-inline">
                <asp:RadioButton ID="rbSearchByName" runat="server" GroupName="SearchType"
                    CssClass="form-check-input" Checked="true" />
                <label class="form-check-label">Por Nombre</label>
            </div>
            <div class="form-check form-check-inline">
                <asp:RadioButton ID="rbSearchByEmail" runat="server" GroupName="SearchType"
                    CssClass="form-check-input" />
                <label class="form-check-label">Por Email</label>
            </div>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnSearch" runat="server" Text="Buscar"
                CssClass="btn btn-primary" OnClick="btnSearch_Click" />
        </div>
    </div>

    <!-- Tabla de Resultados -->
    <div class="table-responsive">
        <asp:GridView ID="GridViewResults" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
            Visible="false" EmptyDataText="No se encontraron resultados.">
            <Columns>
                <asp:BoundField DataField="TeacherID" HeaderText="ID" />
                <asp:BoundField DataField="FirstName" HeaderText="Nombre" />
                <asp:BoundField DataField="LastName" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Status" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>
</div>