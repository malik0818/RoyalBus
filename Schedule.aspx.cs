using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Schedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bus_dbEntities db = new bus_dbEntities();
            var lgs = (from x in db.tbl_schedule 
                       join y in db.tbl_route on x.fk_route equals y.route_id 
                       join a in db.tbl_station on y.route_source equals a.station_id
                       join b in db.tbl_station on y.route_destination equals b.station_id 
                       select new {ID = x.schedule_id, Source = a.station_name, Destination = b.station_name, Timning = x.schedule_time }).ToList();
            var stations = (from x in db.tbl_station select x).ToList();
            var bus = (from x in db.tbl_bus select x).ToList();
            grid1.DataSource = lgs;
            grid1.DataBind();
            Schedule_bus.DataSource = bus;
            Schedule_bus.DataTextField = "bus_name";
            Schedule_bus.DataValueField = "bus_id";
            Schedule_bus.DataBind();

            
            Schedule_Source.DataSource = stations;
            Schedule_Source.DataTextField = "station_name";
            Schedule_Source.DataValueField = "station_id";
            Schedule_Source.DataBind();
            Schedule_Source.SelectedIndex = 0;

            int source = int.Parse(Schedule_Source.SelectedValue.ToString());
            var dest = (from x in db.tbl_route join y in db.tbl_station on x.route_destination equals y.station_id where x.route_source == source select y).ToList();
            Schedule_Destination.DataSource = dest;
            Schedule_Destination.DataTextField = "station_name";
            Schedule_Destination.DataValueField = "station_id";
            Schedule_Destination.DataBind();
            int destination = int.Parse(Schedule_Destination.SelectedValue.ToString());
            var timming = (from x in db.tbl_time select x).ToList();
            Schedule_timming.DataSource = timming;
            Schedule_timming.DataTextField = "time_value";
            Schedule_timming.DataValueField = "time_id";
            Schedule_timming.DataBind();

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
            
        
    }

    protected void Schedule_Source_SelectedIndexChanged(object sender, EventArgs e)
    {
        bus_dbEntities db = new bus_dbEntities();
        int source = int.Parse(Schedule_Source.SelectedValue.ToString());
        var dest = (from x in db.tbl_route join y in db.tbl_station on x.route_destination equals y.station_id where x.route_source == source select y).ToList();
        Schedule_Destination.DataSource = dest;
        Schedule_Destination.DataTextField = "station_name";
        Schedule_Destination.DataValueField = "station_id";
        Schedule_Destination.DataBind();
        int destination = int.Parse(Schedule_Destination.SelectedValue.ToString());
    }
    protected void btn_add_Schedule_Click(object sender, EventArgs e)
    {
        bus_dbEntities db = new bus_dbEntities();
        //Create new instance and assign values to columns
        tbl_schedule route = new tbl_schedule();
        int source = int.Parse(Schedule_Source.SelectedValue.ToString());
        int dest = int.Parse(Schedule_Destination.SelectedValue.ToString());
        route.fk_route = (from x in db.tbl_route where x.route_source == source && x.route_destination == dest select x).ToList()[0].route_id;
        route.schedule_time = TimeSpan.Parse(Schedule_timming.SelectedItem.Text.ToString());
        route.fk_bus = int.Parse(Schedule_bus.SelectedValue.ToString());
        //Add instance in db
        db.tbl_schedule.Add(route);
        db.SaveChanges();

        var lgs = (from x in db.tbl_route join y in db.tbl_station on x.route_source equals y.station_id join z in db.tbl_station on x.route_destination equals z.station_id select new { ID = x.route_id, Source = y.station_name, Destination = z.station_name }).ToList();
        grid1.DataSource = lgs;
        grid1.DataBind();
    }
} 