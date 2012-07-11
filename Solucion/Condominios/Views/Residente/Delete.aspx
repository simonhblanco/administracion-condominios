<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Condominios.Dominio.Residente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Eliminar Residente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Residente</h2>

    <h3>¿Seguro de eliminar este residente?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">DNI</div>
        <div class="display-field"><%: Model.DNI %></div>
        
        <div class="display-label">Nombres</div>
        <div class="display-field"><%: Model.Nombres %></div>
        
        <div class="display-label">ApellidoPaterno</div>
        <div class="display-field"><%: Model.ApellidoPaterno %></div>
        
        <div class="display-label">ApellidoMaterno</div>
        <div class="display-field"><%: Model.ApellidoMaterno %></div>
        
        <div class="display-label">Edad</div>
        <div class="display-field"><%: Model.Edad %></div>
        
        <div class="display-label">Correo</div>
        <div class="display-field"><%: Model.Correo %></div>
        
        <div class="display-label">Tipo</div>
        <div class="display-field"><%: Model.Tipo %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Eliminar" /> |
		    <%: Html.ActionLink("Regresar a la lista", "Index")%>
        </p>
    <% } %>

</asp:Content>

