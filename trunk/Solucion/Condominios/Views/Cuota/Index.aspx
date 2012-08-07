<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Condominios.SRCuota.DCuota>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista de Cuotas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cuotas</h2>

    <table>
        <tr>
            <th></th>
            <th>IdCuota</th>
            <th>Numero de Vivienda</th>
            <th>Mes</th>
            <th>Año</th>
            <th>Importe</th>
            <th>Fecha de Vencimiento</th>
            <th>Estado</th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Edit", "Edit", new { IdCuota = item.IdCuota }) %> |
                <%: Html.ActionLink("Details", "Details", new { IdCuota = item.IdCuota })%> |
                <%: Html.ActionLink("Delete", "Delete", new { IdCuota = item.IdCuota })%>
            </td>
            <td><%: item.IdCuota %></td>
            <td><%: item.Vivienda.NumVivienda%></td>
            <td><%: item.Mes %></td>
            <td><%: item.Anio %></td>
            <td><%: String.Format("{0:F}", item.Importe) %></td>
            <td><%: String.Format("{0:g}", item.FechaVencimiento) %></td>
            <td><%: item.Estado %></td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Crear", "Create") %>
    </p>

</asp:Content>

