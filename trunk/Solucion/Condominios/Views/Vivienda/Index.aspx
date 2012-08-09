<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Condominios.SRVivienda.DVivienda>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de Viviendas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Viviendas</h2>

    <table>
        <tr>
            <th></th>
            <th>NumVivienda</th>
            <th>Ubicacion</th>
            <th>Numero</th>
            <th>Metraje</th>
            <th>Tipo</th>
            <th>Residente</th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { NumVivienda = item.NumVivienda })%> |
                <%: Html.ActionLink("Details", "Details", new { NumVivienda = item.NumVivienda })%> |
                <%: Html.ActionLink("Delete", "Delete", new { NumVivienda = item.NumVivienda })%>
            </td>
            <td><%: item.NumVivienda %></td>
            <td><%: item.Ubicacion %></td>
            <td><%: item.Numero %></td>
            <td><%: item.Metraje %></td>
            <td><%: item.Tipo %></td>
            <td><%: item.Residente.DNI %></td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear", "Create") %>
    </p>

</asp:Content>

