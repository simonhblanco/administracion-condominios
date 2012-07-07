<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Condominios.Dominio.Cuota>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detalles
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cuota</h2>

    <fieldset>
        <legend>Campos</legend>
        
        <div class="display-label">IdCuota</div>
        <div class="display-field"><%: Model.IdCuota %></div>
        
        <div class="display-label">Vivienda</div>
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
    <p>
        <%: Html.ActionLink("Editar", "Edit", new { IdCuota =Model.IdCuota }) %> |
        <%: Html.ActionLink("Regresar a la lista", "Index")%>
    </p>

</asp:Content>

