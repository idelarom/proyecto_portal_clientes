using System;

namespace presentacion
{
    public partial class Global : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.MaintainScrollPositionOnPostBack = true;
            string usuario = (Session["usuario"] as string) == null ? "" : (Session["usuario"] as string);
            String puesto = (Session["puesto"] as string) == null ? "" : (Session["puesto"] as string);
            if (usuario == "" || puesto == "")
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                Response.Redirect("login.aspx" + (Convert.ToBoolean(Session["cliente"]) ? "?c=1" : ""));
            }
            if (!IsPostBack)
            {
                Session["correo_cliente"] = "isaacdelarosamendez@gmail.com";
                Session["tipo_usuario"] = "administrador";
                string nombre = Session["nombre"] == null ? "" : Session["nombre"] as string;
                lblname.Text = nombre;
                lblname2.Text = nombre;
                lblname3.Text = nombre;
                lblpuesto.Text = puesto;
                DateTime localDate = DateTime.Now;
                string date = localDate.ToString();
                date = date.Replace("/", "_");
                date = date.Replace(":", "_");
                date = date.Replace(" ", "");
                string url = "/"+System.Configuration.ConfigurationManager.AppSettings["server"] + "/img/user.png?date=" + date;
              
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string url = "login.aspx" + (Convert.ToBoolean(Session["cliente"]) ? "?c=1" : "");
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect(url);
        }
    }
}