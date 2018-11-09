<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmABMCursos.aspx.cs" Inherits="UI.Web.frmABMCursos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cursos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <script>

document.ready(function(){
	valida();
})

function valida(){
	var cupo = $('.txtCupo');
	var anioCalendario = $('.txtAnioCalendario');	
	var ddlMateria = $('.ddlMateria').selected.text;
	var ddlComision = $('.ddlComision').selected.text;
	
	if(cupo == null){				
	window.alert("Debe cargar el cupo del curso.");
		return;
	}
	
	if(anioCalendario == null){
		window.alert("Debe cargar el año calendario.");
		return;
	}
	
	if(ddlMateria == null){
		window.alert("Debe cargar una materia.");
		return;
	}
	
	if(ddlComision ==null){
		window.alert("Debe cargar una comision.");
		return;
	}
	
}

</script>

    <form id="form1" runat="server">
        <div class="text-center">
            <h2>Administración de cursos</h2>
        </div>
        <br />

        <asp:Panel ID="formPanel" runat="server">
            <div id="buscar">
                <asp:GridView ID="grvCursos" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="grvCursos_SelectedIndexChanged"
                    DataKeyNames="ID" CssClass="table table-hover">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="AnioCalendario" HeaderText="Año Calendario" SortExpression="Nombre" />
                        <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                        <asp:BoundField DataField="Comision.Descripcion" HeaderText="Comision" />
                        <asp:BoundField DataField="Materia.Descripcion" HeaderText="Materia" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
            </div>
        </asp:Panel>
        <div class="col-5">
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblCupo" runat="server" Text="Cupo: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox class="form-control" ID="txtCupo" runat="server"></asp:TextBox>
                    <asp:Label ID="lblValidaCupo" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblAnioCalendario" runat="server" Text="Año Calendario: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox class="form-control" ID="txtAnioCalendario" runat="server"></asp:TextBox>
                    <asp:Label ID="lblAñoCalendario" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <%--<div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="lblAnioCalendario0" runat="server" Text="Camision: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox class="form-control" ID="txtComision" runat="server"></asp:TextBox>
                    <asp:Label ID="lblValidaCom" runat="server" Text=""></asp:Label>
                    <br />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="Materia" runat="server" Text="Materia: "></asp:Label>
                <div class="col-7">
                    <asp:TextBox class="form-control" ID="txtMateria" runat="server"></asp:TextBox>
                    <asp:Label ID="lblValidaMat" runat="server" Text=""></asp:Label>
                    <br />
                </div>
            </div>--%>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="Label1" runat="server" Text="Materia: "></asp:Label>
                <div class="col-7">
                    <asp:dropDownList class="form-control" ID="ddlMateria" runat="server" Width="105px"></asp:dropDownList>
                    <asp:Label ID="lblValidarMateria" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </div>
            <div class="form-group row">
                <asp:Label class="col-5 col-form-label" ID="Label2" runat="server" Text="Comision: "></asp:Label>
                <div class="col-7">
                    <asp:dropDownList class="form-control" ID="ddlComision" runat="server" Width="105px"></asp:dropDownList>
                    <asp:Label ID="lblValidarComision" runat="server" ForeColor="Red"></asp:Label>
                    <br />
                </div>
            </div>           
        </div>
        <div class="d-flex">
            <asp:Button class="ml-auto mr-2 btn btn-default" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button class="mr-2 btn btn-default" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button class="mr-2 btn btn-default" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Button class="mr-2 btn btn-default" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
        <br />
    </form>
</asp:Content>
