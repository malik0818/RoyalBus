using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bus_dbEntities db = new bus_dbEntities();
            List<tbl_bus> lgs = (from x in db.tbl_bus select x).ToList();
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
        if (!String.IsNullOrEmpty(Bus_name.Value.ToString()) && !String.IsNullOrEmpty(Bus_capacity.Value.ToString()))
        {
            bus_dbEntities db = new bus_dbEntities();
            //Create new instance and assign values to columns
            tbl_bus bus = new tbl_bus();
            bus.bus_name = Bus_name.Value.ToString();
            bus.bus_capacity = int.Parse(Bus_capacity.Value.ToString());
            bus.bus_driver = Bus_driver.Value.ToString();
            bus.bus_contact = Bus_contact.Value.ToString();
            //Add instance in db
            db.tbl_bus.Add(bus);
            db.SaveChanges();

            List<tbl_bus> lgs = (from x in db.tbl_bus select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
        }
        else
        {
            //Show alert
            ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "alert('Please Enter bus name and capcaity');", true);
        }
    }
}