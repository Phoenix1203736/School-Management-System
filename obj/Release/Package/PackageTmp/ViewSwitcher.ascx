<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSwitcher.ascx.cs" Inherits="SistemsProyect.ViewSwitcher" %>
<div id="viewSwitcher">
    <%-- ReSharper disable once CSharpWarnings::CS8604 --%>
    <%-- ReSharper disable once CSharpWarnings::CS8604 --%>
    <%-- ReSharper disable once CSharpWarnings::CS8604 --%>
    <%-- ReSharper disable CSharpWarnings::CS8604 --%>
    <%: CurrentView %> view | <a href="<%: SwitchUrl %>" data-ajax="false">Switch to <%: AlternateView %></a>
    <%-- ReSharper restore CSharpWarnings::CS8604 --%>
</div>