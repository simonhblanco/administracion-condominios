<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Condominios.Dominio.Vivienda>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear Vivienda
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Campos</legend>
            
            <%--<div class="editor-label">
                <%: Html.LabelFor(model => model.NumVivienda) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NumVivienda) %>
                <%: Html.ValidationMessageFor(model => model.NumVivienda) %>
            </div>--%>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Ubicacion) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Ubicacion) %>
                <%: Html.ValidationMessageFor(model => model.Ubicacion) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Numero) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Numero) %>
                <%: Html.ValidationMessageFor(model => model.Numero) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Metraje) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Metraje) %>
                <%: Html.ValidationMessageFor(model => model.Metraje) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Tipo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Tipo) %>
                <%: Html.ValidationMessageFor(model => model.Tipo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Residente) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Residente)%>
                <%: Html.ValidationMessageFor(model => model.Residente)%>
            </div>            

            <p>
                <input type="submit" value="Crear" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Regresar a la lista", "Index")%>
    </div>

</asp:Content>

