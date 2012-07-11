<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Acerca de</h2>
    <p>
        El sistema de Administración de Condomios podrá realizar lo siguiente:
    </p>
    <ol>
        <li>Registrar a los residentes y propietarios.</li>
        <li>Registrar las viviendas con su respectivo propietario.</li>
        <li>Registrar las cuotas de las viviendas.</li>
        <li>Pagar cuotas pendientes.</li>
        <li>Mostrar lista de cuotas vencidas.</li>
    </ol>
</asp:Content>
