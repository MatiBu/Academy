using System;
using System.Web.Security;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class frmReporteCursos : System.Web.UI.Page
    {
        CursosReport rpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else if (((Usuario)Session["usuario"]) != null && ((Usuario)Session["usuario"]).ModulosPorUsuario != null && !((Usuario)Session["usuario"]).ModulosPorUsuario.Find(m => m.Modulo.Descripcion == "Reportes").PermiteConsulta)
            {
                FormsAuthentication.RedirectToLoginPage("No está autorizado para acceder a este módulo");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["report"] != null)
            {
                CrystalReportViewer1.ReportSource = (CursosReport)Session["report"];
            }
        }

        protected void GenerarRepo_Click(object sender, EventArgs e)
        {
            CursoLogic da = new CursoLogic();

            rpt = new CursosReport();
            var usr = da.GetAllCursosComisionMateria();
            rpt.SetDataSource(usr);
            CrystalReportViewer1.ReportSource = rpt;
            Session.Add("report", rpt);
        }
    }

    public class CursosComisionMaterias
    {
        public int AnioCalendario;
        public int Cupo;
        public int IDComision;
        public int IDMateria;
        public string DescripcionComision;
        public string DescripcionMateria;
        public int Horas;
    }
}