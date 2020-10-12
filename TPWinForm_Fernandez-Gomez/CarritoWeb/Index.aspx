<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CarritoWeb.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3">

        <%foreach (Dominio.Articulo item in listaArticulo)
            { %>
        <div class="col mb-4">
            <div class="card border-dark mb-3" style="width: 18rem;">
                <img src="<%= item.ImagenUrl %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><% = item.Nombre %></h5>
                    <p class="card-text"><%= item.Descripcion %></p>
                    <a href="#" class="btn btn-primary">Agregar a carrito</a>
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>

