<%@ Control Language="C#" CodeBehind="UpdateTeacher.ascx.cs" Inherits="SistemsProyect.Components.Pages.Actions.Admin.ViewsButton.Teacher.AdminTeacher.UpdateTeacher" %>

<div class="container mt-3">
    <h4 class="mb-3">Buscar Profesor</h4>

    <!-- Mensaje de error -->
    <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-2 d-block" />

    <!-- Selección por qué buscar -->
    <div class="form-group">
        <label>Buscar por:</label>
        <asp:RadioButtonList ID="rblBuscarPor" runat="server" CssClass="form-check" RepeatDirection="Horizontal">
            <asp:ListItem Text="Email" Value="email" Selected="True" />
            <asp:ListItem Text="Teléfono" Value="telefono" />
        </asp:RadioButtonList>
    </div>

    <!-- Campos de búsqueda -->
    <div class="form-row mb-2">
        <div class="form-group col-md-6">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Ingrese el email" />
        </div>
        <div class="form-group col-md-6">
            <label>Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Ingrese el teléfono" />
        </div>
    </div>

    <!-- Botón de búsqueda -->
    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />

    <!-- Resultados -->
    <asp:GridView ID="gvResultados" runat="server" CssClass="table table-bordered table-hover mt-4"
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