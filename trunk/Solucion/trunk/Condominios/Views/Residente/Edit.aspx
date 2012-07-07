<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Condominios.Dominio.Residente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Editar Residente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Residente</h2>

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Campos</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.DNI) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.DNI) %>
                <%: Html.ValidationMessageFor(model => model.DNI) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nombres) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nombres) %>
                <%: Html.ValidationMessageFor(model => model.Nombres) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ApellidoPaterno) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ApellidoPaterno) %>
                <%: Html.ValidationMessageFor(model => model.ApellidoPaterno) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ApellidoMaterno) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.ApellidoMaterno) %>
                <%: Html.ValidationMessageFor(model => model.ApellidoMaterno) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Edad) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Edad) %>
                <%: Html.ValidationMessageFor(model => model.Edad) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Correo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Correo) %>
                <%: Html.ValidationMessageFor(model => model.Correo) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Clave) %>
            </div>
            <div class="editor-field">                
                <%: Html.PasswordFor(model => model.Clave)%>
                <%: Html.ValidationMessageFor(model => model.Clave) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Tipo) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Tipo) %>
                <%: Html.ValidationMessageFor(model => model.Tipo) %>
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

