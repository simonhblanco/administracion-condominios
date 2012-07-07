<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Condominios.Dominio.Cuota>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Pagar Cuota #<%: Model.IdCuota %></h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Detalles</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Mes) %>
            </div>
            <div class="editor-field">
                <%: Model.Mes %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Anio) %>
            </div>
            <div class="editor-field">
                <%: Model.Anio %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Importe) %>
            </div>
            <div class="editor-field">
                <%: Model.Importe %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaVencimiento) %>
            </div>
            <div class="editor-field">
                <%: Model.FechaVencimiento %>
            </div>
            
            <div class="editor-label">
                Tipo de Pago
            </div>
            <div class="editor-field">
                <input type="radio" name="tipoPago" value="E" checked="checked"/>Efectivo
                <input type="radio" name="tipoPago" value="C"/>Tarjeta de Crédito
                <input type="radio" name="tipoPago" value="T"/>Transferencia Bancaria
            </div>
            
            <p>
                <input type="submit" value="Pagar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar", "Index") %>
    </div>

</asp:Content>

