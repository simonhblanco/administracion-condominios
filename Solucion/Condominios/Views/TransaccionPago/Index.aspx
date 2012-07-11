<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Condominios.Dominio.Cuota>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Cuotas Pendientes - Vivienda <%: (String)Request["numVivienda"] %></h2>

    <div class="editor-label">
        Número de vivienda
    </div>
    <div class="editor-field">
    <% using (Html.BeginForm())
       {%>
        <input type="text" name="numVivienda" value="<%: (String)Request["numVivienda"] %>"> <input type="submit" value="Mostrar" />
    <% } %>
    </div>

    <table>
        <tr>
            <th>
                IdCuota
            </th>
            <th>
                Fecha de Vencimiento
            </th>
            <th>
                Monto
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.IdCuota %>
            </td>
            <td>
                <%: String.Format("{0:MM/dd/yyyy}", item.FechaVencimiento) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Importe) %>
            </td>
            <td>
                <%: Html.ActionLink("Pagar Cuota", "Edit", new { id = item.IdCuota })%>
            </td>
        </tr>
    
    <% } %>

    </table>

</asp:Content>

