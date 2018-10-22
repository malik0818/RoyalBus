using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Station : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bus_dbEntities db = new bus_dbEntities();
            List<tbl_station> lgs = (from x in db.tbl_station select x).ToList();
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
        if (!String.IsNullOrEmpty(Station_name.Value.ToString()))
        {
            bus_dbEntities db = new bus_dbEntities();
            //Create new instance and assign values to columns
            tbl_station station = new tbl_station {station_name = Station_name.Value.ToString()};

            //Add instance in db
            db.tbl_station.Add(station);
            db.SaveChanges();

            List<tbl_station> lgs = (from x in db.tbl_station select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
        }
        else
        {
            //Show alert
            ScriptManager.RegisterStartupScript(this, GetType(), "errorAlert", "alert('Please Enter station name');", true);
        }
    }
}