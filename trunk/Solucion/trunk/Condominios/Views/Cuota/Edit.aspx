<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Condominios.Dominio.Cuota>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar Cuota
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cuota</h2>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <%--<div class="editor-label">
                <%: Html.LabelFor(model => model.IdCuota) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.IdCuota) %>
                <%: Html.ValidationMessageFor(model => model.IdCuota) %>
            </div>--%>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Vivienda) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Vivienda.NumVivienda)%>
                <%: Html.ValidationMessageFor(model => model.Vivienda.NumVivienda)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Mes) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Mes) %>
                <%: Html.ValidationMessageFor(model => model.Mes) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Anio) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Anio) %>
                <%: Html.ValidationMessageFor(model => model.Anio) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Importe) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Importe, String.Format("{0:F}", Model.Importe)) %>
                <%: Html.ValidationMessageFor(model => model.Importe) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.FechaVencimiento) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.FechaVencimiento, String.Format("{0:g}", Model.FechaVencimiento)) %>
                <%: Html.ValidationMessageFor(model => model.FechaVencimiento) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Estado) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Estado) %>
                <%: Html.ValidationMessageFor(model => model.Estado) %>
            </div>
            
            <p>
                <input type="submit" value="Guardar" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la lista", "Index")%>
    </div>

</asp:Content>

