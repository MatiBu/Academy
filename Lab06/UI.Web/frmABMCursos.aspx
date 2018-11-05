<%@ Page Language="C#"MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="frmABMCursos.aspx.cs" Inherits="UI.Web.frmABMCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Usuarios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <form id="form1" runat="server">


        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
               <%-- <asp:Label ID="lblBuscar" runat="server" Text="Buscar por Nombre de Usuario"></asp:Label>
                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>--%>
                <br />
                <br />
                <%--<asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />--%>
                <br />
                <br />
                <asp:GridView ID="grvCursos" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grvCursos_SelectedIndexChanged"
                    
                    DataKeyNames="ID">
                    <Columns>                        
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" SortExpression="Nombre" />
                        <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                        <asp:BoundField DataField="IDComision" HeaderText="Comision" />
                        <asp:BoundField DataField="IDMateria" HeaderText="Materia" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
            </div>         
        </asp:Panel>
        <div>
            <br />
            <asp:Label ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
            <asp:TextBox ID="txtCupo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAnioCalendario" runat="server" Text="Año Calendario: "></asp:Label>
            <asp:TextBox ID="txtAnioCalendario" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAnioCalendario0" runat="server" Text="Camision: "></asp:Label>
            <asp:TextBox ID="txtComision" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Materia" runat="server" Text="Materia: "></asp:Label>
            <asp:TextBox ID="txtMateria" runat="server"></asp:TextBox>
            <br />
            <br />
            <%--<asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
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
            <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password"></asp:TextBox>--%>
            <br />
        </div>
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
        <br />      
    </form>
</asp:Content>
