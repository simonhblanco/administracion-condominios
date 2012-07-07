<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Condominios.Dominio.Vivienda>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Eliminar Vivienda
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Vivienda</h2>

    <h3>¿Seguro de eliminar esta vivienda?</h3>
    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">NumVivienda</div>
        <div class="display-field"><%: Model.NumVivienda %></div>
        
        <div class="display-label">Ubicacion</div>
        <div class="display-field"><%: Model.Ubicacion %></div>
        
        <div class="display-label">Numero</div>
        <div class="display-field"><%: Model.Numero %></div>
        
        <div class="display-label">Metraje</div>
        <div class="display-field"><%: Model.Metraje %></div>
        
        <div class="display-label">Tipo</div>
        <div class="display-field"><%: Model.Tipo %></div>
        
        <div class="display-label">Residente</div>
        <div class="display-field"><%: Model.Residente.DNI %></div>
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Eliminar" /> |
		    <%: Html.ActionLink("Regresar a la lista", "Index")%>
        </p>
    <% } %>

</asp:Content>

