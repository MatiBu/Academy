<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Usuarios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblHabilitado" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="cbHabilitado" runat="server"></asp:CheckBox>
        <br />
        <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario: "></asp:Label>
        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblClave" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="lblRepetirClave" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password"></asp:TextBox>
        <br />        
    </asp:Panel>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="lnkEditar" runat="server">Editar</asp:LinkButton>
        <asp:LinkButton ID="lnkEliminar" runat="server">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lnkNuevo" runat="server">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formActionsPanel" runat="server">
        <asp:LinkButton ID="lnkAceptar" runat="server">Aceptarr</asp:LinkButton>
        <asp:LinkButton ID="lnkCancelar" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
