using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bus_dbEntities db = new bus_dbEntities();
            var lgs = (from x in db.tbl_user select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        MakeAccessible(grid1);
    }
    public static void MakeAccessible(GridView grid)
    {
        if (grid.Rows.Count <= 0) return;
        grid.UseAccessibleHeader = true;
        grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        if (grid.ShowFooter)
            grid.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName.Equals("canceled"))
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            int user_id = int.Parse(((HiddenField)gr.FindControl("user_id")).Value.ToString());
            bus_dbEntities db = new bus_dbEntities();
            tbl_login login = (from x in db.tbl_login where x.fk_user==user_id select x).ToList()[0];
            db.tbl_login.Remove(login);
            //Save to database
            db.SaveChanges();
            var original = db.tbl_user.Find(user_id);

            if (original != null)
            {
                db.Entry(original).State = EntityState.Modified;
                original.user_status = "not verified";
                db.SaveChanges();
            }

            var lgs = (from x in db.tbl_user select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
        }
        else if (e.CommandName.Equals("verify"))
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
            int user_id = int.Parse(((HiddenField)gr.FindControl("user_id")).Value.ToString());
            String username = gr.Cells[8].Text.ToString();
            String password = gr.Cells[9].Text.ToString();
            bus_dbEntities db = new bus_dbEntities();
            tbl_login login = new tbl_login();
            login.login_password = password;
            login.login_user = username;
            login.fk_user = user_id;
            db.tbl_login.Add(login);
            db.SaveChanges();

            var original = db.tbl_user.Find(user_id);

            if (original != null)
            {
                db.Entry(original).State = EntityState.Modified;
                original.user_status = "verified";
                db.SaveChanges();
            }

            var lgs = (from x in db.tbl_user select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
        }
    }
    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String status = e.Row.Cells[7].Text.ToString();

            Button cancel = (Button)e.Row.FindControl("btn_cancel");
            Button verify = (Button)e.Row.FindControl("btn_verify");
            if (status.Equals("verified"))
            {
                verify.Visible = false;
            }
            else
            {
                cancel.Visible = false;
            }
        }
    }
}