<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="UI.Web.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Academia</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="text-center">
        <form class="form" role="form" runat="server">
            <%  if (Page.User.Identity.IsAuthenticated)
                { %>
            <br />
            <h2>Bienvenido
                <asp:Literal ID="userName" EnableViewState="false"
                    runat="server" Text=""></asp:Literal></h2>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="desloguearse">¿Desea cerrar sesión?</asp:LinkButton>
            <% }
                else
                { %>
            <br />
            <h2>Bienvenido</h2>
            <br />
            <h3>Inicie sesión para poder continuar!</h3>
            <br />
            <div class="col-4 m-auto">
                <div class="form-group">
                    <asp:TextBox ID="txtNombreUsuario" placeholder="Usuario" required="" class="form-control form-control-sm" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtClave" placeholder="Password" required="" class="form-control form-control-sm" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:CheckBox ID="chkRecordar" runat="server" Text="Recordar proxima vez" />
                </div>
                <div class="form-group">
                    <asp:Button type="submit" runat="server" OnClick="loguearse" class="btn btn-primary btn-block" Text="Aceptar" />
                </div>
                <asp:Label ID="LoginError" runat="server" class="invalid-feedback d-block" Text=""></asp:Label>
            </div>
            <% } %>
        </form>
    </div>
</asp:Content>
