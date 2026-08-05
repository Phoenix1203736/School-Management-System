<%@ Control Language="C#" CodeBehind="UpdateTeacher.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher.UpdateTeacher" %>

<div class="card">
    <div class="card-header">
        <h4 class="mb-0">Buscar Profesor</h4>
    </div>
    <div class="card-body">
        <!-- Mensaje de error -->
        <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-2 d-block" />

        <!-- Selección por qué buscar -->
        <div class="mb-3">
            <label class="form-label">Buscar por:</label>
            <asp:RadioButtonList ID="rblBuscarPor" runat="server" CssClass="form-check" RepeatDirection="Horizontal">
                <asp:ListItem Text="Email" Value="email" Selected="True" />
                <asp:ListItem Text="Teléfono" Value="telefono" />
            </asp:RadioButtonList>
        </div>

        <!-- Campos de búsqueda -->
        <div class="row mb-3">
            <div class="col-md-6">
                <label class="form-label" for="<%= txtEmail.ClientID %>">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Ingrese el email" />
            </div>
            <div class="col-md-6">
                <label class="form-label" for="<%= txtTelefono.ClientID %>">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Ingrese el teléfono" />
            </div>
        </div>

        <!-- Botón de búsqueda -->
        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />

        <!-- Resultados -->
        <div class="table-responsive mt-4">
            <asp:GridView ID="gvResultados" runat="server" CssClass="table table-bordered table-hover align-middle mb-0"
                          AutoGenerateColumns="True" EmptyDataText="No se encontraron profesores." Visible="True">
                <%-- <Columns> --%>
                <%--     <asp:BoundField DataField="fisrt_name" HeaderText="Nombre" /> --%>
                <%--     <asp:BoundField DataField="last_name" HeaderText="Apellido" /> --%>
                <%--     <asp:BoundField DataField="email" HeaderText="Email" /> --%>
                <%--     <asp:BoundField DataField="password" HeaderText="Contraseña"/> --%>
                <%--     <asp:BoundField DataField="phone" HeaderText="Teléfono" /> --%>
                <%--     <asp:BoundField DataField="status" /> --%>
                <%--     <asp:BoundField DataField="Specialization" HeaderText="Especialización" /> --%>
                <%-- </Columns> --%>
            </asp:GridView>
        </div>
    </div>
</div>
