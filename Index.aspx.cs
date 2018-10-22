using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bus_dbEntities db = new bus_dbEntities();
         //   var stations = (from x in db.tbl_station select x).ToList();

          //  bus_dept.DataSource = stations;
            bus_dept.DataTextField = "station_name";
            bus_dept.DataValueField = "station_id";
            bus_dept.DataBind();
            bus_dept.SelectedIndex = 0;

           // int source = int.Parse(bus_dept.SelectedValue.ToString());
         //   var dest = (from x in db.tbl_route join y in db.tbl_station on x.route_destination equals y.station_id where x.route_source == source select y).ToList();
         //   bus_arvl.DataSource = dest;
            bus_arvl.DataTextField = "station_name";
            bus_arvl.DataValueField = "station_id";
            bus_arvl.DataBind();
        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        MakeAccessible(gridview1);
    }
    public static void MakeAccessible(GridView grid)
    {
        if (grid.Rows.Count <= 0) return;
        grid.UseAccessibleHeader = true;
        grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        if (grid.ShowFooter)
            grid.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    protected void bus_dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        bus_dbEntities db = new bus_dbEntities();
        int source = int.Parse(bus_dept.SelectedValue.ToString());
        var dest = (from x in db.tbl_route join y in db.tbl_station on x.route_destination equals y.station_id where x.route_source == source select y).ToList();
        bus_arvl.DataSource = dest;
        bus_arvl.DataTextField = "station_name";
        bus_arvl.DataValueField = "station_id";
        bus_arvl.DataBind();
    }
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        bus_dbEntities db = new bus_dbEntities();
        int source = int.Parse(bus_dept.SelectedValue.ToString());
        int dest = int.Parse(bus_arvl.SelectedValue.ToString());
        var lgs = (from x in db.tbl_schedule
                   join y in db.tbl_bus on x.fk_bus equals y.bus_id
                   join z in db.tbl_route on x.fk_route equals z.route_id
                   join a in db.tbl_station on z.route_source equals a.station_id
                   join b in db.tbl_station on z.route_destination equals b.station_id
                   where a.station_id == source && b.station_id == dest 
                   select new { ID = x.schedule_id, Source = a.station_name, Destination = b.station_name, Bus = y.bus_name, Seats = y.bus_capacity, Time = x.schedule_time }).ToList();

        gridview1.DataSource = lgs;
        gridview1.DataBind();
    }
    protected void gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName.ToString().Equals("book"))
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow gr = (GridViewRow)((Button) e.CommandSource).NamingContainer;
            String id =  ((HiddenField)gr.FindControl("schedule_id")).Value;
            HttpCookie cook = new HttpCookie("bookingData");
            cook.Values.Add("scheduleid",id);
            Response.Cookies.Add(cook);
            Response.Redirect("Login.aspx");
        }
    }
}