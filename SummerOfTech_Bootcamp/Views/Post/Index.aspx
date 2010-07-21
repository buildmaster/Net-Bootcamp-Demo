<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SummerOfTech_Bootcamp.Models.PostViewModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <%= Html.ActionLink("Add new Post", "New") %>
    <%foreach(var post in Model){
          %>
          <div>
          <%=Html.ActionLink(post.Title, "edit", new { id = post.Id })%>
          </div>
          <%}%>

</asp:Content>
