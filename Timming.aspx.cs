using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Timming : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bus_dbEntities db = new bus_dbEntities();
            List<tbl_time> lgs = (from x in db.tbl_time select x).ToList();
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
    protected void btn_add_Bus_Click(object sender, EventArgs e)
    {

    }
    protected void btn_add_Station_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(time_name.Value.ToString()))
        {
            bus_dbEntities db = new bus_dbEntities();
            //Create new instance and assign values to columns
            tbl_time time = new tbl_time();
            time.time_value = TimeSpan.Parse(time_name.Value.ToString());
            //Add instance in db
            db.tbl_time.Add(time);
            db.SaveChanges();

            List<tbl_time> lgs = (from x in db.tbl_time select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
        }
        else
        {
            //Show alert
            ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "alert('Please Select a proper Timming');", true);
        }
    }
}