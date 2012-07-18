<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Condominios.SRResidente.DResidente>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de Residentes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Residentes</h2>

    <table>
        <tr>
            <th></th>
            <th>DNI</th>
            <th>Nombres</th>
            <th>ApellidoPaterno</th>
            <th>ApellidoMaterno</th>
            <th>Edad</th>
            <th>Correo</th>
            <th>Tipo</th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "Edit", new { DNI = item.DNI }) %> |
                <%: Html.ActionLink("Detalles", "Details", new { DNI = item.DNI })%> |
                <%: Html.ActionLink("Eliminar", "Delete", new { DNI = item.DNI })%>
            </td>            
            <td><%: item.DNI %></td>
            <td><%: item.Nombres %></td>
            <td><%: item.ApellidoPaterno %></td>
            <td><%: item.ApellidoMaterno %></td>
            <td><%: item.Edad %></td>
            <td><%: item.Correo %></td>
            <td><%: item.Tipo %></td>
            <%--Pregunta al Profesor--%>
            <%--<td><%: item.TipoDesc %></td>--%>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear", "Create") %>
    </p>

</asp:Content>

