using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Route : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bus_dbEntities db = new bus_dbEntities();
            var lgs = (from x in db.tbl_route join y in db.tbl_station on x.route_source equals y.station_id join z in db.tbl_station on x.route_destination equals z.station_id select new { ID = x.route_id, Source = y.station_name, Destination = z.station_name }).ToList();
            var stations = (from x in db.tbl_station select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
            Route_Source.DataSource = stations;
            Route_Source.DataTextField = "station_name";
            Route_Source.DataValueField = "station_id";
            Route_Source.DataBind();
            Route_Destination.DataSource = stations;
            Route_Destination.DataTextField = "station_name";
            Route_Destination.DataValueField = "station_id";
            Route_Destination.DataBind();
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
    protected void btn_add_Route_Click(object sender, EventArgs e)
    {
        bus_dbEntities db = new bus_dbEntities();
        //Create new instance and assign values to columns
        tbl_route route = new tbl_route
        {
            route_source = int.Parse(Route_Source.SelectedValue),
            route_destination = int.Parse(Route_Destination.SelectedValue)
        };

        //Add instance in db
        db.tbl_route.Add(route);
        db.SaveChanges();

        var lgs = (from x in db.tbl_route join y in db.tbl_station on x.route_source equals y.station_id join z in db.tbl_station on x.route_destination equals z.station_id select new { ID = x.route_id, Source = y.station_name, Destination = z.station_name }).ToList();
        grid1.DataSource = lgs;
        grid1.DataBind();
        
    }
}