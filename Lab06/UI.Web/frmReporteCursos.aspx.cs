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
            rpt.SetDataSource(da.GetAllCursosComisionMateria());
            CrystalReportViewer1.ReportSource = rpt;
            Session.Add("report", rpt);
        }
    }
}