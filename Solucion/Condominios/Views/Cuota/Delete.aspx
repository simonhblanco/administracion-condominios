<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Condominios.SRCuota.DCuota>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Eliminar Cuota
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cuota</h2>

    <h3>¿Seguro de eliminar esta cuota?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">IdCuota</div>
        <div class="display-field"><%: Model.IdCuota %></div>
        
        <div class="display-label">NumVivienda</div>
        <div class="display-field"><%: Model.Vivienda.NumVivienda %></div>

        <div class="display-label">Mes</div>
        <div class="display-field"><%: Model.Mes %></div>
        
        <div class="display-label">Anio</div>
        <div class="display-field"><%: Model.Anio %></div>
        
        <div class="display-label">Importe</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Importe) %></div>
        
        <div class="display-label">FechaVencimiento</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.FechaVencimiento) %></div>
        
        <div class="display-label">Estado</div>
        <div class="display-field"><%: Model.Estado %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Eliminar" /> |
		    <%: Html.ActionLink("Regresar a la lista", "Index")%>
        </p>
    <% } %>

</asp:Content>

